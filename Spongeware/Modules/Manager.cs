using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spongeware.Modules.Module;

namespace Spongeware.Modules
{
    class Manager
    {
        public static List<Spongeware.Module> modules;
        public static List<string> categories;
        public Manager()
        {
            modules = new List<Spongeware.Module>();
            categories = new List<string>();
        }

        public void InitModules()
        {
            modules.Add(new FishESP());
            //modules.Add(new LSD());
            modules.Add(new InfAmmo());
            modules.Add(new TabGUI());
            modules.Add(new HighJump());
            modules.Add(new InfHealth());
            modules.Add(new LowGravity());
            modules.Add(new Speed());
            modules.Add(new Aimbot());
            modules.Add(new AirJump());
            modules.Add(new Tracers());
            modules.Add(new Arraylist());
            modules.Add(new NoFlash());

            foreach (Spongeware.Module module in modules.ToArray())
            {
                if (!categories.Contains(module.category))
                    categories.Add(module.category); // gang shit

                if (module.name == "TabGUI" || module.name == "Arraylist")
                    module.onEnable();
            }
        }

        public static Spongeware.Module[] GetModulesFromCategory(string category)
        {
            List<Spongeware.Module> temp = new List<Spongeware.Module>();
            foreach (Spongeware.Module module in modules)
            {
                if (module.category == category)
                    temp.Add(module);
            }
            return temp.ToArray();
        }
    }
}
