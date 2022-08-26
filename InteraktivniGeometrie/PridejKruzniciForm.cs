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
    public partial class PridejKruzniciForm : Form
    {
        private Nakresna n;
        ComboBox[] boxy;
        public PridejKruzniciForm()
        {
            InitializeComponent();
            this.boxy = new ComboBox[] { comboBox1, comboBox2, comboBox3 };
        }

        public PridejKruzniciForm(Nakresna n)
        {
            InitializeComponent();
            this.boxy = new ComboBox[] { comboBox1, comboBox2, comboBox3 };
            foreach (ComboBox cb in boxy)
            {
                cb.Items.AddRange(n.getJmenaVsechBodu());
            }
            this.n = n;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n.pridejKruznici(textBox1.Text, new string[] { comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString() });
                n.zapis("PridejKruznici " + comboBox1.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString() + " " + comboBox3.SelectedItem.ToString() + " " + textBox1.Text);
                this.Close();
            }
            catch (DuplicitniJmenoException)
            {
                MessageBox.Show("Tvar s timto jmenem již existuje");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void zmenaVstupu()
        {
            foreach (ComboBox cb in boxy){
                if(cb.SelectedItem == null)
                {
                    button1.Enabled = false;
                    return;
                }
            }
            string[] body = new string[] { comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString() };
            if(body.Count() == body.Distinct().Count() )
            {
                new Kruznice(n.najdiBodPodleJmena(body[0]), n.najdiBodPodleJmena(body[1]), n.najdiBodPodleJmena(body[2]), "").klicoveCary()[0].vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                if(textBox1.Text.Length > 0)
                    button1.Enabled = true;
                
            }else
            {
                button1.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            zmenaVstupu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new PridejKruzniciStredemForm(n).Show();
        }
    }
}
