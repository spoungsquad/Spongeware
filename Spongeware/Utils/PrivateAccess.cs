using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spongeware.Utils
{
    class PrivateAccess
    {
        public static void SetPrivateProperty<T>(T obj, string propertyName, object newValue)
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

        // wtf
        public static object GetPrivateProperty<T>(T obj, string propertyName)
        {
            foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (fi.Name.ToLower().Contains(propertyName.ToLower()))
                {
                    return fi.GetValue(obj);
                }
            }
            return null;
        }

        public static object CallPrivateMethod<T>(T obj, string methodName, object[] param)
        {
            MethodInfo mi = obj.GetType().GetMethod(methodName);
            return mi.Invoke(obj, param);
        }
    }
}
