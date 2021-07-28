using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class Arraylist : Spongeware.Module
    {
        public Arraylist() : base("Arraylist", "Visual", "View all of your enabled modules in a cool way")
        {
            
        }

        public override void onRender()
        {
            List<Spongeware.Module> enabledModules = new List<Spongeware.Module>();

            foreach (Spongeware.Module module in Manager.modules)
            {
                if (module.enabled /*|| module.animating*/)
                    enabledModules.Add(module);
            }

            enabledModules = SortModules(enabledModules);

            int offset = Screen.height;
            for (int i = 0; i < enabledModules.Count; i++)
            {
                offset -= 20;
                Render.DrawString(new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i].name), offset),
                    enabledModules[i].name, Color.black, false);

                Render.DrawLine(new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i].name) - 3, offset + 20),
                    new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i].name) - 3, offset), Color.black, 3);

                if (i == enabledModules.Count - 1) // last module in the list (the top one) 
                {
                    Render.DrawLine(new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i].name) - 3, offset),
                        new Vector2(Screen.width, offset), Color.black, 3);
                } else // regular module
                {
                    Render.DrawLine(new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i].name) - 3, offset),
                        new Vector2(Screen.width - Render.GetTextWidth(enabledModules[i + 1].name) - 0.5f, offset), Color.black, 3);
                }
            }
        }

        private List<Spongeware.Module> SortModules(List<Spongeware.Module> modules)
        {
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < modules.Count - 1; i++)
                {
                    if (Render.GetTextWidth(modules[i].name) < Render.GetTextWidth(modules[i + 1].name))
                    {
                        Spongeware.Module temp = modules[i];

                        modules[i] = modules[i + 1];
                        modules[i + 1] = temp;
                        changed = true;
                    }
                }
            }
            return modules;
        }
    }
}
