using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotatoShooter
{
    public partial class Game : Form
    {
        List<Cihla> cihly = new List<Cihla>();
        Terc terc;
        int pocetStrel = 3;
        int PocetStrel {
            get { return pocetStrel; }
            set { pocetStrel = value; label1.Text = "Zbývá střel: " + pocetStrel; }
        }
        int pocetBodu = 0;
        int PocetBodu {
            get { return pocetBodu; }
            set { pocetBodu = value; label2.Text = "Počet bodů: " + pocetBodu; }
        }
        int rady = 9;
        int offset = 30;
        int cihelVRade = 0;
        float pomerVelikosti = 4;

        public Game() {
            InitializeComponent();

            int pouzitelnaSirka = platno1.Width - 2 * offset;
            float sirkaCihly = Cihla.SIRKA * pomerVelikosti;
            cihelVRade = (int)(pouzitelnaSirka / sirkaCihly);
            int zbytek = (int)(pouzitelnaSirka - (sirkaCihly * cihelVRade));
            offset += zbytek / 2;
            
            VytvorCihly();
            terc = new Terc(1, 40, new Point(platno1.Width/2, platno1.Height/2));
            targetTimer.Start();
        }

        private void VytvorCihly() {

            Random r = new Random();

            for(int i = 0; i < rady; i++) {
                
                bool sudy = i % 2 == 0;

                for(int j = 0; j < cihelVRade + (sudy ? 0 : -1); j++) {
                    cihly.Add(new Cihla(
                        Cihla.GenerujTypCihly(r.Next(0,100)),
                        new Point(
                            
                            (int)((sudy ? 0 : (Cihla.SIRKA * pomerVelikosti / 2)) + offset + j * (Cihla.SIRKA * pomerVelikosti)),
                            
                            (int)(offset + i * (Cihla.VYSKA * pomerVelikosti))
                            ),
                        pomerVelikosti
                        ));
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e) {
            terc.HniSe();
            platno1.Refresh();
        }

        private void platno1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            cihly.ForEach(cihla => cihla.Vykresli(e.Graphics));
            terc.VykresliSe(e.Graphics);
        }

        private void targetTimer_Tick(object sender, EventArgs e) {
            Random r = new Random();
            terc.ZmenCilovouPozici(
                new Point(r.Next(0, platno1.Width), r.Next(0, platno1.Height)),
                (float)updateTimer.Interval / targetTimer.Interval);
        }

        private void platno1_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Space) {
                if(pocetStrel > 0)
                    Shoot();
            }
        }

        private void Shoot() {
            PocetStrel--;
            var trefena = cihly.FirstOrDefault(cihla => cihla.ObsahujePozici(terc.Pozice));
            trefena.ZnicSe();
            PocetBodu += trefena.PocetBodu;
        }
    }
}
