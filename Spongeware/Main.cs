using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using Spongeware.Modules;
using System.Windows.Forms;

namespace Spongeware
{
    public class Main : MonoBehaviour
    {
        Manager manager;
        private void Start()
        {
            TextManager.Get().Talk("Spongeware is now injected!");
            manager = new Manager();
            manager.InitModules();
        }

        private void Update()
        {
            foreach (Module module in Manager.modules)
            {
                module.forever();
                if (module.enabled)
                {
                    module.onUpdate();
                }
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 300, 40), "Spongeware: premium meme software");
            foreach (Module module in Manager.modules)
            {
                if (module.enabled)
                    module.onRender();
            }
        }
    }
}
