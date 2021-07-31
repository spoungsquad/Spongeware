using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Spongeware.Modules.Module
{
    class LSD : Spongeware.Module
    {
        public LSD() : base("ForceLSD", "Visual", "Forces the conditions for using LSD to be correct")
        {

        }

        public override void onUpdate()
        {
            LSDTrigger trigger = UnityEngine.Object.FindObjectOfType(typeof(LSDTrigger)) as LSDTrigger;

            PrivateAccess.SetPrivateProperty(trigger, "inRange", true);
        }

        public override void onDisable()
        {
            base.onDisable();
            LSDTrigger trigger = UnityEngine.Object.FindObjectOfType(typeof(LSDTrigger)) as LSDTrigger;

            PrivateAccess.SetPrivateProperty(trigger, "inRange", false);
        }
    }
}
