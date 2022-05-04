﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    /*
     Úsečka nebo lomená čára, definována body v poli body v takovém pořadí, v jakém jsou v poli zadány
         */
    public class PrimaCara : Tvar//, Cara
    {
        private string name;
        private Bod[] body;
        private bool nameVisible;

        public PrimaCara(string name, params Bod[] body)
        {
            this.body = body;
            this.name = name;
            this.nameVisible = true;
            Console.WriteLine(this.name);
        }
        
        

        public PrimaCara(Bod a, Bod b)
        {
            this.body = new Bod[] { a, b };
        }

        public string getName()
        {
            //nsole.WriteLine("jmeno (uvnitr getname): " + this.name);
            return this.name;
        }

        public Bod[] klicoveBody()
        {
            return this.body;
        }

        public Cara[] klicoveCary()
        {
            Usecka[] ret = new Usecka[body.Length - 1];
            
            for (int i=0; i<body.Length-1; i++)
            {
                ret[i] = new Usecka(body[i], body[i + 1]);
                
            }
            return ret;
        }

        public void vykresliSe(Vektor vektorX, Vektor vektorY, Nakresna n, out float[] poziceJmena)
        {
            poziceJmena = new float[] { this.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[0] + this.klicoveBody()[this.klicoveBody().Length - 1].projekceDo2D(vektorX,vektorY)[0], this.klicoveBody()[0].projekceDo2D(vektorX,vektorY)[1] + this.klicoveBody()[this.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[1]+5 };
            for (int i = 0; i< this.klicoveBody().Length-1; i++)
            {
                n.nakresliUsecku(new Usecka(this.klicoveBody()[i], this.klicoveBody()[i + 1]));
            }
            Console.WriteLine(poziceJmena[0]);
            Console.WriteLine(poziceJmena[1]);
            Console.WriteLine(this.getName());
            n.getG().DrawString(this.getName(), SystemFonts.DefaultFont, Brushes.Black, poziceJmena[0], poziceJmena[1]);
        }

        public void vykresliSe(float[] vektorX, float[] vektorY, Nakresna n)
        {
            for (int i = 0; i < this.klicoveBody().Length - 1; i++)
            {
                n.nakresliUsecku(new Usecka(this.klicoveBody()[i], this.klicoveBody()[i + 1]));
            }
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            float[] poziceJmenaR = new float[] { this.klicoveBody()[0].projekceDo2D(vektorX,vektorY)[0] + this.klicoveBody()[this.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[0], this.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[1] + this.klicoveBody()[this.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[1] + 5 };
            return poziceJmenaR;
        }
    }
}
