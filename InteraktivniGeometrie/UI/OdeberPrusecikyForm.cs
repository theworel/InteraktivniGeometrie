using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteraktivniGeometrie.UI
{
    public partial class OdeberPrusecikyForm : Form
    {
        Nakresna n;
        public OdeberPrusecikyForm(Nakresna n)
        {
            InitializeComponent();
            this.n = n;
            this.comboBox1.Items.AddRange(n.getPruseciky());
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            n.odeberPruseciky((Tuple<string, string> ) comboBox1.SelectedItem);
            n.VykresliSe();
            this.Close();
        }
    }
}
