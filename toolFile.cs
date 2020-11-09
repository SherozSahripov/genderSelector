using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Select_Gender_from_Article.MyClasses
{
    class toolFile
    {

        public toolFile()
        {

        }


        /// <summary>
        /// Bayanlar klasöründe bulunan tüm txt dosyaları bir diziye atan metoddur
        /// </summary>
        /// <returns></returns>
        private static List<string> BayanMetod()
        {
            List<string> BayanListe = new List<string>();
            string[] BayanAdlari = BayanAd();
            StreamReader sr;
            String yol = "SelectGender\\BAYAN", metin = "";
            for (int i = 0; i < BayanAdlari.Length; i++)
            {
                yol += "\\" + BayanAdlari[i];
                for (int k = 0; k < 10; k++) // Buradaki 10 Bir kişinin dosya içindeki makale sayısıdır.
                {
                    // metin = BayanAdlari[i] + " = " + (k+1) + ".txt";
                    yol += "\\" + (k + 1) + ".txt";
                    sr = new StreamReader(yol, Encoding.Default,true);
                    metin += sr.ReadToEnd();
                    BayanListe.Add(metin);
                    yol = "SelectGender\\BAYAN\\" + BayanAdlari[i];
                    metin = "";
                }
                yol = "SelectGender\\BAYAN";
            }
            return BayanListe;
        }


        /// <summary>
        /// Baylar klasöründe bulunan tüm txt dosyaları bir diziye atan metoddur
        /// </summary>
        /// <returns></returns>
        private static List<string> BayMetod()
        {
            List<string> BayListe = new List<string>();
            String[] BayAdlari = BayAd();
            StreamReader sr;
            String yol = "SelectGender\\BAY", metin = "";
            for (int i = 0; i < BayAdlari.Length; i++)
            {
                yol += "\\" + BayAdlari[i];
                for (int k = 0; k < 10; k++)// Buradaki 10: Bir kişinin dosya içindeki makale sayısıdır.
                {
                    yol += "\\" + (k + 1) + ".txt";
                    //metin = BayAdlari[i] + " = " + (k+1);
                    sr = new StreamReader(yol, Encoding.Default, true);
                    metin += sr.ReadToEnd();
                    BayListe.Add(metin);
                    yol = "SelectGender\\BAY\\" + BayAdlari[i];
                    metin = "";
                }
                yol = "SelectGender\\BAY";
            }
            return BayListe;
        }

        


        /// <summary>
        /// Bay klasöründe bulunan kişilerin klasör isimlerinin bir diziye atıyor..
        /// </summary>
        /// <returns></returns>
        private static string[] BayAd()
        {
            String[] BayAdlari;
            String YolBay = @"SelectGender\BAY";

            if (!Directory.Exists(YolBay)) // Dosya varmı diye bakar
            {
                MessageBox.Show("Girilen Yolda Dosya Bulunamadı..");
            }

            string[] directorie_Bay = Directory.GetDirectories(YolBay); //Klasördeki klasörleri getirir
            BayAdlari = new string[directorie_Bay.Length];
            for (int i = 0; i < directorie_Bay.Length; i++)
            {
                BayAdlari[i] = Path.GetFileName(directorie_Bay[i]);
            }
            return BayAdlari;
        }




        /// <summary>
        /// Bayan klasöründe bulunan kişilerin klasör isimlerinin bir diziye atıyor..
        /// </summary>
        /// <returns></returns>
        private static string[] BayanAd()
        {
            String[] BayanAdlari;
            String YolBayan = @"SelectGender\BAYAN";

            if (!Directory.Exists(YolBayan)) // Dosya varmı diye bakar
            {
                MessageBox.Show("Girilen Yolda Dosya Bulunamadı..");
            }

            string[] directorie_Bayan = Directory.GetDirectories(YolBayan); //Klasördeki klasörleri getirir
            BayanAdlari = new string[directorie_Bayan.Length];
            for (int i = 0; i < directorie_Bayan.Length; i++)
            {
                BayanAdlari[i] = Path.GetFileName(directorie_Bayan[i]);
            }
            return BayanAdlari;
        }


        public void DosyayaYaz(float[,] dizi)
        {
            StreamWriter dosya = new StreamWriter(@"C:\Users\Hüseyin\Desktop\SelectGender.txt");
            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                for (int k = 0; k < dizi.GetLength(1); k++)
                {
                    dosya.Write(dizi[i, k].ToString("0.##"));
                    dosya.Write(" ; ");
                }
                dosya.WriteLine("");
            }
            dosya.Close();
        }



        public String[] getBayMakale()
        {
            return BayMetod().ToArray();
        }


        public String[] getBayanMakale()
        {
            return BayanMetod().ToArray();
        }
    }
}
