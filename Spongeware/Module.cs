﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spongeware
{
    class Module
    {
        public string name;
        public string category;
        public string description;
        public bool enabled = false;


        // for arraylist
        public bool animating = false;
        public int progress = 1;

        // settings
        public Settings.Setting[] settings;

        public PlayerMovement player()
        {
            return UnityEngine.Object.FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        }

        public Module(string name, string category, string description, Settings.Setting[] settings)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.settings = settings;
        }

        public virtual void onEnable()
        {
            enabled = true;
        }
        public virtual void onDisable()
        {
            enabled = false;
        }
        public virtual void onUpdate() { }
        public virtual void onRender() { }

        public virtual void forever() { }
    }
}
