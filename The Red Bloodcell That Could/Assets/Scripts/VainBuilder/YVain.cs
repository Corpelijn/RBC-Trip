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

        
    }
}
