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
using InteraktivniGeometrie;

namespace InteraktivniGeometrie
{
    public partial class PridejLomenouCaruForm : Form
    {
        List<ComboBox> body;
        List<Label> labely;
        Nakresna n;
        bool uzavrena;
        public PridejLomenouCaruForm(Nakresna n, bool uzavrena)
        {
            InitializeComponent();
            this.n = n;
            body = new List<ComboBox>();
            labely = new List<Label>();
            B_Enter.Enabled = false;
            OdeberSlot.Enabled = false;
            pridejSlot();
            pridejSlot();
            this.uzavrena = uzavrena;

        }

        public string[] vsechnyVybraneBody()
        {
            string[] ret = new string[body.Count];
            for (int i=0; i<body.Count; i++)
            {
                if (body.ElementAt(i).SelectedItem == null)
                    return null;
                ret[i] = body.ElementAt(i).SelectedItem.ToString();
            }
            return ret;
        }

        public void nahledCary()
        {
            if (vsechnyVybraneBody() == null)
                return;

            Console.WriteLine(vsechnyVybraneBody().Distinct().Count() + " : " + vsechnyVybraneBody().Count());
            if (vsechnyVybraneBody().Distinct().Count() == vsechnyVybraneBody().Count())
            {
                Console.WriteLine("kreslim nahled");
                for (int i=0; i<body.Count-1; i++)
                {
                    new Usecka(n.najdiBodPodleJmena(body.ElementAt(i).SelectedItem.ToString()), n.najdiBodPodleJmena(body.ElementAt(i+1).SelectedItem.ToString())).vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
                }
                if(uzavrena)
                    new Usecka(n.najdiBodPodleJmena(body.ElementAt(0).SelectedItem.ToString()), n.najdiBodPodleJmena(body.ElementAt(body.Count-1).SelectedItem.ToString())).vykresliSe(n.getVektory()[0], n.getVektory()[1], n.getVektory()[2], n);
            }
        }

        public void pridejSlot()
        {
            ComboBox cb = new ComboBox();
            cb.FormattingEnabled = true;
            cb.Location = new System.Drawing.Point(197 , 12 + body.Count *30);
            cb.Size = new System.Drawing.Size(91, 24);
            cb.TabIndex = 0;
            cb.Items.AddRange(n.getJmenaVsechBodu());
            cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
            body.Add(cb);

            Label l = new Label();
            l.AutoSize = true;
            l.Location = new System.Drawing.Point(145, 15+body.Count*30-30);
            
            l.Size = new System.Drawing.Size(46, 17);
            l.TabIndex = 2;
            l.Text = "Bod " + body.Count;
            labely.Add(l);
            this.Controls.Add(cb);
            this.Controls.Add(l);
            
            this.Refresh();
            this.Size = new Size(320, Math.Max(body.Count * 30 + 50, 250));
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vsechnyVybraneBody() != null)
            {
                if(vsechnyVybraneBody().Distinct().Count() == vsechnyVybraneBody().Count())
                {
                    if (TB_jmeno.Text.Length > 0)
                        B_Enter.Enabled = true;
                    else
                        B_Enter.Enabled = false;
                }
                else
                    B_Enter.Enabled = false;
            }
            else
                B_Enter.Enabled = false;



            nahledCary();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pridejSlot();
            OdeberSlot.Enabled = true;
        }

        private string getCommand(string command)
        {
            StringBuilder ret = new StringBuilder(command);
            foreach (string b in vsechnyVybraneBody())
            {
                ret.Append(" ");
                
                ret.Append(b);
            }
            
            ret.Append(" ");
            ret.Append(TB_jmeno.Text);
            return ret.ToString();
        }

        private void B_Enter_Click(object sender, EventArgs e)
        {
            try { 
            if (vsechnyVybraneBody().Distinct().Count() == vsechnyVybraneBody().Count())
            {
                    if (uzavrena)
                    {

                        n.zapis(getCommand("PridejiMnohouhelnik"));
                        n.pridejTvar(TB_jmeno.Text, vsechnyVybraneBody());
                    }
                    else {
                        n.zapis(getCommand("NakresliCaru"));
                        n.pridejCaru(TB_jmeno.Text, vsechnyVybraneBody());
                    }
                this.Close();
            } else
            {
                MessageBox.Show("Nemuzu nakreslit caru pres duplicitni body"); }
            }
            catch (DuplicitniJmenoException)
            {
                MessageBox.Show("Tvar s timto jmenem již existuje, zvolte prosím jiné jméno");
            }
        }

        private void OdeberSlot_Click(object sender, EventArgs e)
        {

            this.Controls.Remove(labely.Last());
            this.Controls.Remove(labely.Last());
            labely.RemoveAt(body.Count - 1);
            body.RemoveAt(body.Count() - 1);
            this.Refresh();
            this.Size = new Size(320, Math.Max(body.Count * 30 + 50, 250));

            if(body.Count == 2 || uzavrena && body.Count == 3)
            {
                OdeberSlot.Enabled = false;
            }
        }

        private void TB_jmeno_TextChanged(object sender, EventArgs e)
        {
            
            if (vsechnyVybraneBody() != null)
            {
                if (vsechnyVybraneBody().Distinct().Count() == vsechnyVybraneBody().Count())
                {
                    if (TB_jmeno.Text.Length > 0)
                        B_Enter.Enabled = true;
                    else
                        B_Enter.Enabled = false;
                }
                else
                    B_Enter.Enabled = false;
            }
            else
                B_Enter.Enabled = false;
        }
    }
}
