﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Tvary
{
    class EliptickyOblouk : Tvar
    {
        static float stredovyUhel(Bod a, Bod b, Bod stred, Vektor osaDoprava, Vektor svislaOsa)
        {
            float ret = stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) *180/(float)Math.PI;
            return ret;

            if (a.projekceNaPrimku(stred, osaDoprava).vzdalenostOd(b.projekceNaPrimku(stred, osaDoprava)) > a.projekceNaPrimku(stred, osaDoprava).vzdalenostOd(stred))//pokud A a B jsou v ruznych polkach elipsy podle svisle osy
            {
                if (a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(b.projekceNaPrimku(stred, svislaOsa)) > a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(stred))//A a B jsou v ruznych pulkach elipsy podle vodorovne osy, tedy v opacnych kvadrantech

                    ret = (stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) * 180 / (float)Math.PI);
                else
                {
                    float uhelAsOsou = stred.vektorNaBod(a).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelAsOsou > 90)
                        uhelAsOsou = 180 - uhelAsOsou;

                    float uhelBsOsou = stred.vektorNaBod(b).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelBsOsou > 90)
                        uhelBsOsou = 180 - uhelBsOsou;
                    return 180 - (uhelAsOsou + uhelBsOsou);
                }
            }
            else {
                if (a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(b.projekceNaPrimku(stred, svislaOsa)) > a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(stred))
                {

                    float uhelAsOsou = stred.vektorNaBod(a).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelAsOsou > 90)
                        uhelAsOsou = 180 - uhelAsOsou;

                    float uhelBsOsou = stred.vektorNaBod(b).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelBsOsou > 90)
                        uhelBsOsou = 180 - uhelBsOsou;
                    return 180 - (uhelAsOsou + uhelBsOsou);
                }
                else
                    ret = stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) * 180 / (float)Math.PI;
            }
            return ret;
        }
        static Bod[] seradPoSmeruHodinSeZacatkemVRight(Bod stred, Bod right, Bod top, Bod z, Bod k, Bod dalsi, Vektor vektorOsyDoprava, Vektor vektorOsyNahoru)
        {
            Bod[] ret = new Bod[3];
            float[] vzdalenosti = new float[3];
            Bod[] body = new Bod[] { z, k, dalsi };
            int i = 0;
            float vzdalenostZ = z.projekceNaPrimku(stred, vektorOsyDoprava).vzdalenostOd(right);
            if (z.projekceNaPrimku(stred, vektorOsyNahoru).vzdalenostOd(top) < stred.vzdalenostOd(top))
                vzdalenostZ = right.vzdalenostOd(stred) * 4 - vzdalenostZ;

            float vzdalenostK = k.projekceNaPrimku(stred, vektorOsyDoprava).vzdalenostOd(right);
            if (k.projekceNaPrimku(stred, vektorOsyNahoru).vzdalenostOd(top) < stred.vzdalenostOd(top))
                vzdalenostK = right.vzdalenostOd(stred) * 4 - vzdalenostK;

            float vzdalenostD = dalsi.projekceNaPrimku(stred, vektorOsyDoprava).vzdalenostOd(right);
            if (dalsi.projekceNaPrimku(stred, vektorOsyNahoru).vzdalenostOd(top) < stred.vzdalenostOd(top))
                vzdalenostD = right
                    .vzdalenostOd(stred) * 4 -vzdalenostD;

            if(vzdalenostK > vzdalenostD && vzdalenostD > vzdalenostZ)
            {
                return new Bod[] { z, dalsi, k };
            }
            if (vzdalenostZ > vzdalenostD && vzdalenostD > vzdalenostK)
                return new Bod[] { k, dalsi, z };
            if (vzdalenostD > vzdalenostK && vzdalenostK > vzdalenostZ)
                return new Bod[] { k, dalsi, z };
            if (vzdalenostD > vzdalenostZ && vzdalenostZ > vzdalenostK)
                return new Bod[] { z, dalsi, k };
            if (vzdalenostD < vzdalenostK && vzdalenostK < vzdalenostZ)
                return new Bod[] { z, dalsi, k };
            if (vzdalenostD < vzdalenostZ && vzdalenostZ < vzdalenostK)
                return new Bod[] { k, dalsi, z };
            return ret;
        }
        
        public static float[] vyresSoustavuRovnic(int zbyvajicichPromennych, float[][] radky)
        {
            if (zbyvajicichPromennych == 1)
            {
                return new float[] { radky[0].Last() / radky[0][0] };
            }
            int i = 0;
            while (radky[i][0] == 0)
            {
                i++;
            }

            for (int iradek = 0; iradek < zbyvajicichPromennych; iradek++)
            {
                if (iradek != i)
                {
                    float pomer = radky[iradek][0] / radky[i][0];
                    for (int isloupec = 0; isloupec < zbyvajicichPromennych + 1; isloupec++)
                    {
                        //float pomer = radky[iradek][isloupec] / radky[i][isloupec];
                        radky[iradek][isloupec] -= radky[i][isloupec] * pomer;
                    }
                }
            }

            float[][] podmatice = new float[zbyvajicichPromennych - 1][];
            for (int j = 0; j < i; j++)
            {
                podmatice[j] = new float[zbyvajicichPromennych];
                Array.ConstrainedCopy(radky[j], 1, podmatice[j], 0, zbyvajicichPromennych);

            }

            for (int j = i + 1; j < zbyvajicichPromennych; j++)
            {
                podmatice[j - 1] = new float[zbyvajicichPromennych];
                Array.ConstrainedCopy(radky[j], 1, podmatice[j - 1], 0, zbyvajicichPromennych);
            }

            float[] hodnoty = vyresSoustavuRovnic(zbyvajicichPromennych - 1, podmatice);

            float[] ret = new float[zbyvajicichPromennych];
            Array.ConstrainedCopy(hodnoty, 0, ret, 1, zbyvajicichPromennych - 1);
            float sum = radky[i].Last();
            for (int j = 1; j < zbyvajicichPromennych; j++)
            {
                sum -= radky[i][j] * hodnoty[j - 1];
            }
            float posledniPromena = sum / radky[i][0];

            ret[0] = posledniPromena;

            return ret;
        }

        private Bod stred;
        private Oblouk oblouk;
        private string name;

        public Bod getStred()
        {
            return this.stred;
        }

        /*public void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n)
        {
            oblouk.vykresliSe(vektorX, vektorY, vektorPosun,n);
        }*/

        public Bod[] klicoveBody()
        {
            throw new NotImplementedException();
        }

        public Cara[] klicoveCary()
        {
            Bod zObraz = z.vektorNaBod(stred).skaluj(2.0F).posun(z);
            Vektor v = k.vektorNaBod(stred).skaluj(2.0F);
            Bod kObraz = v.posun(k);
            Vektor posouvaciVektor = stred.vektorNaBod(new Bod2D(0, 0));

            Bod[] body = new Bod[] { z, k, zObraz, kObraz, dalsi };
            int i = 0;
            float[][] radky = new float[5][];
            foreach (Bod c in body)
            {
                Bod b = posouvaciVektor.posun(c);
                radky[i] = new float[] { b.getSouradnice()[0] * b.getSouradnice()[0], b.getSouradnice()[0] * b.getSouradnice()[1], b.getSouradnice()[1] * b.getSouradnice()[1], b.getSouradnice()[0], b.getSouradnice()[1], 1 };
                i++;

            }

            float[] normalizovanaRovnice = vyresSoustavuRovnic(5, radky); //pro kazdy bod elipsy (x,y) plati: nr.1*x^2 + nr.2*y^2 + nr.3*x*y + nr.4*x+nr.5*y = 1
                                                                          //nr2yy + nr3xy + nr5y = 1 - nr1xx - nr4x
                                                                          //nr2yy + (nr3x + nr5) + (nr1xx + nr4x -1) = 0
                                                                          //D = (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1)
                                                                          //y = [(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2 = 
                                                                          //vzdalenost(stred, (x,y)) ~ (stred.1 - x)^2 + (stred.2 - y)^2
                                                                          // vzdalenost(stred, (x, y)) ~(stred.1^2 - 2x*stred.1 + x^2) + (stred.2^2 - 2y*stred.2 + y^2)
                                                                          // vzdalenost(stred, (x,y)) ~ (stred.1^2 - 2x*stred.1 + x^2) + stred.2^2 - 2*stred.2*([(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2) + ([(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2)^2
                                                                          //vzdalenost(stred, (x,y))' = 2*stred.1 + 2x + - (2*stred.2*(nr3x+nr5)^2)' - 2*stred.2*sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2)'

            float uhelRotace = (float)Math.Atan((double)normalizovanaRovnice[1] / (normalizovanaRovnice[0] - normalizovanaRovnice[2])) / 2;

            Vektor vektorOsy = kolmySmer.otoceny(stred.vektorNaBod(dalsi), uhelRotace);
            Vektor vektorVodorovneOsy = stred.vektorNaBod(dalsi).nakolmiK(vektorOsy);
            Bod right = posouvaciVektor.skaluj(-1).posun(vektorOsy.prusecikSElipsou(posouvaciVektor.posun(stred), normalizovanaRovnice)); //az sem to funguje dobre

            Bod top = posouvaciVektor.skaluj(-1).posun(stred.vektorNaBod(dalsi).nakolmiK(vektorOsy).prusecikSElipsou(posouvaciVektor.posun(stred), normalizovanaRovnice));

            top = top.vektorNaBod(stred).skaluj(2).posun(top);
            Bod[] poporade = seradPoSmeruHodinSeZacatkemVRight(stred, right, top, z, k, dalsi, stred.vektorNaBod(right), stred.vektorNaBod(top));


            float startAngle = stredovyUhel(right, poporade[0], stred, vektorOsy, stred.vektorNaBod(dalsi).nakolmiK(vektorOsy));
            float vzdalenostZacatkuodTop = poporade[0].projekceNaPrimku(stred, stred.vektorNaBod(top)).vzdalenostOd(top);
            float delkaSvisleOsy = stred.vzdalenostOd(top);
            if (poporade[0].projekceNaPrimku(stred, stred.vektorNaBod(top)).vzdalenostOd(top) < stred.vzdalenostOd(top))
            {
                startAngle = 360 - startAngle;
            }

            float sweepAngle = stredovyUhel(z, k, stred, vektorOsy, vektorVodorovneOsy);
            float soucetUhlu = stredovyUhel(z, dalsi, stred, vektorOsy, vektorVodorovneOsy);
            float bdalsiUhel = stredovyUhel(k, dalsi, stred, vektorOsy, vektorVodorovneOsy);
            soucetUhlu += bdalsiUhel;
            if (sweepAngle < soucetUhlu-0.1F)
                sweepAngle = 360 - sweepAngle;

            if (this.uplny)
                sweepAngle = 360;
            Oblouk o = new Oblouk(top, right, stred, startAngle, sweepAngle, normalizovanaRovnice);
            //this.stred = stred;
            this.oblouk = o;
            return new Cara[] { oblouk };
        }

        public string getName()
        {
            return this.name;
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            return this.stred.getSouradnice();
        }

        private Bod dalsi, z, k;
        private Vektor kolmySmer;
        private double sweepAngle;
        private Vektor2D vektor2D;
        private string jmeno;
        private bool uplny;

        public EliptickyOblouk(Bod stred, Bod dalsi, Bod z, Bod k, Vektor kolmySmer, bool uplny, string jmeno) : this(stred,dalsi,z,k,kolmySmer,jmeno)
        {
            this.uplny = uplny;
        }
        public EliptickyOblouk(Bod stred, Bod dalsi, Bod z, Bod k, Vektor kolmySmer, string jmeno)
        {
            this.uplny = false;
            this.name = jmeno;
            if (z.stredUsecky(k).jeStejnyJako(stred) || z.stredUsecky(dalsi).jeStejnyJako(stred) || k.stredUsecky(dalsi).jeStejnyJako(stred))
            {
                
            }
            
            this.z = z;
            this.k = k;
            this.dalsi = dalsi;
            this.kolmySmer = kolmySmer;
            this.stred = stred;

            /*Bod zObraz =z.vektorNaBod(stred).skaluj(2.0F).posun(z);
            Vektor v = k.vektorNaBod(stred).skaluj(2.0F);
            Bod kObraz = v.posun(k);
            Vektor posouvaciVektor = stred.vektorNaBod(new Bod2D(0, 0));

            Bod[] body = new Bod[] { z, k, zObraz, kObraz, dalsi };
            int i = 0;
            float[][] radky = new float[5][];
            foreach(Bod c in body)
            {
                Bod b = posouvaciVektor.posun(c);
                radky[i] = new float[] { b.getSouradnice()[0] * b.getSouradnice()[0], b.getSouradnice()[0] * b.getSouradnice()[1], b.getSouradnice()[1] * b.getSouradnice()[1],  b.getSouradnice()[0], b.getSouradnice()[1], 1 };
                i++;

            }

            float[] normalizovanaRovnice = vyresSoustavuRovnic(5, radky); //pro kazdy bod elipsy (x,y) plati: nr.1*x^2 + nr.2*y^2 + nr.3*x*y + nr.4*x+nr.5*y = 1
                                                                          //nr2yy + nr3xy + nr5y = 1 - nr1xx - nr4x
                                                                          //nr2yy + (nr3x + nr5) + (nr1xx + nr4x -1) = 0
                                                                          //D = (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1)
                                                                          //y = [(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2 = 
                                                                          //vzdalenost(stred, (x,y)) ~ (stred.1 - x)^2 + (stred.2 - y)^2
                                                                          // vzdalenost(stred, (x, y)) ~(stred.1^2 - 2x*stred.1 + x^2) + (stred.2^2 - 2y*stred.2 + y^2)
                                                                          // vzdalenost(stred, (x,y)) ~ (stred.1^2 - 2x*stred.1 + x^2) + stred.2^2 - 2*stred.2*([(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2) + ([(nr3x+nr5)^2 + sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2)^2
                                                                          //vzdalenost(stred, (x,y))' = 2*stred.1 + 2x + - (2*stred.2*(nr3x+nr5)^2)' - 2*stred.2*sqrt(  (nr3x+nr5)^2 - 4nr2(nr1xx+nr4x-1) )]/2nr2)'

            float uhelRotace =(float) Math.Atan((double) normalizovanaRovnice[1] / (normalizovanaRovnice[0] - normalizovanaRovnice[2]))/2;

            Vektor vektorOsy = kolmySmer.otoceny(stred.vektorNaBod(dalsi), uhelRotace);
            Vektor vektorVodorovneOsy = stred.vektorNaBod(dalsi).nakolmiK(vektorOsy);
            Bod right = posouvaciVektor.skaluj(-1).posun(vektorOsy.prusecikSElipsou(posouvaciVektor.posun(stred), normalizovanaRovnice)); //az sem to funguje dobre

            Bod top = posouvaciVektor.skaluj(-1).posun(stred.vektorNaBod(dalsi).nakolmiK(vektorOsy).prusecikSElipsou(posouvaciVektor.posun(stred), normalizovanaRovnice));

            Bod[] poporade = seradPoSmeruHodinSeZacatkemVRight(stred, right, top, z, k, dalsi, stred.vektorNaBod(right), stred.vektorNaBod(top));
            

            float startAngle = stredovyUhel(right, poporade[2], stred, vektorOsy, stred.vektorNaBod(dalsi).nakolmiK(vektorOsy));
            if(poporade[2].projekceNaPrimku(stred,vektorOsy).vzdalenostOd(top) < stred.vzdalenostOd(top))
            {
                startAngle = 360 - startAngle;
            }
            
            float sweepAngle = stredovyUhel(z, k, stred, vektorOsy, vektorVodorovneOsy);
           
            if(sweepAngle< stredovyUhel(z,dalsi,stred,vektorOsy,vektorVodorovneOsy) + stredovyUhel(k,dalsi,stred,vektorOsy, vektorVodorovneOsy))
                sweepAngle = 360 - sweepAngle;
           
            Oblouk o = new Oblouk(top, right, stred, startAngle, sweepAngle);
            this.stred = stred;
            this.oblouk = o;*/
            

            

        }

        public EliptickyOblouk(Bod hlavniBodA, Bod hlavniBodB, Bod dalsi)
        {
            
        }

       

        
    }
}
