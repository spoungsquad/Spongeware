using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class RapidFire : Spongeware.Module
    {
        public RapidFire() : base("RapidFire", "Combat", "Shoot really fast")
        {

        }

        public override void onUpdate()
        {
            PrivateAccess.SetPrivateProperty(player(), "fireTimer", 0);
            if (Input.GetKey(KeyCode.Q))
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp | MouseOperations.MouseEventFlags.LeftDown);
            }
        }
    }
}
