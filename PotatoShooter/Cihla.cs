using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PotatoShooter
{
    public class Cihla {

        public const float SIRKA = 40;
        public const float VYSKA = 10;

        private float pomerVelikosti;

        private Brush barva;

        private int pocetBodu;
        public int PocetBodu { get { return pocetBodu; } }

        private Point pozice;

        private bool znicena = false;

        private float realSirka;
        private float realVyska;

        public static Dictionary<int, Brush> barvy = new Dictionary<int, Brush>() {
            { 1, Brushes.Red },
            { 3, Brushes.Blue },
            { 5, Brushes.Purple }
        };

        public static int GenerujTypCihly(int rand) { // rand: 0 - 100
            if (rand < 70)
                return 1;
            if (rand < 90)
                return 3;
            return 5;
        }

        public Cihla(int pocetBodu, Point pozice, float pomerVelikosti) {
            this.pocetBodu = pocetBodu;
            this.pozice = pozice;
            this.pomerVelikosti = pomerVelikosti;
            this.realSirka = SIRKA * pomerVelikosti;
            this.realVyska = VYSKA * pomerVelikosti;
            this.barva = barvy[pocetBodu];

        }

        public void Vykresli(Graphics g) {
            if(znicena) {
                g.FillRectangle(Brushes.SkyBlue,
                    pozice.X,
                    pozice.Y,
                    realSirka,
                    realVyska
                    );
            } else {
                g.FillRectangle(barva, 
                    pozice.X, 
                    pozice.Y, 
                    realSirka, 
                    realVyska
                    );
                g.DrawRectangle(Pens.DarkGray,
                    pozice.X,
                    pozice.Y,
                    realSirka,
                    realVyska
                    );
            }
        }

        public void ZnicSe() {
            znicena = true;
        }

        public bool ObsahujePozici(Point p) {
            return p.X > pozice.X && p.Y > pozice.Y && p.X < pozice.X + realSirka && p.Y < pozice.Y + realVyska;
        }
    }
}
