using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class NoFireRate : Spongeware.Module
    {
        public NoFireRate() : base("NoFireRate", "Combat", "No shooting speed limit")
        {

        }

        public override void onUpdate()
        {
            SetPrivatePropertyValue(player(), "fireTimer", 0);
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