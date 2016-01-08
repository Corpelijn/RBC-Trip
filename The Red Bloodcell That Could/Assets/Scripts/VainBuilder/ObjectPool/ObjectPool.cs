using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ObjectPool
{
    using Assets.Scripts.VainBuilder;
    using Assets.Scripts.VainBuilder.Organen;
    using Object = UnityEngine.Object;

    class ObjectPool
    {
        private List<PoolList> objectList;

        public Vector3 Poolpoint = new Vector3(0, 0, -10);

        private static ObjectPool instance;
        public static ObjectPool GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectPool();
                instance.objectList = new List<PoolList>();
            }

            return instance;
        }

        public GameObject GetObject(Type type)
        {
            PoolList list = this.GetList(type);
            if (list != null)
            {
                GameObject go = list.GetNextAvaiableObject();
                if (go == null)
                {
                    go = CreateNewObject(list.GetGameObjectType());
                }
                return go;
            }

            this.objectList.Add(new PoolList(type));
            return this.GetObject(type);
        }

        private GameObject CreateNewObject(Type type)
        {
            GameObject go = null;
            if (type == typeof(YVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainY);
            }
            else if (type == typeof(SVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainS);
            }
            else if (type == typeof(TVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainT);
            }
            else if (type == typeof(DVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainD);
            }
            else if (type == typeof(EVain))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.VainE);
            }
            else if (type == typeof(Orgaan))
            {
                go = GameObject.Instantiate(ObjectPoolObjects.Instance.Orgaan);
            }


            if (go != null)
            {
                PoolList list = this.GetList(type);
                if (list != null)
                {
                    list.AddGameObject(go);
                }
            }

            return go;
        }

        public void SetBeschikbaar(GameObject obj)
        {
            for (int i = 0; i < this.objectList.Count; i++)
            {
                int result = this.objectList[i].Contains(obj);
                if (result != -1)
                {
                    this.objectList[i].SetBeschikbaar(result);
                    return;
                }
            }
        }

        private PoolList GetList(Type type)
        {
            for (int i = 0; i < this.objectList.Count; i++)
            {
                if (this.objectList[i].GetGameObjectType() == type)
                {
                    return this.objectList[i];
                }
            }

            return null;
        }
    }
}
