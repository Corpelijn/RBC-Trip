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


        public GameObject Hersenen = null;
        public GameObject LongR = null;
        public GameObject LongL = null;
        public GameObject Hart = null;
        public GameObject Maag = null;
        public GameObject Lever = null;
        public GameObject Darmen = null;
        public GameObject Nier = null;

        public static ObjectPoolObjects Instance { get; private set; }

        public void Start()
        {
            Instance = this;
        }
    }
}
