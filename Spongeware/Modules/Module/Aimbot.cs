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
            Fish[] fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];
            Fish currentFish = fish[0];

            foreach (Fish nextFish in fish)
            {
                if (GetClosestFish().wandering)//Check if fish is wandering to see if its dead
                {
                    if ((nextFish.transform.position - player().transform.position).sqrMagnitude <
                   (currentFish.transform.position - player().transform.position).sqrMagnitude
                   && !nextFish.agent.isStopped)
                    {
                        currentFish = nextFish;
                    }
                }
            }
            return currentFish;
        }

        public override void onUpdate()
        {
            // 5 is added to the y value because the real fish position is at their feet :/
            if (GetClosestFish().wandering)//Check if fish is wandering to see if its dead
            {
                Vector3 vector = new Vector3(GetClosestFish().transform.position.x, GetClosestFish().transform.position.y + 5,
              GetClosestFish().transform.position.z); // very large aimbot
                player().transform.LookAt(vector);
            }
        }
    }
}