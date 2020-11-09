using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Select_Gender_from_Article.MyClasses
{
    public class main
    {
        private int makaleAdet = 5;
        private int m_q = 5;
        private String gelen_Metin;
        private String str_Cinsiyet;


        private float[,] matris; // new float[toolFile.MakaleSayisi(), 257];

        public main(String str)
        {
            gelen_Metin = str;

            CreateMatrix();
            Min_Max_Normalizasyon();
            methodResult2(GettingDistance());
        }

        private void CreateMatrix()
        {
            toolFile obj = new toolFile();
            List<String> listBay = obj.getBayMakale().ToList();
            List<String> listBayan = obj.getBayanMakale().ToList();
            matris = new float[listBay.Count + listBayan.Count + 1, 257];

            int count = 0;

            for (int i = 0; i < listBay.Count; i++)
            {
                int[] dizi = new toolText(listBay[i]).getList();
                for (int k = 0; k < dizi.Length; k++)
                {
                    matris[count, k] = dizi[k];
                }
                matris[count, 256] = 1;
                count++;
            }
            MessageBox.Show("Baylar Matris'e Yazıldı.");
            

            for (int i = 0; i < listBayan.Count; i++)
            {
                int[] dizi = new toolText(listBayan[i]).getList();
                for (int k = 0; k < dizi.Length; k++)
                {
                    matris[count, k] = dizi[k];
                }
                matris[count, 256] = 0;

                count++;
            }
            MessageBox.Show("Bayanlar Matris'e Yazıldı.");

            int[] yeniDizi = new toolText(gelen_Metin).getList();
            for (int i = 0; i < yeniDizi.Length; i++)
            {
                matris[count, i] = yeniDizi[i];
            }

            //new toolFile().DosyayaYaz(matris);
        }

        private void Min_Max_Normalizasyon()
        {
            for (int i = 0; i < matris.GetLength(1); i++)
            {
                List<float> gecici = new List<float>();
                for (int k = 0; k < matris.GetLength(0); k++)
                {
                    gecici.Add(matris[k,i]);
                }

                gecici = new Min_Max(gecici).GetList();

                for (int k = 0; k < matris.GetLength(0); k++)
                {
                    matris[k, i] = gecici[k];
                }
            }

            //new toolFile().DosyayaYaz(matris);
        }

        private Dictionary<int, double> GettingDistance()
        {
            double result = 0;
            Dictionary<int, double> dictionary = new Dictionary<int, double>();
            Dictionary<int, double> dictionary2 = new Dictionary<int, double>();
            List<int> listeNum = new List<int>();
            List<float> listGelen = new List<float>();

            for (int i = 0; i < matris.GetLength(1)-1; i++)
            {
                listGelen.Add(matris[matris.GetLength(0)-1,i]);
            }


            //with minkowski
            for (int i = 0; i < matris.GetLength(0) - 1; i++)
            {
                for (int k = 0; k < matris.GetLength(1) - 1; k++)
                {
                    result += Math.Pow(Math.Abs(matris[i, k] - listGelen[k]), m_q);
                }
                result = Math.Pow(result, 1.0 / m_q);
                dictionary.Add(i, result);
                result = 0;
            }



            //with öklit
            //for (int i = 0; i < matris.GetLength(0) - 1; i++)
            //{
            //    for (int k = 0; k < matris.GetLength(1) - 1; k++)
            //    {
            //        result += Math.Pow(Math.Abs(matris[i, k] - listGelen[k]), 2.0);
            //    }
            //    result = Math.Sqrt(result);
            //    dictionary.Add(i, result);
            //    result = 0;
            //}



            var items = from pair in dictionary
                        orderby pair.Value ascending
                        select pair;
            

            foreach(KeyValuePair<int, double> pair in items)
            {
                dictionary2.Add(pair.Key, pair.Value);
                listeNum.Add(pair.Key);
            }

            //return listeNum;
            return dictionary2;

        }

        //private void methodResult(List<int> list)
        //{
        //    int bayAdet = 0;
        //    int bayanAdet = 0;
        //    for (int i = 0; i < makaleAdet; i++)
        //    {
        //        if (matris[list[i],matris.GetLength(1) - 1] == 1)
        //        {
        //            bayAdet++;
        //        }

        //        else if (matris[list[i], matris.GetLength(1) - 1] == 0)
        //        {
        //            bayanAdet++;
        //        }
        //    }

        //    if (bayAdet > bayanAdet)
        //    {
        //        str_Cinsiyet = "BAY";
        //    }
        //    if (bayanAdet > bayAdet)
        //    {
        //        str_Cinsiyet = "BAYAN";
        //    }
        //}

        public String getCinsiyet()
        {
            return str_Cinsiyet;
        }

        private void methodResult2(Dictionary<int, double> dictionary)
        {
            double baySkor = 0;
            double bayanSkor = 0;
            for (int i = 0; i < makaleAdet; i++)
            {
                double skor = AgirlikliOylama(dictionary.Values.ElementAt(i));
                if (matris[dictionary.Keys.ElementAt(i), matris.GetLength(1) - 1] == 1)
                {
                    baySkor += skor;
                }

                else if (matris[dictionary.Keys.ElementAt(i), matris.GetLength(1) - 1] == 0)
                {
                    bayanSkor += skor;
                }
            }

            if (baySkor > bayanSkor)
            {
                str_Cinsiyet = "BAY";
            }
            if (bayanSkor > baySkor)
            {
                str_Cinsiyet = "BAYAN";
            }
        }

        private double AgirlikliOylama(double x)
        {
            return 1.0 / Math.Pow(x,2);
        }
    }
}
