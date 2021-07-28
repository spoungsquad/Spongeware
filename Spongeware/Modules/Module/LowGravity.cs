using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class LowGravity : Spongeware.Module
    {
        public LowGravity() : base("LowGravity", "Movement", "Bounce Around")
        {

        }

        //public override void forever()
        //{
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
            base.onEnable();
            player().gravity = -2.5F;
        }

        public override void onDisable()
        {
            base.onDisable();
            player().gravity = -9.81F;
        }
    }
}