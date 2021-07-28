using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class AirJump : Spongeware.Module
    {
        public AirJump() : base("AirJump", "Movement", "Jump in the air")
        {

        }

        public override void onUpdate()
        {
            player().groundDistance = 10f;
        }
    }
}
