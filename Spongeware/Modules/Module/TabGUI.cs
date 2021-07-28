using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class TabGUI : Spongeware.Module
    {
        public TabGUI() : base("TabGUI", "Visual", "This!")
        {

        }

        int currentCategory = 0, currentModule = 0;

        bool categorySelected = false, moduleSelected = false;

        string[] categories = Manager.categories.ToArray();
        Spongeware.Module[] modules;

        public override void forever()
        {
            // how 2 keybindo 102
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (enabled)
                    onDisable();
                else
                    onEnable();
            }
        }

        public override void onUpdate()
        {
            categories = Manager.categories.ToArray();
            modules = Manager.GetModulesFromCategory(categories[currentCategory]);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (categorySelected && !moduleSelected)
                {
                    if (currentCategory == 0)
                        currentCategory = categories.Length;
                    currentCategory--;
                } else
                {
                    if (moduleSelected)
                    {
                        if (currentModule == 0)
                            currentModule = modules.Length;
                        currentModule--;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (categorySelected && !moduleSelected)
                {
                    currentCategory++;
                    if (currentCategory >= categories.Length)
                        currentCategory = 0;
                } else
                {
                    currentModule++;
                    if (currentModule >= modules.Length)
                        currentModule = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!categorySelected)
                    categorySelected = true;
                else
                {
                    if (!moduleSelected)
                        moduleSelected = true;
                    else
                    {
                        Spongeware.Module moduleToToggle = (Spongeware.Module)modules.GetValue(currentModule);
                        if (moduleToToggle.enabled)
                            moduleToToggle.onDisable();
                        else
                            moduleToToggle.onEnable();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (moduleSelected)
                {
                    currentModule = 0;
                    moduleSelected = false;
                } else
                {
                    if (categorySelected)
                        categorySelected = false;
                }
            }
        }

        public override void onRender()
        {
            GUI.Box(new Rect(0, 15, 150, 20), "TabGUI");
            float offset = 35;
            float offset2 = 35;
            foreach (string category in categories)
            {
                if (categories[currentCategory] == category)
                    GUI.Box(new Rect(0, offset, 150, 20), category + ">>");
                else
                    GUI.Box(new Rect(0, offset, 150, 20), category);
                offset += 20;
            }

            if (moduleSelected)
            {
                foreach (Spongeware.Module module in modules)
                {
                    if (modules[currentModule] == module)
                        GUI.Box(new Rect(150, offset2, 150, 20), ">" + module.name + "(" + module.enabled.ToString() + ")");
                    else
                        GUI.Box(new Rect(150, offset2, 150, 20), module.name + "(" + module.enabled.ToString() + ")");
                    offset2 += 20;
                }
            }
            
            offset = 35;
            offset2 = 35;
        }
    }
}
