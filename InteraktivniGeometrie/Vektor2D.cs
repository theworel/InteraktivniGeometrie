using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Vektor2D : Vektor
    {
        public Vektor2D(Bod pocatek, Bod konec)
        {
            this.v1 = konec.getSouradnice()[0] - pocatek.getSouradnice()[0];
            this.v2 = konec.getSouradnice()[1] - pocatek.getSouradnice()[1];
        }

        public Vektor2D(float v1, float v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        private float v1, v2;
        public float getDelka()
        {
            return (float)Math.Sqrt(v1 * v1 + v2 * v2);
        }

        public Bod posun(Bod posouvany)
        {
            return new Bod2D(posouvany.getSouradnice()[0] + this.v1, posouvany.getSouradnice()[1]+ this.v2, "");
        }

        public Vektor pricti(Vektor druhy)
        {
            return new Vektor2D(v1 + druhy.getSouradnice()[0], v2 + druhy.getSouradnice()[1]);
        }

        public Vektor odecti(Vektor druhy)
        {
            return new Vektor2D(v1 - druhy.getSouradnice()[0], v2 - druhy.getSouradnice()[1]);
        }

        public Vektor skaluj(float alpha)
        {
            return new Vektor2D(this.v1 * alpha, this.v2 * alpha);
        }

        public Vektor projekceNa(Vektor druhy)
        {
            return druhy.skaluj(this.skalarniSoucin(druhy) / druhy.skalarniSoucin(druhy));
        }

        public Vektor nakolmiK(Vektor druhy)
        {
            return this.odecti(this.projekceNa(druhy));
        }

        public float skalarniSoucin(Vektor druhy)
        {
            return (v1*druhy.getSouradnice()[0] + v2*druhy.getSouradnice()[1]);
        }

        public float[] getSouradnice()
        {
           return new float[] { v1, v2 };
        }

        public Bod2D prusecikS(Vektor druhy, Bod2D pocatek1, Bod2D pocatek2)
        {
            /*soustava rovnic
             pocatek1.1 + v1*a = pocatek2.1 +druhy.1*b
             pocatek1.2 + v2*a = pocatek2.2 + druhy.2*b

            p1.1-p2.1 = v1*a + u1*b
            p1.2-p2.2 = v2*a + u2*b
             
             */

            float[] prvniRadek = new float[] { v1, druhy.getSouradnice()[0], pocatek1.getSouradnice()[0] - pocatek2.getSouradnice()[0] };
            float[] druhyRadek = new float[] { v2, druhy.getSouradnice()[1], pocatek1.getSouradnice()[1] - pocatek2.getSouradnice()[1] };

            for (int i = 0; i < 3; i++)
                Console.Write(prvniRadek[i] + " ");
            Console.WriteLine("prvni radek");

            for (int i = 0; i < 3; i++)
                Console.Write(druhyRadek[i] + " ");
            Console.WriteLine("druhy radek");

            float pomer = v2 / v1;
            for(int i=0; i<3; i++)
                druhyRadek[i] = druhyRadek[i] - pomer * prvniRadek[i];
            float b = druhyRadek[2] / druhyRadek[1];

            float a = (prvniRadek[2] - b * prvniRadek[1]) / prvniRadek[0];

            return (Bod2D) druhy.skaluj(b).posun(pocatek2);

        }

        public Bod prusecikS(Vektor druhy, Bod pocatek1, Bod pocatek2)
        {

            float[] prvniRadek = new float[] { v1, druhy.getSouradnice()[0], pocatek1.getSouradnice()[0] - pocatek2.getSouradnice()[0] };
            float[] druhyRadek = new float[] { v2, druhy.getSouradnice()[1], pocatek1.getSouradnice()[1] - pocatek2.getSouradnice()[1] };

            float pomer = v2 / v1;
            for (int i = 0; i < 3; i++)
                druhyRadek[i] = druhyRadek[i] - pomer * prvniRadek[i];
            float b = druhyRadek[2] / druhyRadek[1];

            float a = (prvniRadek[2] - b * prvniRadek[1]) / prvniRadek[0];

            return (Bod2D)druhy.skaluj(b).posun(pocatek2);
        }

        public float getUhel(Vektor druhy)
        {
            return (float) Math.Acos((double) (skalarniSoucin(druhy) / this.getDelka() / druhy.getDelka()));
        }

        public void otoc(Vektor druhyVektor, float uhel)//druhyVektor spolecne s otacenym vektorem definuji rovinu, ve které vektor otacime, pro 2D geometrii neni potreba
        {
            float newv1 = (float)( this.v1 * Math.Cos(uhel) - this.v2 * Math.Sin(uhel));
            float newv2 = (float)(this.v1 * Math.Sin(uhel) + this.v2 * Math.Cos(uhel));

            this.v1 = newv1;
            this.v2 = newv2;
        }

        public Vektor otoceny(Vektor druhyVektor, float uhel)
        {
            float newv1 = (float)(this.v1 * Math.Cos(uhel) - this.v2 * Math.Sin(uhel));
            float newv2 = (float)(this.v1 * Math.Sin(uhel) + this.v2 * Math.Cos(uhel));

            return new Vektor2D(newv1, newv2);
        }

        public Bod prusecikSElipsou(Bod pocatek , float[] rovnice)
        {
            //pro kazdy bod elipsy (x,y) plati: nr.1*x^2 + nr.2*x*y  + nr.3*y^2 + nr.4*x+nr.5*y = 1
            //x=p1+v1*s
            //y=p2+v2*s
            //nr.1*(p1^2+2s*p1v1+s^2v1^2) + nr.2*(p2^2+2s*p2v2+s^2v2^2) + nr.3*(p1p2 + s*p1v2 + s*p2v1 + s^2*v1v2) + nr.4*(p1+v1*s)+nr.5*(p2+v2*s) = 1
            //s^2(v1^2*nr.1 + v2^2*nr2 + nr3*v1v2) + s(2p1v1*nr1 + 2p2v2*nr2 + nr3*p1v2 + nr3*p2v1 + nr4v1 + nr5v2) + nr1p1^2 + nr2*p2^2 + nr3*p1p2 + nr4p1 + nr5p2 - 1 = 0

            float kvadratickyClen = v1 * v1 * rovnice[0] + v2 * v2 * rovnice[2] + v1 * v2 * rovnice[1];
            float linearniClen = 2*pocatek.getSouradnice()[0]*v1*rovnice[0] + 2*pocatek.getSouradnice()[1]*v2*rovnice[2] + rovnice[1]*(pocatek.getSouradnice()[0]*v2 + pocatek.getSouradnice()[1]*v1) + rovnice[3]*v1 +  rovnice[4]*v2;
            //2*0 + 2*0 + 
            float konstantniClen = rovnice[0] * pocatek.getSouradnice()[0] * pocatek.getSouradnice()[0] + rovnice[2] * pocatek.getSouradnice()[1] * pocatek.getSouradnice()[1] + rovnice[1] * pocatek.getSouradnice()[1] * pocatek.getSouradnice()[0] + rovnice[3] * pocatek.getSouradnice()[0] + rovnice[4] * pocatek.getSouradnice()[1]-1;

            float s = (-linearniClen + (float)Math.Sqrt(linearniClen * linearniClen - 4 * kvadratickyClen * konstantniClen)) / 2 / kvadratickyClen;
            return this.skaluj(s).posun(pocatek);

            
        }

        public Bod[] prusecikySElipsou(Bod pocatek, float[] rovnice)
        {
            float kvadratickyClen = v1 * v1 * rovnice[0] + v2 * v2 * rovnice[2] + v1 * v2 * rovnice[1];
            float linearniClen = 2 * pocatek.getSouradnice()[0] * v1 * rovnice[0] + 2 * pocatek.getSouradnice()[1] * v2 * rovnice[2] + rovnice[1] * (pocatek.getSouradnice()[0] * v2 + pocatek.getSouradnice()[1] * v1) + rovnice[3] * v1 + rovnice[4] * v2;
            //2*0 + 2*0 + 
            float konstantniClen = rovnice[0] * pocatek.getSouradnice()[0] * pocatek.getSouradnice()[0] + rovnice[2] * pocatek.getSouradnice()[1] * pocatek.getSouradnice()[1] + rovnice[1] * pocatek.getSouradnice()[1] * pocatek.getSouradnice()[0] + rovnice[3] * pocatek.getSouradnice()[0] + rovnice[4] * pocatek.getSouradnice()[1] - 1;

            float s = (-linearniClen + (float)Math.Sqrt(linearniClen * linearniClen - 4 * kvadratickyClen * konstantniClen)) / 2 / kvadratickyClen;
            float s2 = (-linearniClen - (float)Math.Sqrt(linearniClen * linearniClen - 4 * kvadratickyClen * konstantniClen)) / 2 / kvadratickyClen;
            return new Bod[] { this.skaluj(s).posun(pocatek), this.skaluj(s2).posun(pocatek) };
        }
    }
}
