/**
 * This Game engine handle all algorythms and GUI interface
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class GameEngine
    {
        public void startGame(){
            GameClient gameClient = new GameClient();
            gameClient.startServer();
            String response;
            


            
           
           // gameClient.turnRight();
            while (true)
            {
                response = gameClient.RecieveData();
                if (gameClient.decodeData(response))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Console.Write(gameClient.grid2[j,i]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
