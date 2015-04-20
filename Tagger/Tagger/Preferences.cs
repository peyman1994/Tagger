using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaggerNamespace.DAL;
using TaggerNamespace.Model;
using TaggerNamespace.Properties;
using System.IO;

namespace TaggerNamespace
{
    public partial class Preferences : Form
    {
        private EntityContext context;
        public Preferences(EntityContext Context)
        {            
            context = Context;
            InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            if (Settings.Default.DefaultDb > 0)
            {
                InitDatabases(Settings.Default.DefaultDb);
            }
        }

        private void newDb_Click(object sender, EventArgs e)
        {
            var newDb = new NewDb(context);
            newDb.ShowDialog(this);
            if (newDb.Root == null) return;

            var listItem = new ListViewItem(newDb.Root.Name);
            listItem.SubItems.Add(newDb.Root.Path);            
            if (databases.Items.Count == 0)
            {
                //listItem.Font = new Font(listItem.Font.FontFamily, listItem.Font.Size, FontStyle.Bold);
                Settings.Default.DefaultDb = newDb.Root.Id;
                Settings.Default.Save();
            }
            databases.Items.Add(listItem);
        }

        private void InitDatabases(int defaultId)
        {
            var roots = context.Items.Where(x => x.ParentId == null).ToList();
            foreach(var root in roots)
            {
                var listItem = new ListViewItem(root.Name);
                listItem.SubItems.Add(root.Path);
                if (root.Id == defaultId)
                    listItem.Font = new Font(listItem.Font.FontFamily, listItem.Font.Size, FontStyle.Bold);
                databases.Items.Add(listItem);                
            }
        }
    }
}
