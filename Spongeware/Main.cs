using Spongeware.Utils;
using UnityEngine;
using Spongeware.Modules;

namespace Spongeware
{
    public class Main : MonoBehaviour
    {
        Manager manager;
        private void Start()
        {
            try
            {
                TextManager.Get().Talk("Spongeware is now injected!");
            }
            catch
            {
                // this should fix injecting in the menu
            }
            
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
            Render.DrawString(new Vector2(0, Screen.height - 20), "Spongeware: premium meme software", Color.black, false);
            foreach (Module module in Manager.modules)
            {
                if (module.enabled)
                    module.onRender();
            }
        }
    }
}
