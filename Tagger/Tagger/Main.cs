using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaggerNamespace.DAL;
using TaggerNamespace.Model;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;

namespace TaggerNamespace
{
    public partial class Tagger : Form
    {
        private EntityContext context;

        public Tagger()
        {
            context = new EntityContext();
            InitializeComponent();
        }

        #region Events
        private void Main_Load(object sender, EventArgs e)
        {
            //EmptyDatabase();
            //SaveFolder(new DirectoryInfo(@"C:\Users\Peyman\Documents\Git\TestFiles"), null);

            treeView.Nodes.Add(LoadTree(context.Items.Where(i => i.ParentId == null).SingleOrDefault()));
            var tags = context.Tags.ToArray();
            newTag.Items.AddRange(tags);
            tagSelector.Items.AddRange(tags);
        }

        private void tagButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newTag.Text)) return;

            Tag tag;
            if (newTag.SelectedItem != null)
            {
                tag = (Tag)newTag.SelectedItem;
            }
            else
            {
                tag = new Tag()
                {
                    Name = newTag.Text.Trim()
                };
                context.Tags.Add(tag);
                context.SaveChanges();
                newTag.Items.Add(tag);
            }

            TagSelected(tag);
            DisplayTags();
            AddRecentTag(tag);
            newTag.Text = string.Empty;
        }
        private void newTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tagButton_Click(sender, e);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayTags();
        }

        private void treeView_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var itemId = Int32.Parse(e.Node.Name);
            OpenItem(itemId);
        }

        private void searchResults_DoubleClick(object sender, EventArgs e)
        {
            var items = searchResults.SelectedItems;
            foreach (var item in items)
            {
                var path = ((ListViewItem)item).SubItems[1].Text;
                Process.Start(path);
            }
        }

        private void recentTag_Click(object sender, MouseEventArgs e)
        {
            var tagId = Int32.Parse(((Label)sender).Name);
            var recentTag = context.Tags.Where(t => t.Id == tagId).SingleOrDefault();
            TagSelected(recentTag);
            AddRecentTag(recentTag);
            DisplayTags();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var query = searchQuery.Text.Trim();
            var lambda = ExpressionBuilder.BuildExpression(query);

            DisplaySearchResults(context.Items.Where(lambda).ToList());
        }

        private void appendTag_Click(object sender, EventArgs e)
        {
            searchQuery.Text += tagSelector.Text;
        }
        private void tagSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                appendTag_Click(sender, e);
        }
        #endregion

        #region Helper Methods


        private void EmptyDatabase()
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [ItemTagMaps]");
            context.Database.ExecuteSqlCommand("DELETE FROM [Items]");
            context.Database.ExecuteSqlCommand("DELETE FROM [Tags]");
        }

        public TreeNode LoadTree(Item item)
        {
            var children = context.Items.Where(i => i.ParentId == item.Id).ToList();
            var directoryNode = new TreeNode(item.Name);
            directoryNode.Name = item.Id.ToString();
            foreach (var child in children)
                directoryNode.Nodes.Add(LoadTree(child));
            return directoryNode;
        }

        private void SaveFolder(DirectoryInfo directoryInfo, int? parentId)
        {
            var folder = new Item()
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.FullName,
                ParentId = parentId,
                IsFolder = true
            };
            context.Items.Add(folder);
            context.SaveChanges();
            foreach (var directory in directoryInfo.GetDirectories())
                SaveFolder(directory, folder.Id);
            foreach (var file in directoryInfo.GetFiles())
            {
                context.Items.Add(new Item()
                {
                    IsFolder = false,
                    Name = file.Name,
                    Path = file.FullName,
                    ParentId = folder.Id
                });
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Opens the item's path with its default application
        /// </summary>
        /// <param name="itemId"></param>
        private void OpenItem(int itemId)
        {
            var path = context.Items.Where(i => i.Id == itemId).Select(i => i.Path).SingleOrDefault();
            Process.Start(path);
        }

        /// <summary>
        /// Tags the selected nodes
        /// </summary>
        /// <param name="tag"></param>
        private void TagSelected(Tag tag)
        {
            foreach (var node in treeView.SelectedNodes)
            {
                int itemId = Int32.Parse(node.Name);
                var item = context.Items.Where(x => x.Id == itemId).SingleOrDefault();
                if (item != null)
                {
                    item.Tags.Add(tag);
                    context.Items.Attach(item);
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds the tag to the recent tags list
        /// </summary>
        /// <param name="tag"></param>
        private void AddRecentTag(Tag tag)
        {
            var label = GetRecentTagLabel(tag);
            if (recentTags.Controls.Count == 0)
            {
                recentTags.Controls.Add(label);
                return;
            }
            else if (recentTags.Controls[0].Name == label.Name)
                return;

            var tmp = recentTags.Controls.Cast<Control>().ToList();
            tmp.RemoveAll(x => x.Name == label.Name);
            recentTags.Controls.Clear();
            recentTags.Controls.Add(label);
            recentTags.Controls.AddRange(tmp.ToArray());
        }

        /// <summary>
        /// Displays the tags for the selected nodes
        /// </summary>
        private void DisplayTags()
        {
            var selectedNodes = treeView.SelectedNodes;
            tagContainer.Controls.Clear();
            List<Tag> tags = null;
            foreach (var node in selectedNodes)
            {
                int itemId = Int32.Parse(node.Name);
                var itemTags = context.Items.Where(x => x.Id == itemId).SingleOrDefault().Tags;
                if (tags == null)
                    tags = (List<Tag>)itemTags;
                else
                    tags = tags.Intersect(itemTags).ToList();
            }
            if (tags != null)
                foreach (var tag in tags)
                    tagContainer.Controls.Add(GetTagLabel(tag));

        }

        private void DisplaySearchResults(List<Item> items)
        {
            searchResults.Items.Clear();
            foreach (var item in items)
            {
                ListViewItem listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Path);
                listItem.SubItems.Add(GetTagString(item));
                searchResults.Items.Add(listItem);
            }
        }

        private string GetTagString(Item item)
        {
            string tagString = string.Empty;
            foreach (var tag in item.Tags)
            {
                tagString += tag.Name + "; ";
            }
            return tagString;
        }

        /// <summary>
        /// Returns a label control for the given tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private Label GetTagLabel(Tag tag)
        {
            var tagLabel = new Label();
            tagLabel.Text = tag.Name;
            tagLabel.Name = tag.Id.ToString();
            tagLabel.Padding = new Padding(3);
            tagLabel.BackColor = Color.LightBlue;
            tagLabel.BorderStyle = BorderStyle.Fixed3D;
            tagLabel.AutoSize = true;
            tagLabel.Font = new Font(FontFamily.GenericSansSerif, 10);
            tagLabel.Margin = new Padding(3);
            tagLabel.Cursor = tagButton.Cursor;
            return tagLabel;
        }

        private Label GetRecentTagLabel(Tag tag)
        {
            var recentTagLabel = GetTagLabel(tag);
            recentTagLabel.MouseClick += new MouseEventHandler(recentTag_Click);
            return recentTagLabel;
        }
        #endregion
    }
}
