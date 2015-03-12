using System;

namespace game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.startGame();
            /*using (GUI game = new GUI())
            {
                game.Run();
            }*/
        }
    }
#endif
}

