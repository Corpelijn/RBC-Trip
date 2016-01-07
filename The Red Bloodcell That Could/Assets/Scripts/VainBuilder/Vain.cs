using Assets.Scripts.VainBuilder.OBJPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    public class Vain
    {
        #region "Attributes"

        private int id;
        protected Vain[] exits;
        protected GameObject obj;
        private bool isDrawn;
        protected float scale;
        private int zrotation;
        private float flip;

        protected Vector3 size;

        private int drawcalls = 1;

        #endregion

        #region "Constructors"

        public Vain()
        {
            isDrawn = false;
        }

        #endregion

        #region "Static Methods"

        public static Vain GetVain(string data)
        {
            data = data.Replace("\r", "");
            string[] d = data.Split(new char[] { ';' }, StringSplitOptions.None);

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
                case "D":
                    vain = new DVain();
                    break;
                case "E":
                    vain = new EVain();
                    break;
            }

            vain.id = Convert.ToInt32(d[1]);
            vain.scale = (float)Convert.ToDouble(d[3]);
            if (d[4] != "")
            {
                vain.zrotation = Convert.ToInt32(d[4]);
            }
            if (d[5] != "")
            {
                vain.flip = (float)Convert.ToDouble(d[5]);
            }

            return vain;
        }

        #endregion

        #region "Properties"

        public int GetID()
        {
            return this.id;
        }

        public void SetID(int value)
        {
            this.id = value;
        }

        public bool HasDrawcalls()
        {
            return drawcalls > -1;
        }

        public void AddDrawcall()
        {
            drawcalls++;
        }

        public void RemoveDrawcall()
        {
            drawcalls--;
        }

        public bool IsDrawn()
        {
            return this.isDrawn;
        }

        public GameObject GetGameObject()
        {
            return obj;
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

        public int GetExit(Vain vain)
        {
            for (int i = 0; i < exits.Length; i++)
            {
                if (exits[i] == vain)
                {
                    return i;
                }
            }
            return -1;
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

        /// <summary>
        /// Returns the amount of exits the current vain has
        /// </summary>
        /// <returns>The amount of exits</returns>
        public int GetExitCount()
        {
            return this.exits.Length;
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Draw the current vain to the gamescene
        /// </summary>
        /// <param name="parent">The parent transform for the vain to be part of</param>
        /// <param name="drawinfo">The information given by the CalculateNextPosition() method</param>
        /// <returns>Returns true if there is a second exit</returns>
        public bool DrawMe(Transform parent, VainDrawer drawinfo)
        {
            // Check if the vain is already drawn. If it is drawn already, skip creating the object
            if (!isDrawn)
            {
                // Get the next available object from the object pool
                //this.obj = ObjectPool.GetInstance().GetObject(this.GetType());
                this.obj = ObjectPool.INSTANCE.GetNext(this.GetType());

                // Set the parent of the object to the VainBuilder
                this.obj.transform.parent = parent;

                // Set the scale of the object
                this.obj.transform.localScale = new Vector3(this.scale, this.scale, this.scale);

                // Set the flip of the object
                for (int i = 0; i < this.obj.transform.childCount; i++)
                {
                    this.obj.transform.GetChild(i).eulerAngles = new Vector3(0, 180 - this.flip, this.zrotation * 30.0f);
                }

                // Remember that the vain is now drawn
                this.isDrawn = true;

                // Set the position and rotation of the vain
                if (!drawinfo.IsEmpty())
                    this.SetPosition(drawinfo);
            }

            // Return true if the vain has a second exit
            return this.HasSecondExit();
        }

        /// <summary>
        /// Destorys the object in the scene
        /// </summary>
        public void DestroyMe()
        {
            // Forget that we have drawn the object
            this.isDrawn = false;

            // Give the object back to the objectpool
            //ObjectPool.GetInstance().SetBeschikbaar(this.obj);
            ObjectPool.INSTANCE.GivebackObject(this.obj, this.GetType());

            // Set the gameobject property to null
            this.obj = null;
        }

        /// <summary>
        /// Sets the position and rotation of the new vain object to the correct parameters
        /// </summary>
        /// <param name="drawinfo">The information about how to rotate and position</param>
        protected virtual void SetPosition(VainDrawer drawinfo)
        {
            Debug.LogError("No method defined for subtype of vain: " + this.GetType().ToString() + " method: SetPosition()");
        }

        /// <summary>
        /// Get the next vain in the logic order
        /// </summary>
        /// <returns>The next vain from the current viewpoint</returns>
        public virtual Vain GetStraight(Vain last)
        {
            Debug.LogError("No method defined for subtype of vain: " + this.GetType().ToString() + " method: GetStraight()");
            return null;
        }

        /// <summary>
        /// Calculate the position of the next vain according to the ideas of the current vain
        /// </summary>
        /// <returns>The new position information</returns>
        public virtual VainDrawer CalculateNextPosition(Vain last, Vain next)
        {
            Debug.LogError("No method defined for subtype of vain: " + this.GetType().ToString() + " method: CalculateNextPosition()");
            return null;
        }

        /// <summary>
        /// Checks if the vain has second exit. For example the Y-shaped vain
        /// </summary>
        /// <returns>Return true if the vain has a second exit; otherwise false</returns>
        public virtual bool HasSecondExit()
        {
            Debug.LogError("No method defined for subtype of vain: " + this.GetType().ToString() + " method: HasSecondExit()");
            return false;
        }

        /// <summary>
        /// Get the other vain of the logic order
        /// </summary>
        /// <param name="last"></param>
        /// <returns></returns>
        public virtual Vain GetSecond(Vain last)
        {
            Debug.LogError("No method defined for subtype of vain: " + this.GetType().ToString() + " method: GetSecond()");
            return null;
        }

        #endregion
    }
}
