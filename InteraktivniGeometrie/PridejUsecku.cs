using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InteraktivniGeometrie.Exceptions;

namespace InteraktivniGeometrie
{
    public partial class PridejUsecku : Form
    {
        Nakresna n;
        public PridejUsecku(Nakresna n)
        {
            
            InitializeComponent();
            CB_bod1.Items.AddRange(n.getJmenaVsechBodu());
            CB_bod2.Items.AddRange(n.getJmenaVsechBodu());
            this.n = n;
            button1.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_bod2.SelectedItem != null && CB_bod1.SelectedItem != null)
            {
                if (!CB_bod2.SelectedItem.Equals(CB_bod1.SelectedItem))
                {
                    n.VykresliSe();
                    new Usecka(n.najdiBodPodleJmena(CB_bod1.SelectedItem.ToString()), n.najdiBodPodleJmena(CB_bod2.SelectedItem.ToString())).vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                    if (TB_jmeno.Text.Length > 0)
                        button1.Enabled = true;
                    else
                        button1.Enabled = false;
                }else
                {
                    button1.Enabled = false;
                }
            }else
            {
                button1.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n.pridejCaru(TB_jmeno.Text, new string[] { CB_bod1.SelectedItem.ToString(), CB_bod2.SelectedItem.ToString() });
                n.zapis("PridejCaru " + CB_bod1.SelectedItem.ToString() + " " + CB_bod2.SelectedItem.ToString() + " " + TB_jmeno.Text);
                this.Close();
            }
            catch (DuplicitniJmenoException)
            {
                MessageBox.Show("Cara s tímto jménem již existuje, zvolte prosím jiné jméno");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2_SelectedIndexChanged(sender, e);
        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            comboBox2_SelectedIndexChanged(sender, e);
        }
    }
}
