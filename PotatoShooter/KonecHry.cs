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
    public partial class KonecHry : Form
    {
        int body;

        public KonecHry() {
            InitializeComponent();
        }

        public void NastavText(int bodu) {
            body = bodu;
            label2.Text = $"Vaše skóre je {bodu} bodů, zadejte jméno pro uložení!";
            ShowVysledky();
        }

        private void button1_Click(object sender, EventArgs e) {
            var jmeno = textBox1.Text;
            if(!string.IsNullOrEmpty(jmeno)) {
                var skore = new Skore() { jmeno = jmeno, skore = body};
                FileManager.Instance.UlozSkore(skore);
                button1.Enabled = false;
            }
            flowLayoutPanel1.Controls.Clear();
            ShowVysledky();
        }
        private void ShowVysledky() {
            var all = FileManager.Instance.NactiSkore();
            all = all.OrderByDescending(x => x.skore).ToList();
            foreach (var sk in all) {
                var label = new Label();
                label.Text = sk.skore + " - " + sk.jmeno;
                flowLayoutPanel1.Controls.Add(label);
            }
        }
    }
}
