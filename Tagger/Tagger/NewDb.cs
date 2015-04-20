using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaggerNamespace.DAL;
using TaggerNamespace.Model;

namespace TaggerNamespace
{
    public partial class NewDb : Form
    {
        EntityContext context;
        public Item Root { get; set; }

        public NewDb(EntityContext context)
        {
            this.context = context;
            Root = null;
            InitializeComponent();
        }

        #region Events
        private void ok_Click(object sender, EventArgs e)
        {
            var path = rootPath.Text.Trim();
            DirectoryInfo dir;
            try
            {
                dir = new DirectoryInfo(path);
            }
            catch
            {
                MessageBox.Show("The path you entered is not valid.", "Invalid Path");
                return;
            }
            Root = SaveDatabase(dir, null);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper Methods
        private Item SaveDatabase(DirectoryInfo directoryInfo, int? parentId)
        {
            var folder = new Item()
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.FullName,
                ParentId = parentId,
            };
            context.Items.Add(folder);
            context.SaveChanges();

            foreach (var directory in directoryInfo.GetDirectories())
                SaveDatabase(directory, folder.Id);
            foreach (var file in directoryInfo.GetFiles())
            {
                var item = new Item()
                {
                    Name = file.Name,
                    Path = file.FullName,
                    ParentId = folder.Id
                };

                if (fileNameTags.Checked)
                    AddTagsFromName(ref item, file.Name);

                context.Items.Add(item);
            }
            context.SaveChanges();
            return folder;
        }

        private void AddTagsFromName(ref Item item, string name)
        {
            if (!name.Contains(" [Tags] ")) return;
            var tagSplit = name.Split(new string[] { " [Tags] " }, StringSplitOptions.None);
            item.Name = tagSplit.First().Trim();
            var tags = tagSplit.Last().Split('.').First().Split(' ');

            foreach (var tag in tags)
            {
                if (string.IsNullOrEmpty(tag)) continue;
                var tagToAdd = context.Tags.Where(t => t.Name == tag).SingleOrDefault();
                if (tagToAdd == null)
                {
                    tagToAdd = new Tag() { Name = tag };
                    context.Tags.Add(tagToAdd);
                    context.SaveChanges();
                }
                item.Tags.Add(tagToAdd);
            }
        }
        #endregion
    }
}
