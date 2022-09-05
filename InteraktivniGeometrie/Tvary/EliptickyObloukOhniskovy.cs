using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Tvary
{
    class EliptickyObloukOhniskovy : Tvar
    {
        private static bool obsahujeDuplicitni(Bod[] body)
        {
            for(int i = 0; i < body.Length - 1; i++)
            {
                if (body[i].jeStejnyJako(body[body.Length - 1]))
                    return true;
            }
            return false;
        }

        public string getCommand()
        {
            return "PridejEliptickyOblouk " + ohnisko2 + " " + ohnisko2 + " " + dalsi + " " + this.getName();
        }
        private static Bod zvolNovyBod(Bod ohnisko1, Bod ohnisko2, float ohniskovaVzdalenost, Vektor kolmySmer)
        {
            float a = ohniskovaVzdalenost - ohnisko1.vzdalenostOd(ohnisko2);

            float x = a - a * a / 2 / ohniskovaVzdalenost;

            Vektor smerPosunuti = kolmySmer.nakolmiK(ohnisko1.vektorNaBod(ohnisko2));
            smerPosunuti = smerPosunuti.skaluj(x / smerPosunuti.getDelka());

            return smerPosunuti.posun(ohnisko2);
        }
        private string name;
        private Bod ohnisko1, ohnisko2, dalsi;
        private float sweepAngle;
        private Vektor kolmySmer;

        public EliptickyObloukOhniskovy(Bod ohnisko1, Bod ohnisko2, Bod dalsi, float sweepAngle, Vektor kolmySmer, string jmeno)
        {
            this.ohnisko2 = ohnisko2;
            this.ohnisko1 = ohnisko1;
            this.dalsi = dalsi;
            this.name = jmeno;
            this.sweepAngle = sweepAngle;
            this.kolmySmer = kolmySmer;
        }
        public string getName()
        {
            return name;
        }

        public Bod[] klicoveBody()
        {
            return new Bod[] { ohnisko1, ohnisko2,dalsi };
        }

        public Cara[] klicoveCary()
        {


            Bod stred = ohnisko1.vektorNaBod(ohnisko2).skaluj(0.5F).posun(ohnisko1);

            Vektor kvektor = stred.vektorNaBod(dalsi).otoceny(kolmySmer, (float)sweepAngle);
            //hb11
            Vektor hlavniOsa = ohnisko1.vektorNaBod(ohnisko2);
            if (hlavniOsa.getSouradnice()[0] < 0)
            {
                hlavniOsa = hlavniOsa.skaluj(-1);
            }
            Bod hlavniBod1 = hlavniOsa.skaluj((ohnisko2.vzdalenostOd(dalsi) + ohnisko1.vzdalenostOd(dalsi)) / (2 * hlavniOsa.getDelka())).posun(stred);
            //sqrt( (z1 - s1)^2 + (z2-s2)^2 
            Vektor vedlejsiOsa = kolmySmer.nakolmiK(hlavniOsa);
                if (vedlejsiOsa.getSouradnice()[1] < 0)
                {
                    vedlejsiOsa = vedlejsiOsa.skaluj(-1);
                }
            vedlejsiOsa = vedlejsiOsa.skaluj(1 / vedlejsiOsa.getDelka());
            //(ohniskovavzdalenost/2)^2 = (vzdalenost ohnisek/2)^2 + vedlejsi^2
            double R = ohnisko1.vzdalenostOd(dalsi) + ohnisko2.vzdalenostOd(dalsi);

            double vyska = Math.Sqrt(R * R / 4 - ohnisko1.vzdalenostOd(ohnisko2) * ohnisko1.vzdalenostOd(ohnisko2) / 4);
            Bod hlavniBod2 = vedlejsiOsa.skaluj((float)vyska).posun(stred);

            Bod[] body = new Bod[] { hlavniBod1, hlavniBod2, new Vektor2D(hlavniBod1,stred).skaluj(2).posun(hlavniBod1), new Vektor2D(hlavniBod2, stred).skaluj(2).posun(hlavniBod2), dalsi };
            int i = 0;
            float[][] radky = new float[5][];
            if (obsahujeDuplicitni(body))
            {
                body[4] = zvolNovyBod(ohnisko1, ohnisko2, (float) R, kolmySmer);
            }
            foreach (Bod c in body)
            {
                Bod b = c;
                radky[i] = new float[] { b.getSouradnice()[0] * b.getSouradnice()[0], b.getSouradnice()[0] * b.getSouradnice()[1], b.getSouradnice()[1] * b.getSouradnice()[1], b.getSouradnice()[0], b.getSouradnice()[1], 1 };
                i++;

            }

            float[] normalizovanaRovnice = EliptickyOblouk.vyresSoustavuRovnic(5, radky);

            return new EliptickyOblouk(stred, body[0], body[1], body[4], kolmySmer, true, "").klicoveCary();
            //return new Cara[] { new Oblouk(hlavniBod2, hlavniBod1, stred, stred.vektorNaBod(dalsi).getUhel(hlavniOsa), sweepAngle, normalizovanaRovnice) };
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            Bod stred = ohnisko1.vektorNaBod(ohnisko2).skaluj(0.5F).posun(ohnisko1);
            return stred.getSouradnice();
        }
    }
}
