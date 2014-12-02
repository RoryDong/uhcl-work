using System;

namespace FallingFalcon
{
#if WINDOWS || XBOX
    static class FalconMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FallingFalconGame falconGame = new FallingFalconGame())
            {
                falconGame.Run();
            }
        }
    }
#endif
}

