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
    public partial class Form1 : Form
    {
        static List<Command> allCommands;
        static Nakresna n;
        public Form1()
        {
            
            InitializeComponent();
            n = new Nakresna(panel1, 2);
            allCommands = new List<Command>();
            allCommands.Add(new PridejBodCommand());
            allCommands.Add(new NakresliCaruCommand());
            allCommands.Add(new PridejMnohouhelnikCommand());
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
            n.otoc(-0.1);
            n.VykresliSe();
        }

        private void buttonTurnRight_Click(object sender, EventArgs e)
        {
            n.otoc(0.1);
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
                string[] vstup = textBox1.Text.Split(' ');
                string commandName = vstup[0];
                string[] args = new string[vstup.Length - 1];
                Array.ConstrainedCopy(vstup, 1, args, 0, args.Length);
                foreach(Command c in allCommands)
                {
                    if (c.getName().Equals(commandName))
                        c.exec(args, n);
                }
                n.VykresliSe();
            }
        }
    }
}
