using Spongeware.Utils;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class TabGUI : Spongeware.Module
    {
        public TabGUI() : base("TabGUI", "Visual", "This!", null)
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
            Render.DrawBox(new Vector2(20, 20), new Vector2(80, categories.Length * 20), new Color(15, 15, 15));
            Render.DrawBox(20, 20, 80, categories.Length * 20, new Color(0, 0, 0), 3);
            //GUI.Box(new Rect(0, 15, 150, 20), "TabGUI");
            float offset = 20;
            float offset2 = 20;
            foreach (string category in categories)
            {
                if (categories[currentCategory] == category && categorySelected)
                    Render.DrawString(new Vector2(23, offset), category + ">>", new Color(0, 0, 0), false);
                    //GUI.Box(new Rect(0, offset, 150, 20), category + ">>");
                else
                    Render.DrawString(new Vector2(23, offset), category, new Color(0, 0, 0), false);
                    //GUI.Box(new Rect(0, offset, 150, 20), category);
                offset += 20;
            }

            if (moduleSelected)
            {
                Render.DrawBox(new Vector2(100, 20), new Vector2(120, modules.Length * 20), new Color(15, 15, 15));
                Render.DrawBox(100, 20, 120, modules.Length * 20, new Color(0, 0, 0), 3);
                foreach (Spongeware.Module module in modules)
                {
                    if (modules[currentModule] == module)
                        Render.DrawString(new Vector2(103, offset2), ">" + module.name + " (" + module.enabled.ToString() + ")", new Color(0, 0, 0), false);
                        //GUI.Box(new Rect(150, offset2, 150, 20), ">" + module.name + "(" + module.enabled.ToString() + ")");
                    else
                        Render.DrawString(new Vector2(103, offset2), module.name + " (" + module.enabled.ToString() + ")", new Color(0, 0, 0), false);
                        //GUI.Box(new Rect(150, offset2, 150, 20), module.name + "(" + module.enabled.ToString() + ")");
                    offset2 += 20;
                }
            }
            
            offset = 35;
            offset2 = 35;
        }
    }
}
