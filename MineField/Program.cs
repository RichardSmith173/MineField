using Autofac;
using MineField.Common;
using MineField.Common.Enumerations;
using MineField.Logic;
using System;

namespace MineField
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerSetup.BuildContainer();
            InitialiseGame();            
        }

        static void InitialiseGame()
        {
            Console.WriteLine(UserMessages.Welcome);

            var gameManager = ContainerSetup.Container.Resolve<IGameManager>();
            var gameData = new GameData();

            if (gameManager == null) throw new ArgumentNullException("Check the container is initialised correctly.");

            gameManager.StartGame(gameData);

            while (gameData.GameState == GameState.InProgress)
            {
                var message = gameManager.ProgressGame(gameData);

                Console.WriteLine(message);
            }
        }
    }
}
