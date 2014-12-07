using System;

namespace BallDodge
{
#if WINDOWS || XBOX
    static class BallDodge
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BallDodgeGame game = new BallDodgeGame())
            {
                game.Run();
            }
        }
    }
#endif
}

