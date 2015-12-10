using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder
{
    class TVain : Vain
    {
        public TVain()
            : base()
        {
            this.exits = new Vain[2];
        }
    }
}
