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
        
    }
}
