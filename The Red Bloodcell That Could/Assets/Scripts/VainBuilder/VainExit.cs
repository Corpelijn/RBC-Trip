using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder
{
    class VainExit
    {
        private int vain1;
        private int vain1Exit;
        private int vain2;
        private int vain2Exit;

        public VainExit(string data)
        {
            string[] d = data.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            this.vain1 = Convert.ToInt32(d[1]);
            this.vain1Exit = Convert.ToInt32(d[2]);
            this.vain2 = Convert.ToInt32(d[3]);
            this.vain2Exit = Convert.ToInt32(d[4]);
        }

        public int Vain1
        {
            get { return vain1; }
            set { vain1 = value; }
        }

        public int Vain1Exit
        {
            get { return vain1Exit; }
            set { vain1Exit = value; }
        }

        public int Vain2
        {
            get { return vain2; }
            set { vain2 = value; }
        }

        public int Vain2Exit
        {
            get { return vain2Exit; }
            set { vain2Exit = value; }
        }


        private static int ids = 10000;
        private static int GetNextID()
        {
            return ids++;
        }

        public static string[] GetExits(string data)
        {
            string[] d = data.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> exits = new List<string>();

            string currentID = d[1];
            string currentExit = d[2];
            string nextID = GetNextID().ToString();
            string nextExit = "0";
            for (int i = 0; i < Convert.ToInt32(d[5]); i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("e;");

                // e;x;0;y;0;
                // e;z;1;a;0;

                sb.Append(currentID).Append(";").Append(currentExit).Append(";");
                sb.Append(nextID).Append(";").Append(nextExit).Append(";");
                exits.Add("v;" + nextID + ";S;1;;;");

                currentID = nextID;
                currentExit = "1";
                nextID = GetNextID().ToString();

                exits.Add(sb.ToString());
            }

            exits.Add("e;" + currentID + ";" + currentExit + ";" + d[3] + ";" + d[4] + ";");

            return exits.ToArray();
        }
    }
}
