using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class Speed : Spongeware.Module
    {
        public Speed() : base("Speed", "Movement", "Run really fast.")
        {
        }

        //public override void forever()
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
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
            player().walkSpeed = 36;
            player().runSpeed = 90;
        }

        public override void onDisable()
        {
            base.onDisable();
            player().walkSpeed = 12;
            player().runSpeed = 30;
        }
    }
}