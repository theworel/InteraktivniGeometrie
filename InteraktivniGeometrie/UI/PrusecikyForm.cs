using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteraktivniGeometrie
{
    public partial class PrusecikyForm : Form
    {
        private Nakresna n;
        public PrusecikyForm(Nakresna n)
        {
            this.n = n;
            InitializeComponent();
            CB_tvar1.Items.Add(" ");
            CB_tvar1.Items.AddRange(n.getJmenaVsechTvaru());
            CB_tvar2.Items.Add(" ");
            CB_tvar2.Items.AddRange(n.getJmenaVsechTvaru());
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
           
            n.nakresliPruseciky(CB_tvar1.SelectedItem.ToString(), CB_tvar2.SelectedItem.ToString());
            n.pridejPruseciky(CB_tvar1.SelectedItem.ToString(), CB_tvar2.SelectedItem.ToString());
            n.VykresliSe();
            this.Close();
        }
    }
}
