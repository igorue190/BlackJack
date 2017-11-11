using System;

namespace BlackJack
{
    class Program
    {
           
        static void Main(string[] args)
        {
            GameSession gameSession = new GameSession();
            do
            {
               gameSession.Game();
               Console.WriteLine("Press any key for deal!\n");
               GameSession.isWin = false;
               Console.ReadKey();
            }
            while (gameSession.money > 0);
            Console.ReadKey();
        }       
    }
}
