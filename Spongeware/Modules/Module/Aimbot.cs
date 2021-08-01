using UnityEngine;

namespace Spongeware.Modules.Module
{
    internal class Aimbot : Spongeware.Module
    {
        public Aimbot() : base("Aimbot", "Combat", "Locks your camera on the nearest fish")
        {
        }

        public Fish GetClosestFish()
        {
            Fish[] fish = Object.FindObjectsOfType(typeof(Fish)) as Fish[];
            if (fish.Length != 0)
            {
                Fish currentFish = fish[0];

                foreach (Fish nextFish in fish)
                {
                    if ((nextFish.transform.position - player().transform.position).sqrMagnitude <
                   (currentFish.transform.position - player().transform.position).sqrMagnitude
                   && !nextFish.agent.isStopped)
                    {
                        currentFish = nextFish;
                    }
                }
                return currentFish;
            }
            return null;
        }

        public override void onUpdate()
        {
            if (GetClosestFish() != null) // aimbot fix :)
            {
                // 5 is added to the y value because the real fish position is at their feet :/

                Vector3 vector = new Vector3(GetClosestFish().transform.position.x, GetClosestFish().transform.position.y + 5,
              GetClosestFish().transform.position.z); // very large aimbot
                player().transform.LookAt(vector);
            }
        }
    }
}