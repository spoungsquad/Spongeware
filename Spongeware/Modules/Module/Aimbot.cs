using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class Aimbot : Spongeware.Module
    {
        public Aimbot() : base("Aimbot", "Combat", "Locks your camera on the nearest fish")
        {

        }

        private Fish GetClosestFish()
        {
            Fish[] fish = UnityEngine.Object.FindObjectsOfType(typeof(Fish)) as Fish[];
            Fish currentFish = fish[0];

            foreach (Fish nextFish in fish)
            {
                if ((nextFish.transform.position - player().transform.position).sqrMagnitude < 
                    (currentFish.transform.position - player().transform.position).sqrMagnitude )
                {
                    currentFish = nextFish;
                }
            }
            return currentFish;
        }

        public override void onUpdate()
        {
            Camera.current.transform.LookAt(GetClosestFish().transform);
        }
    }
}
