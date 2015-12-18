using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.VainBuilder.OBJPool
{
    class ObjectPool
    {
        #region "Attributes"

        private List<ObjectList> lists;

        #endregion

        #region "Static Getter"

        private static ObjectPool instance;
        public static ObjectPool INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectPool();
                }
                return instance;
            }
        }

        #endregion

        private ObjectPool()
        {
            lists = new List<ObjectList>();
        }
    }
}
