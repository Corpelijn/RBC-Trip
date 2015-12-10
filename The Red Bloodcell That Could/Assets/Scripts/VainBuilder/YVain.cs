using Assets.Scripts.MapGeneration.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class YVain : Vain
    {
        public YVain()
            : base()
        {
            this.exits = new Vain[3];
        }

        public override Vain[] DrawNext(Vain ingang, Transform parent)
        {
            if (ingang == null)
            {
                return null;
            }

            List<Vain> vains = new List<Vain>();

            // Komt aan vanaf de onderkant (enkele ingang/uitgang), splits naar de dubbele ingang/uitgang
            if (ingang == exits[0])
            {
                for (int i = 1; i < exits.Length; i++)
                {
                    if (exits[i] != ingang)
                    {
                        exits[i].DrawMe(parent);
                        float x_pos = (i == 2 ? 0.58f : i * -0.58f);
                        exits[i].UpdatePosition(this.obj.transform, new Vector3(x_pos, 0, 3), new Vector3(), exits[i]);
                        vains.Add(exits[i]);
                    }
                }
            }
            // Komt aan vanaf van een van de aftakkingen aan de bovenkant
            else
            {
                // Teken alleen de doorgang naar voren toe
                exits[0].DrawMe(parent);
                exits[0].UpdatePosition(this.obj.transform, new Vector3(0, 0, 3), new Vector3(), exits[0]);
                vains.Add(exits[0]);
            }

            return vains.ToArray();
        }

        public override void UpdatePosition(Transform last, Vector3 position, Vector3 rotation, Vain exit)
        {
            base.UpdatePosition(last, position, rotation, exit);

            if (exit == exits[0])
            {
            }
            else if (exit == exits[1])
            {

            }
            else
            {
                if (last.eulerAngles.y == 0)
                {
                    if (this.obj.transform.position.z > last.position.z)
                    {
                        this.obj.transform.eulerAngles = new Vector3(0, 180, 0);
                        this.obj.transform.position = new Vector3(this.obj.transform.position.x - 0.58f, this.obj.transform.position.y, this.obj.transform.position.z);
                    }
                    else if (this.obj.transform.position.z < last.position.z)
                    {
                        this.obj.transform.eulerAngles = new Vector3(0, 0, 0);
                        this.obj.transform.position = new Vector3(this.obj.transform.position.x + 0.58f, this.obj.transform.position.y, this.obj.transform.position.z);
                    }
                }
            }
        }
    }
}
