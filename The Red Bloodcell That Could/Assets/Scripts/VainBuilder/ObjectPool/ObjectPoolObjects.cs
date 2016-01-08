using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ObjectPool
{
    class ObjectPoolObjects : MonoBehaviour
    {
        public GameObject VainS = null;
        public GameObject VainY = null;
        public GameObject VainT = null;
        public GameObject VainD = null;
        public GameObject VainE = null;

        public GameObject Orgaan = null;

        public static ObjectPoolObjects Instance { get; private set; }

        public void Start()
        {
            Instance = this;
        }
    }
}
