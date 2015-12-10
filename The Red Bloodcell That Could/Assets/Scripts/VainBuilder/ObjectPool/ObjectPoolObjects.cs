using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ObjectPool
{
    class ObjectPoolObjects : MonoBehaviour
    {
        public GameObject VainS;
        public GameObject VainY;
        public GameObject VainT;

        public static ObjectPoolObjects Instance { get; private set; }

        public void Start()
        {
            Instance = this;
        }
    }
}
