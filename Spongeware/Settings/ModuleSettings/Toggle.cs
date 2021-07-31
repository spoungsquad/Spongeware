using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spongeware.Settings.ModuleSettings
{
    class Toggle : Setting
    {
        public bool value;

        public Toggle(bool value)
        {
            this.value = value;
        }
    }
}
