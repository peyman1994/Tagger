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
        private List<TreeNode> SelectedNodes = new List<TreeNode>();

        public Tagger()
        {
            context = new EntityContext();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SaveFolder(new DirectoryInfo(@"Z:\Tagger\TestFiles"), null);
            //var items = context.Items.ToList();
            treeView.Nodes.Add(LoadTree(context.Items.Where(i => i.ParentId == null).SingleOrDefault()));
            newTag.Items.AddRange(context.Tags.ToArray());
        }

        private void tag_Click(object sender, EventArgs e)
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
            DisplayTags();
            newTag.Text = string.Empty;
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

        private void OpenItem(int itemId)
        {
            var path = context.Items.Where(i => i.Id == itemId).Select(i => i.Path).SingleOrDefault();
            Process.Start(path);
        }

        private void DisplayTags()
        {
            var selectedNodes = treeView.SelectedNodes;
            tagContainer.Controls.Clear();
            foreach (var node in selectedNodes)
            {
                int itemId = Int32.Parse(node.Name);
                var tags = context.Tags.Where(t => context.ItemTagMap.Where(m => m.ItemId == itemId).Select(m => m.TagId).Contains(t.Id)).ToList();
                if (tags != null)
                    foreach (var tag in tags)
                        tagContainer.Controls.Add(GetTagLabel(tag));
            }
        }

        private Label GetTagLabel(Tag tag)
        {
            var tagLabel = new Label();
            tagLabel.Text = tag.Name;
            tagLabel.Name = tag.Id.ToString();
            tagLabel.Padding = new Padding(3);
            tagLabel.BackColor = Color.LightBlue;
            tagLabel.BorderStyle = BorderStyle.Fixed3D;
            tagLabel.AutoSize = true;
            return tagLabel;
        }
    }
}
