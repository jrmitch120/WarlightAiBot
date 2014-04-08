using System;
using GamePlayer.Botting;
using GamePlayer.Botting.Commands;
using GamePlayer.Game;

namespace GamePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBot = new Bot(new GameState());

            while (true)
            {
                CommandResponse response = gameBot.ProcessCommand(Console.ReadLine());

                if (response.Action == CommandAction.Quit)
                    Environment.Exit(0);

                if (response.Action == CommandAction.Error)
                    Console.Error.WriteLine(response.ResponseData);
                
                else if (response.Action == CommandAction.SendData)
                    Console.WriteLine(response.ResponseData);
            }
        }
    }
}
