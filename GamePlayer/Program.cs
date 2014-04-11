using System;
using System.IO;
using GamePlayer.Botting.StupidBotting;
using GamePlayer.Engine;
using GamePlayer.Engine.Commands;

namespace GamePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new GameplayEngine(new StupidBot());

            var inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            while (true)
            {
                try
                {
                    CommandResponse response = engine.ProcessCommand(Console.ReadLine());

                    if (response.Action == CommandAction.Quit)
                        Environment.Exit(0);

                    if (response.Action == CommandAction.Error)
                        Console.Error.WriteLine(response.ResponseData);

                    else if (response.Action == CommandAction.SendData)
                        Console.WriteLine(response.ResponseData);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message + " : " + ex.StackTrace); 
                }
            }
        }
    }
}
