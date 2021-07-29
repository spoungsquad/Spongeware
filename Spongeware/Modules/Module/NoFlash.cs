using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spongeware.Modules.Module
{
    class NoFlash : Spongeware.Module
    {
        public NoFlash() : base("NoFlash", "Visual", "Disables the muzzle flash")
        {

        }

        public override void onUpdate()
        {
            player().muzzleFlash.Stop();
        }
    }
}
