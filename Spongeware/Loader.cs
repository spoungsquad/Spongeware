using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Spongeware
{
    public class Loader
    {
        public static GameObject gameObject;
        public static void Load()
        {
            gameObject = new GameObject();
            gameObject.AddComponent<Main>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
