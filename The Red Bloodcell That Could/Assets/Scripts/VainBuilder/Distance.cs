using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder
{
    public class Distance
    {
        private int id_1;
        private int id_2;
        private int distance;
        private List<int> subs;

        public Distance(int id_1, int id_2, int distance)
        {
            this.id_1 = id_1;
            this.id_2 = id_2;
            this.distance = distance;
            this.subs = new List<int>();
        }

        public int ID1
        {
            get { return this.id_1; }
        }

        public int ID2
        {
            get { return this.id_2; }
        }

        public int Afstand
        {
            get { return this.distance; }
        }

        public void AddSubNumber(int number)
        {
            this.subs.Add(number);
        }

        public int Contains(int id)
        {
            if (id == id_1)
            {
                return 0;
            }
            else if (subs.IndexOf(id) != -1)
            {
                return subs.IndexOf(id)+ 1;
            }
            if (id == id_2)
            {
                return subs.Count + 1;
            }
            return -1;
        }

        private static List<Distance> instance;
        public static void AddDistance(string[] data)
        {
            if (instance == null) instance = new List<Distance>();

            int startID = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].StartsWith("e"))
                {
                    startID = GetValue(data[i], 1);
                    break;
                }
            }

            int endID = -1;
            for (int i = data.Length - 1; i > -1; i++)
            {
                if (data[i].StartsWith("e"))
                {
                    endID = GetValue(data[i], 3);
                    break;
                }
            }

            int amount = new List<string>(data).Count(item => item.StartsWith("e")) - 1;

            instance.Add(new Distance(startID, endID, amount));

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].StartsWith("e"))
                {
                    int value = GetValue(data[i], 1);
                    if (value != startID && value != endID)
                    {
                        instance[instance.Count - 1].AddSubNumber(value);
                    }
                }
            }
        }

        private static int GetValue(string data, int field)
        {
            string[] dat = data.Split(new char[] {';'});

            return Convert.ToInt32(dat[field]);
        }

        public static float GetDistance(int currentid)
        {
            Distance dist = instance.Find(item => item.Contains(currentid) != -1);

            int length = dist.Afstand + 1;
            int index = dist.Contains(currentid);


            return 1.0f / length * index;
        }

        public static BloedLocatie GetLocatie(int currentid)
        {
            Distance dist = instance.Find(item => item.Contains(currentid) != -1);
            return (BloedLocatie)dist.ID2;
        }
    }
}
