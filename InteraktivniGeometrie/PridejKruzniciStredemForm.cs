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
    public partial class PridejKruzniciStredemForm : Form
    {
        private Nakresna n;
        public PridejKruzniciStredemForm(Nakresna n)
        {
            InitializeComponent();
            CB_bod.Items.Add(" ");
            CB_bod.Items.AddRange(n.getJmenaVsechBodu());
            CB_stred.Items.Add(" ");
            CB_stred.Items.AddRange(n.getJmenaVsechBodu());
            Button_OK.Enabled = false;
            this.n = n;
        }

        private void zmenaVstupu()
        {
            if (CB_bod.SelectedItem != null && CB_stred.SelectedItem != null)
            {
                if (CB_bod.SelectedItem.ToString().Equals(" ") || CB_stred.SelectedItem.ToString().Equals(" ") || CB_stred.SelectedItem.Equals(CB_bod.SelectedItem))
                    Button_OK.Enabled = false;
                else
                {
                    new KruzniceStredova(n.najdiBodPodleJmena(CB_stred.SelectedItem.ToString()), n.najdiBodPodleJmena(CB_bod.SelectedItem.ToString()), n.getVektory()[0], n.getVektory()[1], "").klicoveCary()[0].vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                    if (TB_jmeno.Text.Length > 0)
                        Button_OK.Enabled = true;
                }
            }
            else
                Button_OK.Enabled = false;
        }



        private void Button_OK_Click(object sender, EventArgs e)
        {
            n.zapis("PridejKruznici " + CB_stred.SelectedItem.ToString() + " " + CB_bod.SelectedItem.ToString() + " " + TB_jmeno.Text);
            n.pridejKruznici(TB_jmeno.Text, new string[] { CB_stred.SelectedItem.ToString(), CB_bod.SelectedItem.ToString() });
            this.Close();
        }

        private void CB_stred_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_bod_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void Button_zmenForm_Click(object sender, EventArgs e)
        {
            this.Close();
            new PridejKruzniciForm(n).Show();
        }
    }
}
