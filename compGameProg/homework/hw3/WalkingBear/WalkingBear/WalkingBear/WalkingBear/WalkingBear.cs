using System;

namespace WalkingBear
{
#if WINDOWS || XBOX
    static class WalkingBear
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (WalkingBearGame game = new WalkingBearGame())
            {
                game.Run();
            }
        }
    }
#endif
}

