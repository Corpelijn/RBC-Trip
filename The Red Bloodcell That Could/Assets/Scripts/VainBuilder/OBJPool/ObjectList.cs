using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.OBJPool
{
    class ObjectList
    {
        private Type type;
        private List<GameObject> objects;

        public ObjectList(Type type)
        {
            this.type = type;
            this.objects = new List<GameObject>();
        }

        public GameObject GetNextAvailable()
        {
            if (objects.Count == 0)
                return null;

            GameObject next = objects[0];
            objects.Remove(next);
            return next;
        }

        public void AddObject(GameObject obj)
        {
            if (!this.objects.Contains(obj))
                this.objects.Add(obj);
        }

        public Type Type
        { 
            get { return type; } 
        }
    }
}
