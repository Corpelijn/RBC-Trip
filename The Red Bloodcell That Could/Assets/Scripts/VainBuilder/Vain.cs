using Assets.Scripts.MapGeneration.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    public class Vain
    {
        private int id;
        private string type;
        protected Vain[] exits;
        protected GameObject obj;
        private bool isDrawn;

        public Vain()
        {
            isDrawn = false;
        }

        public static Vain GetVain(string data)
        {
            string[] d = data.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Vain vain = null;
            switch (d[2])
            {
                case "Y":
                    vain = new YVain();
                    break;
                case "T":
                    vain = new TVain();
                    break;
                case "S":
                    vain = new SVain();
                    break;
            }
            vain.id = Convert.ToInt32(d[1]);

            return vain;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public GameObject GameObject
        {
            get { return obj; }
        }

        public Vain[] GetExits()
        {
            return this.exits.ToArray();
        }

        public Vain GetExit(int id)
        {
            if (id > exits.Length)
            {
                Debug.Log("Impossible id");
                return null;
            }
            return exits[id];
        }

        public void SetExit(int index, Vain vain)
        {
            if (index > exits.Length)
            {
                Debug.Log("Impossible id");
                return;
            }

            //Debug.Log(this.id + "." + index + " - " + vain.id);
            if (exits[index] != null)
            {
                Debug.Log("Exit " + index + " of vain " + this.id + " cannot be set to " + vain.id);
            }
            exits[index] = vain;
        }

        public virtual Vain[] DrawNext(Vain ingang, Transform parent)
        {
            if (ingang == null)
            {
                return null;
            }

            List<Vain> last = new List<Vain>();
            for (int i = 0; i < exits.Length; i++)
            {
                if (exits[i] != ingang && exits[i] != null)
                {
                    last.Add(exits[i]);
                }
            }
            return last.ToArray();
        }

        public virtual void UpdatePosition(Transform last, Vector3 position, Vector3 rotation, Vain exit)
        {
            obj.transform.position = new Vector3(last.position.x + position.x, last.position.y + position.y, last.position.z + position.z);
            obj.transform.eulerAngles = rotation;
        }

        public virtual GameObject DrawMe(Transform parent)
        {
            if (!isDrawn)
            {
                this.obj = ObjectPool.GetInstance().GetObject(this.GetType());
                this.obj.transform.parent = parent;
                this.isDrawn = true;
            }

            return this.obj;
        }

        public virtual GameObject DrawMe(Transform parent, GameObject previous)
        {
            return DrawMe(parent);
        }

        public virtual void DestroyMe()
        {
            this.isDrawn = false;
            ObjectPool.GetInstance().SetBeschikbaar(this.obj);
            this.obj = null;
        }

        public virtual int GetExitCount()
        {
            return this.exits.Length;
        }

        public virtual int GetNext(Vain previous)
        {
            if (exits.Length > 2 || exits.Length < 1)
                return -1;

            if (exits[0] == null || exits[1] == null)
            {
                if (exits[0] == previous)
                    return 1;
                else if (exits[1] == previous)
                    return 0;
            }

            return -1;
        }

        public virtual Vain GetStraight(Vain previous)
        {
            if (previous == null) return null;
            if (exits[0] == null)
            {
                if (exits[1] == null)
                {
                    return null;
                }
                else
                    return exits[1];
            }

            if (exits[0] == previous)
                return exits[1];
            else
                return exits[0];
        }

        public virtual VainDrawer CalculateNextPosition()
        {
            return new VainDrawer();
        }

        public virtual void SetTransform(VainDrawer vd)
        {
            this.GameObject.transform.position = vd.Position;
            this.GameObject.transform.eulerAngles = vd.Rotation;
        }
    }
}
