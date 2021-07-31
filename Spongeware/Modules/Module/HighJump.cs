namespace Spongeware.Modules.Module
{
    class HighJump : Spongeware.Module
    {
        public HighJump() : base("HighJump", "Movement", "Jump to the moon")
        {
        }

        //public override void forever()
        //{
        //    if (Input.GetKeyDown(KeyCode.H))
        //    {
        //        if (enabled)
        //            onDisable();
        //        else
        //            onEnable();
        //    }
        //}

        public override void onEnable()
        {
            base.onEnable();
            player().jumpHeight = 35;
        }

        public override void onDisable()
        {
            base.onDisable();
            player().jumpHeight = 3;
        }
    }

}