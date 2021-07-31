using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Settings.ModuleSettings
{
    class Keybind : Setting
    {
        public KeyCode key;

        public Keybind(KeyCode key)
        {
            this.key = key;
        }
    }
}
