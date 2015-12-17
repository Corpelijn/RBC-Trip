using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    public class VainDrawer
    {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 exitCenter;

        public VainDrawer(Vector3 p, Vector3 r, Vector3 ec)
        {
            this.position = p;
            this.rotation = r;
            this.exitCenter = ec;
        }

        public VainDrawer()
        {
            this.position = new Vector3(0,0,0);
            this.rotation = new Vector3(0, 0, 0);
            this.exitCenter = new Vector3(0, 0, 0);
        }

        public Vector3 Position
        {
            get { return this.position; }
        }

        public Vector3 Rotation
        {
            get { return this.rotation; }
        }

        public Vector3 ExitCenter
        {
            get { return this.exitCenter; }
        }
    }
}
