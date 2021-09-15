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

        int rady = 5;
        int offset = 30;
        int cihelVRade = 0;
        float pomerVelikosti = 4;

        public Game() {
            InitializeComponent();

            int pouzitelnaSirka = panel1.Width - 2 * offset;
            float sirkaCihly = Cihla.SIRKA * pomerVelikosti;
            cihelVRade = (int)(pouzitelnaSirka / sirkaCihly);
            int zbytek = (int)(pouzitelnaSirka - (sirkaCihly * cihelVRade));
            offset += zbytek / 2;

            VytvorCihly();
        }

        private void VytvorCihly() {
            for(int i = 0; i < rady; i++) {
                
                bool sudy = i % 2 == 0;

                for(int j = 0; j < cihelVRade + (sudy ? 0 : -1); j++) {
                    cihly.Add(new Cihla(
                        1,
                        new Point(
                            
                            (int)((sudy ? 0 : (Cihla.SIRKA * pomerVelikosti / 2)) + offset + j * (Cihla.SIRKA * pomerVelikosti)),
                            
                            (int)(offset + i * (Cihla.VYSKA * pomerVelikosti))
                            ),
                        pomerVelikosti
                        ));
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

            cihly.ForEach(cihla => cihla.Vykresli(e.Graphics));

        }
    }
}
