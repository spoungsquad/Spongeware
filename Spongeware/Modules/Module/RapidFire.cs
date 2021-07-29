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
            SetPrivatePropertyValue(player(), "fireTimer", 0);
            if (Input.GetKey(KeyCode.Q))
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp | MouseOperations.MouseEventFlags.LeftDown);
            }
        }

        public void SetPrivatePropertyValue<T>(T obj, string propertyName, object newValue)
        {
            foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (fi.Name.ToLower().Contains(propertyName.ToLower()))
                {
                    fi.SetValue(obj, newValue);
                    break;
                }
            }

        }

    }
}
