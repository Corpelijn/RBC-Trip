using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    public class VainDrawer
    {
        private Vector3 exitPosition;
        private Vector3 exitRotation;
        private int destinationExit;

        public VainDrawer(Vector3 ep, Vector3 er)
        {
            this.exitPosition = ep;
            this.exitRotation = er;
            this.destinationExit = -1;
        }

        public VainDrawer()
        {
            this.exitPosition = new Vector3(0, 0, 0);
            this.exitRotation = new Vector3(0, 0, 0);
        }

        public Vector3 ExitPosition
        {
            get { return this.exitPosition; }
        }

        public Vector3 ExitRotation
        {
            get { return this.exitRotation; }
        }

        public int DestinationExit
        {
            set { this.destinationExit = value; }
            get { return this.destinationExit; }
        }

        public bool IsEmpty()
        {
            if (this.exitPosition == new Vector3(0, 0, 0) && this.exitRotation == new Vector3(0, 0, 0))
            {
                return true;
            }
            return false;
        }
    }
}
