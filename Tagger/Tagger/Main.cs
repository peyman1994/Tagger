using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaggerNamespace.DAL;
using TaggerNamespace.Model;
using System.Data.Entity;
using System.Diagnostics;

namespace TaggerNamespace
{
    public partial class Tagger : Form
    {
        private EntityContext context;
        private Tag[] Tags;

        public Tagger()
        {
            context = new EntityContext();
            Tags = context.Tags.ToArray();
            InitializeComponent();
        }

        #region Events
        private void Main_Load(object sender, EventArgs e)
        {
            //SaveFolder(new DirectoryInfo(@"Z:\Tagger\TestFiles"), null);
            //var items = context.Items.ToList();
            treeView.Nodes.Add(LoadTree(context.Items.Where(i => i.ParentId == null).SingleOrDefault()));
            newTag.Items.AddRange(Tags);
            tagSelector.Items.AddRange(Tags);            
            DisplaySearchResults(context.Items.ToList());            
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

        private void recentTag_Click(object sender, MouseEventArgs e)
        {
            var label = (Label)sender;
            var recentTag = new Tag()
            {
                Name = label.Text,
                Id = Int32.Parse(label.Name)
            };
            TagSelected(recentTag);
            AddRecentTag(recentTag);
            DisplayTags();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

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
                context.ItemTagMap.Add(new ItemTagMap()
                {
                    ItemId = itemId,
                    TagId = tag.Id
                });
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
            foreach (var node in selectedNodes)
            {
                int itemId = Int32.Parse(node.Name);
                var tags = context.Tags.Where(t => 
                    context.ItemTagMap.Where(m => m.ItemId == itemId).Select(m => m.TagId).Contains(t.Id))
                    .OrderBy(x => x.Name).ToList();

                if (tags != null)
                    foreach (var tag in tags)
                        tagContainer.Controls.Add(GetTagLabel(tag));
            }
        }

        private void DisplaySearchResults(List<Item> items)
        {
            foreach(var item in items)
            {
                ListViewItem listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Path);
                searchResults.Items.Add(listItem);
            }
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
