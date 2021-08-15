using System.Runtime.InteropServices;
using Spongeware.Utils;
using UnityEngine;
using System.Diagnostics;
using Spongeware.Modules;
using System;

namespace Spongeware
{
    public class Main : MonoBehaviour
    {
        Manager manager;

        
        private void Start()
        {
            if (DebugConsole.IsDevEnvironment())
                DebugConsole.Write("A developer environment was detected, so a console was allocated for debug purposes.");
            try
            {
                TextManager.Get().Talk("Spongeware is now injected!");
            }
            catch
            {
                // this should fix injecting in the menu
            }

            DebugConsole.Write("Injected! Initializing modules...");

            manager = new Manager();
            manager.InitModules();

            DebugConsole.Write("All modules initialized successfully.");
        }

        private void Update()
        {
            try
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
            catch (Exception e)
            {
                foreach (Module mod in Manager.modules)
                {
                    mod.enabled = false; // we do this instead of mod.onDisable() in case that is why it crashed
                }
                DebugConsole.Write("Spongeware ran into a problem and needs to exit.\nException info:\n" + e.ToString());
                Loader.Unload();
            }
        }

        string val = "test";

        private void OnGUI()
        {
            try
            {
                Render.DrawString(new Vector2(0, Screen.height - 20), "Spongeware: premium meme software", Color.black, false);
                val = Render.DrawTextBox(new Rect(0, 0, 100, 20), val);
                //Render.DrawString(new Vector2(0, 0), val, false);
                foreach (Module module in Manager.modules)
                {
                    if (module.enabled)
                        module.onRender();
                }
            }
            catch (Exception e)
            {
                foreach (Module mod in Manager.modules)
                {
                    mod.enabled = false; // we do this instead of mod.onDisable() in case that is why it crashed
                }
                DebugConsole.Write("Spongeware ran into a problem. All modules have been disabled. \n Exception info:\n" + e.ToString());
                Loader.Unload();
            }
        }
    }
}
