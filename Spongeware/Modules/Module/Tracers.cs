﻿using System.Linq;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    internal class Tracers : Spongeware.Module
    {
        public Tracers() : base("Tracers", "Visual", "Draw a line to all fish")
        {
        }

        private Fish[] fish;

        public override void onRender()
        {
            fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];

            if (fish.FirstOrDefault().wandering)//Check if fish is wandering to see if its dead
            {
                for (int i = 0; i < fish.Length; i++)
                {
                    Vector3 vec1 = fish[i].transform.position;
                    Vector3 w2s_vec1 = Camera.current.WorldToScreenPoint(vec1);
                    if (w2s_vec1.z > 1f)
                    {
                        drawTracers(w2s_vec1, Color.clear);
                    }
                }
            }
        }

        public void drawTracers(Vector3 pos, Color color)
        {
            if (fish.FirstOrDefault().wandering)//Check if fish is wandering to see if its dead
            {
                Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(pos.x, (float)Screen.height - pos.y), color, 2f);
            }
        }
    }
}