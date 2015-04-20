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

namespace TaggerNamespace
{
    public partial class Settings : Form
    {
        private EntityContext context;
        public Settings(EntityContext Context)
        {
            context = Context;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            
        }

        private void InitDatabases()
        {
            var roots = context.Items.Where(x => x.ParentId == null).ToList();
            foreach(var root in roots)
            {
                var listItem = new ListViewItem(root.Name);
                listItem.SubItems.Add(root.Path);
            }
        }
    }
}
