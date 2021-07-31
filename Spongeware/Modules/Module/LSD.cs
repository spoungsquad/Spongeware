using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Spongeware.Utils;

namespace Spongeware.Modules.Module
{
    class LSD : Spongeware.Module
    {
        public LSD() : base("ForceLSD", "Visual", "Forces the conditions for using LSD to be correct")
        {

        }

        public override void onUpdate()
        {
            try
            {
                LSDTrigger trigger = UnityEngine.Object.FindObjectOfType(typeof(LSDTrigger)) as LSDTrigger;

                PrivateAccess.SetPrivateProperty(trigger, "inRange", true);
            }
            catch
            {
                // fix
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            try
            {
                LSDTrigger trigger = UnityEngine.Object.FindObjectOfType(typeof(LSDTrigger)) as LSDTrigger;

                PrivateAccess.SetPrivateProperty(trigger, "inRange", false);
            }
            catch
            {
                // fix 2
            }
        }
    }
}
