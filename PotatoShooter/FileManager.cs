using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotatoShooter
{
    public class FileManager
    {
        private static FileManager instance = new FileManager();

        public static FileManager Instance => instance;

        private string cesta = "skore.txt";

        private FileManager() {

        }

        public void UlozSkore(Skore skore) {
            if(!File.Exists(cesta)) {
                File.Create(cesta);
            }

            using (var stream = new StreamWriter(cesta, true)) {
                stream.WriteLine(skore.jmeno + ";" + skore.skore);
                stream.Close();
            }
        }

        public List<Skore> NactiSkore() {
            string all = File.ReadAllText(cesta);
            string[] lines = all.Split("\n");

            List<Skore> skore = new List<Skore>();
            foreach(var line in lines) {
                if (line == "")
                    continue;

                string[] zaznam = line.Split(";");
                skore.Add(new Skore() { 
                    jmeno = zaznam[0], 
                    skore = int.Parse(zaznam[1])
                });
            }

            return skore;
        }
    }
}
