using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Spongeware.Modules.Module
{
    class LSD : Spongeware.Module
    {
        public LSD() : base("LSD", "Visual", "The LSD effect from Sandy's table")
        {

        }

        //public override void forever()
        //{
        //    // how 2 keybindo 102
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        if (enabled)
        //            onDisable();
        //        else
        //            onEnable();
        //    }
        //}

        public override void onEnable()
        {
            //shit
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();

        }
    }
}
