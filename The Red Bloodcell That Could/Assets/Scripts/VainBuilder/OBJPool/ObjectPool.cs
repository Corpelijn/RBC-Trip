using Assets.Scripts.MapGeneration.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.OBJPool
{
    class ObjectPool
    {
        #region "Attributes"

        private List<ObjectList> lists;

        #endregion

        #region "Static Getter"

        private static ObjectPool instance;
        public static ObjectPool INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectPool();
                }
                return instance;
            }
        }

        #endregion

        private ObjectPool()
        {
            lists = new List<ObjectList>();
        }

        public GameObject GetNext(Type type)
        {
            // Find the object list
            ObjectList list = null;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Type == type)
                {
                    list = lists[i];
                    GameObject next = list.GetNextAvailable();
                    if(next == null)
                        break;
                    return next;
                }
            }

            // Create a new one
            GameObject go = null;
            if (type == typeof(SVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainS);
            }
            else if (type == typeof(DVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainD);
            }
            else if (type == typeof(EVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainE);
            }
            else if (type == typeof(YVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainY);
            }
            else if (type == typeof(TVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainT);
            }

            // Add the object to the list
            if (list == null)
                list = new ObjectList(type);

            return go;
        }

        public void GivebackObject(GameObject obj, Type type)
        {
            obj.transform.parent = ObjectPoolObjects.Instance.transform;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Type == type)
                {
                    lists[i].AddObject(obj);
                    return;
                }
            }

            lists.Add(new ObjectList(type));
            lists[lists.Count - 1].AddObject(obj);
        }
    }
}
