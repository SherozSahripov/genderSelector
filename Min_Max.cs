using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select_Gender_from_Article.MyClasses
{
    class Min_Max
    {
        private List<float> dizi;

        private float Min, Max;

        public Min_Max(List<float> list)
        {
            //dizi = new List<float>(list);
            dizi = list;
            FindMaxMin();
            CreateList();
        }

        private void FindMaxMin()
        {
            List<float> sortList = new List<float>(dizi);
            sortList.Sort();
            Min = sortList[0];
            Max = sortList[sortList.Count - 1];
        }

        private void CreateList()
        {
            for (int i = 0; i < dizi.Count; i++)
            {
                dizi[i] = (dizi[i] - Min) / (Max - Min);
            }
        }

        public List<float> GetList()
        {
            return dizi;
        }

        public float GetMax()
        {
            return Max;
        }

        public float GetMin()
        {
            return Min;
        }
    }
}
