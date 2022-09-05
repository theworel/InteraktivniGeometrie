using InteraktivniGeometrie.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteraktivniGeometrie
{
    public partial class Form1 : Form
    {
        static List<Command> allCommands;
        static Nakresna n;
        private string textFile;
        public Form1()
        {
            
            InitializeComponent();
            n = new Nakresna(panel1, comboBoxBody, CB_zvolenyTvar, 2);
            allCommands = new List<Command>();
            allCommands.Add(new PridejBodCommand());
            allCommands.Add(new NakresliCaruCommand());
            allCommands.Add(new PridejMnohouhelnikCommand());
            
            allCommands.Add(new PridejKruzniciCommand());
            allCommands.Add(new PridejEliptickyObloukCommand());
            allCommands.Add(new PosunBodCommand());
            allCommands.Add(new PridejPrusecikyCommand());
            allCommands.Add(new OdeberBod());
            allCommands.Add(new OdeberTvar());
            B_posunBodDoleva.Enabled = false;
            B_posunBodDolu.Enabled = false;
            B_posunBodDoprava.Enabled = false;
            B_posunBodNahoru.Enabled = false;
            B_OdeberBod.Enabled = false;
            B_OdeberTvar.Enabled = false;
            textFile = null;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            n.posun(new float[] { 0, -5 });
            n.VykresliSe();
        }

        private void buttonTurnLeft_Click(object sender, EventArgs e)
        {
            n.otoc(-0.1F);
            n.VykresliSe();
        }

        private void buttonTurnRight_Click(object sender, EventArgs e)
        {
            n.otoc(0.1F);
            n.VykresliSe();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            n.posun(new float[] { 5, 0 });
            n.VykresliSe();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            n.posun(new float[] { -5, 0 });
            n.VykresliSe();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            n.posun(new float[] { 0, 5 });
            n.VykresliSe();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*string[] vstup = textBox1.Text.Split(' ');
                string commandName = vstup[0];
                string[] args = new string[vstup.Length - 1];
                Array.ConstrainedCopy(vstup, 1, args, 0, args.Length);
                foreach(Command c in allCommands)
                {
                    if (c.getName().Equals(commandName))
                        try
                        {
                            c.exec(args, n);
                        }
                        catch (SpatneArgumentyPrikazuException)
                        {
                            Console.WriteLine("špatný počet argumentů");
                        }
                }*/

                executeCommand(textBox1.Text);
                n.VykresliSe();
            }
        }

       public void executeCommand(string command)
        {
            string[] vstup = command.Split(' ');
            string commandName = vstup[0];
            string[] args = new string[vstup.Length - 1];
            Array.ConstrainedCopy(vstup, 1, args, 0, args.Length);
            foreach (Command c in allCommands)
            {
                if (c.getName().Equals(commandName))
                    try
                    {
                        c.exec(args, n);
                       
                        n.VykresliSe();
                    }
                    catch (SpatneArgumentyPrikazuException)
                    {
                        Console.WriteLine("špatný počet argumentů");
                    }
            }
            
            
        }

        private void comboBoxBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            n.vyberBod(comboBoxBody.SelectedItem.ToString());
            if(comboBoxBody.SelectedItem.ToString().Length == 0)
            {
                B_OdeberBod.Enabled = false;
                
                B_posunBodDoleva.Enabled = false;
                B_posunBodDolu.Enabled = false;
                B_posunBodDoprava.Enabled = false;
                B_posunBodNahoru.Enabled = false;
            }
            else
            {
                B_OdeberBod.Enabled = true;
                if (n.najdiBodPodleJmena(comboBoxBody.SelectedItem.ToString()).jePrusecik())
                {
                    B_posunBodDoleva.Enabled = false;
                    B_posunBodDolu.Enabled = false;
                    B_posunBodDoprava.Enabled = false;
                    B_posunBodNahoru.Enabled = false;
                }
                else
                {
                    B_posunBodDoleva.Enabled = true;
                    B_posunBodDolu.Enabled = true;
                    B_posunBodDoprava.Enabled = true;
                    B_posunBodNahoru.Enabled = true;
                }
            }
        }

        private void buttonPosunVybranyBodDolu(object sender, EventArgs e)
        {
            string jmeno = n.jmenoVybraneho();
            executeCommand("PosunBod 0 5 " + jmeno);
            //n.posunVybranyBod(0, 5F);
        }

        private void buttonPosunVybranyBodDoprava(object sender, EventArgs e)
        {
            string jmeno = n.jmenoVybraneho();
            executeCommand("PosunBod 5 0 " + jmeno);
            //n.posunVybranyBod(5f, 0);
        }

        private void buttonPosunVybranyBodNahoru(object sender, EventArgs e)
        {
            string jmeno = n.jmenoVybraneho();
            executeCommand("PosunBod 0 -5 " + jmeno);
            //n.posunVybranyBod(0, -5f);
        }

        private void buttonPosunVybranyBodDoleva(object sender, EventArgs e)
        {
            string jmeno = n.jmenoVybraneho();
            executeCommand("PosunBod -5 0 " + jmeno);
            //n.posunVybranyBod(-5f, 0);
        }

        private void B_pridejBod_Click(object sender, EventArgs e)
        {
            PridejBod_Form f2 = new PridejBod_Form(n);
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PridejUsecku f2 = new PridejUsecku(n);
            f2.Show();
        }

        private void B_NovaLomenaCara_Click(object sender, EventArgs e)
        {
            PridejLomenouCaruForm f2 = new PridejLomenouCaruForm(n, false);
            f2.Show();
        }

        private void B_oblouk_Click(object sender, EventArgs e)
        {
            PridejObloukForm f2 = new PridejObloukForm(n, false);
            f2.Show();
        }

        private void B_mnohouhelnik_Click(object sender, EventArgs e)
        {
            PridejLomenouCaruForm f2 = new PridejLomenouCaruForm(n, true);
            f2.Show();
        }

        private void B_kruznice_Click(object sender, EventArgs e)
        {
            PridejKruzniciForm f2 = new PridejKruzniciForm(n);
            f2.Show();
        }

        private void CB_zvolenyTvar_SelectedIndexChanged(object sender, EventArgs e)
        {
            n.vyberTvar(CB_zvolenyTvar.SelectedItem.ToString());

            if (CB_zvolenyTvar.SelectedItem.ToString().Length == 0)
            {
                B_OdeberTvar.Enabled = false;
            }
        }

        private void B_OdeberBod_Click(object sender, EventArgs e)
        {
            n.odeberBod(comboBoxBody.SelectedItem.ToString());
            B_OdeberBod.Enabled = false;
            B_posunBodDoleva.Enabled = false;
            B_posunBodDolu.Enabled = false;
            B_posunBodDoprava.Enabled = false;
            B_posunBodNahoru.Enabled = false;
        }

        private void Button_uloz_Click(object sender, EventArgs e)
        {
            if (this.textFile == null) { 
                SaveFileDialog dialog = new SaveFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                
                    this.textFile = Path.GetFullPath(dialog.FileName);
                }
            }
            Console.Write(n.getHistory());
            File.WriteAllLines(textFile, n.getHistory());
            
        }

        private void Button_otevri_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                this.textFile = Path.GetFullPath(dialog.FileName);
                string[] commands = File.ReadAllLines(textFile);
                
                n = new Nakresna(panel1, comboBoxBody, CB_zvolenyTvar, 2);
                foreach (string s in commands)
                    executeCommand(s);
            }
        }

        private void NovaElipsa_Button_Click(object sender, EventArgs e)
        {
            new PridejOhniskovouElipsu(n).Show();
        }

        private void B_pruseciky_Click(object sender, EventArgs e)
        {
            new PrusecikyForm(n).Show();
        }

        private void B_ulozJako_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                this.textFile = Path.GetFullPath(dialog.FileName);
            }
            File.WriteAllLines(textFile, n.getHistory());
        }

        private void B_odeberPruseciky_Click(object sender, EventArgs e)
        {
            new InteraktivniGeometrie.UI.OdeberPrusecikyForm(n).Show();
        }
    }
}
