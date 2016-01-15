using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Player : MonoBehaviour
    {
        //public LayerMask mask;
        public GameObject player = null;
        public GameObject currentVain = null;

        private const float SPEED = 0.05f;

        public static Player Instance { get; private set; }

        public void Start()
        {
            if (Player.Instance == null)
            {
                Player.Instance = this;
            }
        }

        public void Update()
        {
            //this.transform.position = this.transform.position + new Vector3(Input.GetKey(KeyCode.LeftArrow) ? -SPEED : Input.GetKey(KeyCode.RightArrow) ? SPEED : 0, 0, SPEED);

            Ray rayRight = new Ray(player.transform.position, Vector3.right);
            Ray rayLeft = new Ray(player.transform.position, Vector3.left);
            Ray rayTop = new Ray(player.transform.position, Vector3.up);
            Ray rayDown = new Ray(player.transform.position, Vector3.down);
            Ray rayForward = new Ray(player.transform.position, Vector3.forward);
            Ray rayBackward = new Ray(player.transform.position, Vector3.back);

            RaycastHit[] hit = new RaycastHit[6];
            bool[] hitting = new bool[6];

            // 11011111
            //int m = ~223;
            hitting[0] = Physics.Raycast(rayRight, out hit[0]);
            hitting[1] = Physics.Raycast(rayLeft, out hit[1]);
            hitting[2] = Physics.Raycast(rayTop, out hit[2]);
            hitting[3] = Physics.Raycast(rayDown, out hit[3]);
            hitting[4] = Physics.Raycast(rayForward, out hit[4]);
            hitting[5] = Physics.Raycast(rayBackward, out hit[5]);

            int closest = 0;
            for (int i = 0; i < hit.Length; i++)
            {
                if (!hitting[closest])
                    closest++;
                if (closest > 5)
                    break;
                if (hitting[closest] && hitting[i])
                {
                    if (hit[closest].distance > hit[i].distance)
                    {
                        closest = i;
                    }
                }
            }

            if (closest > 5)
            {
                currentVain = null;
                return;
            }

            if (!hitting[closest])
            {
                currentVain = null;
            }
            else
            {
                currentVain = hit[closest].transform.parent.gameObject;
            }
        }
    }
}
