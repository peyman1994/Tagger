using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TaggerNamespace.DAL;
using TaggerNamespace.Model;
using System.Data.Entity;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            //ListDirectory(@"C:\Users\Peyman\Documents\Visual Studio 2013\Projects\Tagger\TestFiles");
            var items = context.Items.ToList();
            //treeView.Nodes.Add(LoadTree(context.Items.Where(i => i.ParentId == null).SingleOrDefault()));
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

        private void ListDirectory(string path)
        {
            var rootDirectoryInfo = new DirectoryInfo(path);
            SaveFolder(rootDirectoryInfo, null);
        }

        private void SaveFolder(DirectoryInfo directoryInfo, int? parentId)
        {
            var folder = new Item()
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.ToString(),
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
                    Path = file.ToString(),
                    ParentId = folder.Id
                });
            }
            context.SaveChanges();
        }

        private void tag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newTag.Text))
            {
                return;
            }
            string newTagText = newTag.Text.Trim();

            var tag = context.Tags.Where(t => t.Name == newTagText).SingleOrDefault();
            if (tag == null)
            {
                tag = new Tag()
                {
                    Name = newTagText
                };
                context.Tags.Add(tag);
                context.SaveChanges();
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
        }

        private void treeView_SelectedNodesChanged(EventArgs e)
        {
            
        }
    }
}
