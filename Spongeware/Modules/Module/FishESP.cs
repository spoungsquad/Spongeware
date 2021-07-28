using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class FishESP : Spongeware.Module
    {
        public FishESP() : base("FishESP", "Visual", "Look at fish from anywhere")
        {

        }

        //public override void forever()
        //{
        //    // how 2 keybindo 102
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        if (enabled)
        //            onDisable();
        //        else
        //            onEnable();
        //    }
        //}

        private Fish[] fish;
        private Rect rect;

        public override void onRender()
        {
            fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];

            for (int i = 0; i < fish.Length; i++)
            {
                Vector3 vec1 = fish[i].transform.position;
                Vector3 vec2 = vec1;
                vec2.y += 1.8f;
                vec1 = Camera.current.WorldToScreenPoint(vec1);
                vec2 = Camera.current.WorldToScreenPoint(vec2);
                if (vec1.z > 0f && vec2.z > 0f)
                {
                    Vector3 vector3 = GUIUtility.ScreenToGUIPoint(vec1);
                    vector3.y = (float)Screen.height - vector3.y;
                    Vector3 vector4 = GUIUtility.ScreenToGUIPoint(vec2);
                    vector4.y = (float)Screen.height - vector4.y;
                    float num = Math.Abs(vector3.y - vector4.y) / 2.2f;
                    float num2 = num / 2f;
                    rect = new Rect(new Vector2(vector4.x - num2, vector4.y), new Vector2(num, vector3.y - vector4.y));
                }

                GUI.Box(rect, "");
            }
            player().jumpHeight = 50;
        }
    }
}
