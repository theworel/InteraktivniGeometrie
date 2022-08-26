using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InteraktivniGeometrie.Tvary;

namespace InteraktivniGeometrie
{
    public partial class PridejOhniskovouElipsu : Form
    {
        private Nakresna n;
        public PridejOhniskovouElipsu()
        {
            InitializeComponent();
        }

        public PridejOhniskovouElipsu(Nakresna n)
        {
            InitializeComponent();
            this.n = n;
            CB_bod.Items.Add(" ");
            CB_bod.Items.AddRange(n.getJmenaVsechBodu());
            CB_ohnisko1.Items.Add(" ");
            CB_ohnisko1.Items.AddRange(n.getJmenaVsechBodu());
            CB_ohnisko2.Items.Add(" ");
            CB_ohnisko2.Items.AddRange(n.getJmenaVsechBodu());
        }

        private void zmenaVstupu()
        {
            if(CB_bod.SelectedItem != null && CB_ohnisko1.SelectedItem != null && CB_ohnisko2.SelectedItem != null)
            {
                if (new List<string>(new string[] { CB_bod.SelectedItem.ToString(), CB_ohnisko1.SelectedItem.ToString(), CB_ohnisko2.SelectedItem.ToString() }).Distinct().Count() == 3)
                {
                    new EliptickyObloukOhniskovy(n.najdiBodPodleJmena(CB_ohnisko1.SelectedItem.ToString()), n.najdiBodPodleJmena(CB_ohnisko2.SelectedItem.ToString()), n.najdiBodPodleJmena(CB_bod.SelectedItem.ToString()), 360, new Vektor2D(0, 1), TB_jmeno.Text).klicoveCary()[0].vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                    if (TB_jmeno.Text.Length > 0)
                    {
                        OK_Button.Enabled = true;
                    }

                    else
                        OK_Button.Enabled = false;
                    return;
                }
                
            }
            OK_Button.Enabled = false;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            n.zapis("PridejEliptickyOblouk " + CB_ohnisko1.SelectedItem.ToString() + " " + CB_ohnisko2.SelectedItem.ToString() + " " + CB_bod.SelectedItem.ToString() + " " + TB_jmeno.Text);
            n.pridejEliptickyOblouk(TB_jmeno.Text, new string[] { CB_ohnisko1.SelectedItem.ToString(), CB_ohnisko2.SelectedItem.ToString(), CB_bod.SelectedItem.ToString() });
            this.Close();
        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_ohnisko1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_ohnisko2_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_bod_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void SwitchForm_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            new PridejObloukForm(n, true).Show();
        }
    }
}
