/**
 *  GameClient provide basic communication between client and server.
 * 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class GameClient
    {
        SendData sendData = new SendData();
        RecieveData recieveData = new RecieveData();
        int myID;           // hold client ID which send from server
        Player p0 = new Player();
        Player p1 = new Player();
        Player p2 = new Player();
        Player p3 = new Player();

        public char[,] grid = new char[10, 10] { 
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'}};           // B-brike S-stone W-water E-empty

        public char[,] grid2=new char[10,10];
        public void startServer()
        {
            sendData.connect();
            sendData.sendMessage("JOIN#");
            sendData.disconnect();
            Console.WriteLine("Joined");
        }
        public String RecieveData(){                // recieve data from server and return data
            return recieveData.connect();
        }

        public Boolean decodeData(String response)     // decode server response
        {


                if (response[0] == 'I' && response[1] == ':')           // arina details
                {
                    char[] colon = {':'};
                    String[] detail= response.Split(colon);
                    myID = (int)Char.GetNumericValue(detail[1][1]);
                    char[] comma = { ';' };
                    String[] brickList = detail[2].Split(comma);
                    for (int i = 0; i < brickList.Length; i++)
                    {
                        grid[(int)Char.GetNumericValue(brickList[i][0]),(int)Char.GetNumericValue(brickList[i][2])] = 'B';
                    }
                    String[] stoneList = detail[3].Split(comma);
                    for (int i = 0; i < stoneList.Length; i++)
                    {
                        grid[(int)Char.GetNumericValue(stoneList[i][0]), (int)Char.GetNumericValue(stoneList[i][2])] = 'S';
                    }
                    String[] waterList = detail[4].Split(comma);
                    for (int i = 0; i < waterList.Length; i++)
                    {
                        grid[(int)Char.GetNumericValue(waterList[i][0]), (int)Char.GetNumericValue(waterList[i][2])] = 'W';
                    }
                    //grid2 = grid;
                    //return true;
                }
                else if (response[0] == 'G' && response[1] == ':')          // update by broadcasting
                {
                 
                    for(int i=0;i<10;i++){
                        for (int j = 0; j < 10; j++)
                        {
                            grid2[i,j] = grid[i,j];
                        }
                    }
                    char[] colon = { ':' };
                    String[] detail = response.Split(colon);

                    grid2[(int)Char.GetNumericValue(detail[1][3]), (int)Char.GetNumericValue(detail[1][5])] = '0';
                    grid2[(int)Char.GetNumericValue(detail[2][3]), (int)Char.GetNumericValue(detail[2][5])] = '1';
                    grid2[(int)Char.GetNumericValue(detail[3][3]), (int)Char.GetNumericValue(detail[3][5])] = '2';
                    grid2[(int)Char.GetNumericValue(detail[4][3]), (int)Char.GetNumericValue(detail[4][5])] = '3';

                    return true;

                }
                else if (response[0] == 'S' && response[1] == ':')      // store initial positions
                {
                    p0.posX = (int)Char.GetNumericValue(response[5]);
                    p0.posY = (int)Char.GetNumericValue(response[7]);
                    //grid2[p0.posX,p0.posY] = '0';
                    p0.direction = (int)Char.GetNumericValue(response[9]);

                    p1.posX = (int)Char.GetNumericValue(response[14]);
                    p1.posY = (int)Char.GetNumericValue(response[16]);
                    //grid2[p1.posX, p1.posY] = '1';
                    p1.direction = (int)Char.GetNumericValue(response[18]);

                    p2.posX = (int)Char.GetNumericValue(response[23]);
                    p2.posY = (int)Char.GetNumericValue(response[25]);
                    //grid2[p2.posX, p2.posY] = '2';
                    p2.direction = (int)Char.GetNumericValue(response[27]);

                    p3.posX = (int)Char.GetNumericValue(response[32]);
                    p3.posY = (int)Char.GetNumericValue(response[34]);
                    //grid2[p3.posX, p3.posY] = '3';
                    p3.direction = (int)Char.GetNumericValue(response[36]);

                    //return true;
                }

                //grid2 = grid;
                return false;
        }

        public void turnRight()
        {
            sendData.connect();
            sendData.sendMessage("RIGHT#");
            sendData.disconnect();
            Console.WriteLine("RIGHT ->");
        }
        public void turnLeft()
        {
            sendData.connect();
            sendData.sendMessage("LEFT#");
            sendData.disconnect();
            Console.WriteLine("LEFT <-");
        }


    }
    class Player
    {
        public int posX, posY,direction;  


    }
}
