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
    public partial class PridejBod_Form : Form
    {
        
        Nakresna n;
       
        public PridejBod_Form(Nakresna n)
        {
            InitializeComponent();
            this.n = n;
            button1.Enabled = false;
            
            
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void TB_textChanged()
        {
            n.VykresliSe();
            try {
                n.nakresliBod(new Bod2D(float.Parse(TB_X.Text), float.Parse(TB_Y.Text), TB_jmeno.Text));
                if(TB_jmeno.Text.Length>0)
                    button1.Enabled = true;
            }
            catch (FormatException)
            {
                button1.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                float x = float.Parse(TB_X.Text);
                float y = float.Parse(TB_Y.Text);
                n.pridejBod(new Bod2D(float.Parse(TB_X.Text), float.Parse(TB_Y.Text), TB_jmeno.Text));
                
                n.VykresliSe();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Špatné zadání souřadnic");
            }
            catch (DuplicitniJmenoException)
            {
                MessageBox.Show("Bod s tímto jménem již existuje. Zvolte prosím jiné jméno");
            }
        }

        private void TB_X_TextChanged(object sender, EventArgs e)
        {
            TB_textChanged();
        }

        private void TB_Y_TextChanged(object sender, EventArgs e)
        {
            TB_textChanged();
        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            TB_textChanged();
        }
    }
}
