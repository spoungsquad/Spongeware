using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class InfHealth : Spongeware.Module
    {
        public InfHealth() : base("InfHealth", "Combat", "Never die")
        {

        }

        //public override void forever()
        //{
        //    if (Input.GetKeyDown(KeyCode.V))
        //    {
        //        if (enabled)
        //            onDisable();
        //        else
        //            onEnable();
        //    }
        //}

        public override void onUpdate()
        {
            PlayerMovement.SetHealth(999);
        }

        public override void onDisable()
        {
            base.onDisable();
            PlayerMovement.SetHealth(100); // i think this is default health idfk
        }
    }
}