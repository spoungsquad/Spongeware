using Spongeware.Utils;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class Tracers : Spongeware.Module
    {
        public Tracers() : base("Tracers", "Visual", "Draw a line to all fish")
        {
        }

        private Fish[] fish;
        public override void onRender()
        {
            fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];
            for (int i = 0; i < fish.Length; i++)
            {
                Vector3 vec1 = fish[i].transform.position;
                Vector3 w2s_vec1 = Camera.current.WorldToScreenPoint(vec1);
                if (w2s_vec1.z > 1f)
                {
                    drawTracers(w2s_vec1, Color.red);
                }
            }
        }

        public void drawTracers(Vector3 pos, Color color)
        {
            Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(pos.x, (float)Screen.height - pos.y), color, 2f);
        }
    }
}