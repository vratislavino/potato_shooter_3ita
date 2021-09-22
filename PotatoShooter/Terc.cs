using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PotatoShooter
{
    public class Terc
    {
        private float rychlost;
        private int velikost;
        private Point pozice;

        private float realX;
        private float realY;

        private float deltaX;
        private float deltaY;

        public Point Pozice => pozice;
        //public Point Pozice { get { return pozice; } }
        
        private Pen barva;
        private Point cilovaPozice;
        bool test = false;

        public Terc(float rychlost, int velikost, Point pozice) {
            this.rychlost = rychlost;
            this.velikost = velikost;
            this.pozice = pozice;
            this.realX = pozice.X;
            this.realY = pozice.Y;
            this.barva = new Pen(Color.White, 3);
        }

        public void HniSe() {
            realX += deltaX;
            realY += deltaY;
            pozice = new Point((int)realX, (int)realY);
        }

        public void VykresliSe(Graphics g) {
            g.DrawLine(barva, pozice.X - velikost / 2, pozice.Y, pozice.X + velikost / 2, pozice.Y);
            g.DrawLine(barva, pozice.X, pozice.Y - velikost / 2, pozice.X, pozice.Y + velikost / 2);

            int velikostKruznice = velikost * 3 / 8;
            g.DrawEllipse(barva, 
                pozice.X - velikostKruznice, 
                pozice.Y - velikostKruznice, 
                velikostKruznice * 2, 
                velikostKruznice * 2);
        }

        public void ZmenCilovouPozici(Point point, float deltaTime) {
            test = true;
            cilovaPozice = point;
            System.Diagnostics.Debug.WriteLine(cilovaPozice);

            SpocitejDelty(deltaTime);
        }

        private void SpocitejDelty(float deltaTime) {
            float x = cilovaPozice.X - pozice.X;
            float y = cilovaPozice.Y - pozice.Y;

            deltaX = x * deltaTime;
            deltaY = y * deltaTime;
        }
    }
}
