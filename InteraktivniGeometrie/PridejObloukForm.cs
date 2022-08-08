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
using InteraktivniGeometrie.Exceptions;

namespace InteraktivniGeometrie
{
    public partial class PridejObloukForm : Form
    {
        private Nakresna n;

        private ComboBox[] boxy;

        public PridejObloukForm()
        {
            InitializeComponent();
        }

        public PridejObloukForm(Nakresna n)
        {
            InitializeComponent();
            this.n = n;
            this.boxy = new ComboBox[] { CB_B1, CB_B2, CB_dalsi, CB_stred };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_B1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_B2_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_dalsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void CB_stred_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void zmenaVstupu()
        {
            string[] body = new string[4];
            int i = 0;
            foreach (ComboBox cb in boxy)
            {
                if (cb.SelectedItem == null)
                {
                    B_enter.Enabled = false;
                    n.VykresliSe();
                    return;
                }
                body[i] = cb.SelectedItem.ToString();
                i++;
            }
            if(body.Count() == body.Distinct().Count())
            {
                n.VykresliSe();
                new EliptickyOblouk(n.najdiBodPodleJmena(CB_stred.SelectedItem.ToString()), n.najdiBodPodleJmena(CB_dalsi.SelectedItem.ToString()),
                    n.najdiBodPodleJmena(CB_B1.SelectedItem.ToString()) , n.najdiBodPodleJmena(CB_B2.SelectedItem.ToString()), new Vektor2D(0F,1F),"").klicoveCary()[0]
                    .vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                if(TB_jmeno.Text.Length > 0)
                {
                    B_enter.Enabled = true;
                }else
                {
                    B_enter.Enabled = false;
                }

            }
        }

        private void B_enter_Click(object sender, EventArgs e)
        {
            try
            {
                n.pridejEliptickyOblouk(TB_jmeno.Text, new string[] { CB_stred.SelectedItem.ToString(), CB_dalsi.SelectedItem.ToString(), CB_B1.SelectedItem.ToString(), CB_B2.SelectedItem.ToString() });

                this.Close();
            }
            catch (DuplicitniJmenoException)
            {
                MessageBox.Show("Tvar s tímto jménem již existuje, zvolte prosím jiné jméno");
            }
        }
    }
}
