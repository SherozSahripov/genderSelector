using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Select_Gender_from_Article.MyClasses
{
    class toolText
    {

        private static String Text = "";
        private int[] list;

        public toolText(String Metin)
        {
            Text = Metin;
            StartClass();
        }




        /// <summary>
        /// Clastaki tüm metodları birleştiren metotdur
        /// </summary>
        /// <returns>0-255 sayılarından kaç tane olduğunu bir dizi ile dönderiyor</returns>
        private void StartClass()
        {
            String Metin = Surplus(Text);

            Byte[] liste1 = Encoding.ASCII.GetBytes(Metin);

            List<Byte> liste2 = AddZeros(liste1.ToList<Byte>());

            String[] liste3 = CompareToNeighborgs(liste2);

            List<Byte> liste4 = ConvertToDecimal(liste3);

            Byte[] liste5 = liste4.ToArray();

            list = PieceOfNumbers(liste5);
        }





        /// <summary>
        /// Metnin İçindeki noktalama işaretleri atar.
        /// </summary>
        /// <param name="text">Gelen metin</param>
        /// <returns>Noktalama işaretleri atılmış hali</returns>
        private String Surplus(String text)
        {
            String ss = "";
            String[] abc = Regex.Split(text, @"[^a-zA-Z0-9]");
            foreach (String item in abc)
            {
                ss += item;
            }
            return ss;
        }




        /// <summary>
        /// Listedeki karakterlerin ASCII karşılığı bir listede, listenin sağına ve soluna 4 adet sıfır ekliyor
        /// </summary>
        /// <param name="ZerosArray">Karakterlerin ASCII karşılığı bir liste</param>
        /// <returns>Sağına ve soluna 4 sıfır ekli halini dönderiyor</returns>
        private List<Byte> AddZeros(List<Byte> ZerosArray)
        {

            ZerosArray.Insert(0, 0);
            ZerosArray.Insert(1, 0);
            ZerosArray.Insert(2, 0);
            ZerosArray.Insert(3, 0);
            ZerosArray.Insert(ZerosArray.Count, 0);
            ZerosArray.Insert(ZerosArray.Count - 1, 0);
            ZerosArray.Insert(ZerosArray.Count - 2, 0);
            ZerosArray.Insert(ZerosArray.Count - 3, 0);
            return ZerosArray;
        }




        /// <summary>
        /// Algoritmaıyı oluşturan metoddur. 4 sağ ve 4 sol kontrol ederek 8 bitlik bir binary kod oluşturuyor
        /// </summary>
        /// <param name="CompareList">Sağına ve soluna 4 sıfır ekli halinde gelen bir dizi</param>
        /// <returns>Oluşturulan 8 bitlik kodları bir dizi şeklinde dönderiyor.</returns>
        private String[] CompareToNeighborgs(List<Byte> CompareList)
        {
            String[] GenuineList = new String[CompareList.Count - 8];

            for (int i = 4; i < CompareList.Count - 4; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (CompareList[i] >= CompareList[i - j])
                    {
                        GenuineList[i - 4] += "1";
                    }
                    else if (CompareList[i] < CompareList[i - j])
                    {
                        GenuineList[i - 4] += "0";
                    }
                }

                for (int s = 1; s < 5; s++)
                {
                    if (CompareList[i] >= CompareList[i + s])
                    {
                        GenuineList[i - 4] += "1";
                    }
                    else if (CompareList[i] < CompareList[i + s])
                    {
                        GenuineList[i - 4] += "0";
                    }
                }

            }
            return GenuineList;
        }




        /// <summary>
        /// 8 bitlik binary kodu decimal koda çeviren metoddur.
        /// </summary>
        /// <param name="CompareToNeighborgsSecond">8 bitlik kodları barındıran bir dizi</param>
        /// <returns>8 bitlik kodların karşılığı olan decimal kodları bir liste şeklinde dönderiyor.</returns>
        private List<Byte> ConvertToDecimal(String[] CompareToNeighborgsSecond)
        {
            List<Byte> ConvertToDecimal2 = new List<byte>();
            byte dec = 0;

            for (int i = 0; i < CompareToNeighborgsSecond.Length; i++)
            {
                for (int k = 0; k < CompareToNeighborgsSecond[i].Length; k++)
                {

                    if ((CompareToNeighborgsSecond[i].Substring(k, 1)).Equals("0"))
                        continue;
                    dec += (byte)Math.Pow(2, 7 - k);
                }
                ConvertToDecimal2.Add(dec);
                dec = 0;
            }

            return ConvertToDecimal2;
        }





        /// <summary>
        /// 0-255 sayılarından kaç adet olduğunu bulan metoddur
        /// </summary>
        /// <param name="Piece">decimal kodların bulunduğu dizidir</param>
        /// <returns>0-255 sayılarından kaç adet olduğunu bulup ve diziyle dönderir.</returns>
        private int[] PieceOfNumbers(Byte[] Piece)
        {
            int[] matris = new int[256];

            for (int i = 0; i < Piece.Length; i++)
            {
                for (int k = 0; k < 256; k++)
                {
                    if (Piece[i] == k)
                    {
                        matris[k]++;
                    }
                }
            }
            return matris;
        }




        public int[] getList()
        {
            return list;
        }
    }
}
