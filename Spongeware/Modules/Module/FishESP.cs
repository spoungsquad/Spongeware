using Spongeware.Utils;
using System.Linq;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    internal class FishESP : Spongeware.Module
    {
        public FishESP() : base("FishESP", "Visual", "Look at fish from anywhere", null)
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

        public override void onRender()
        {
            fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];

            for (int i = 0; i < fish.Length; i++)
            {
                Vector3 footPos = fish[i].transform.position;
                Vector3 headPos; headPos.x = footPos.x; headPos.z = footPos.z; headPos.y = footPos.y + 6;

                Vector3 w2s_footPos = Camera.current.WorldToScreenPoint(footPos);
                Vector3 w2s_headPos = Camera.current.WorldToScreenPoint(headPos);

                if (w2s_footPos.z > 0)
                {
                    drawBoxESP(w2s_footPos, w2s_headPos, Color.red);
                }
            }
        }

        public void drawBoxESP(Vector3 footPos, Vector3 headPos, Color color)
        {
            if (fish.FirstOrDefault().wandering)//Check if fish is wandering to see if its dead
            {
                float height = headPos.y - footPos.y;
                float widthOffset = 2f;
                float width = height / widthOffset;
                Render.DrawBox(footPos.x - (width / 2), (float)Screen.height - footPos.y - height, width, height, color, 2f);
            }

        }
    }
}