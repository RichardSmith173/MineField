using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindField.Logic;
using MineField.Common;
using MineField.Common.Enumerations;
using MineField.Logic;
using System;
using System.Linq;

namespace MineField.Tests
{
    [TestClass]
    public class MineFieldLogicTests : TestBase
    {
        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.GameManager_StartOfGame_SalienceChecks), typeof(DynamicDataSources))]
        public void GameManager_StartOfGame_SalienceChecks(int numberOfMines, int gridSize, int numberOfLives, Type expectedExceptionType)
        {
            try
            {
                var gameData = new GameData();

                Environment.SetEnvironmentVariable("NumberOfMines", numberOfMines.ToString());
                Environment.SetEnvironmentVariable("NumberOfLives", numberOfLives.ToString());
                Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

                var gameManager = new GameManager(UserInputHandlers.Object);

                gameManager.StartGame(gameData);

                Assert.Fail("Expected exception did not occur.");
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception, expectedExceptionType);
            }
        }

        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.GameManager_StartOfGame), typeof(DynamicDataSources))]
        public void GameManager_StartOfGame(int numberOfMines, int gridSize, int numberOfLives)
        {
            var gameData = new GameData();
            Environment.SetEnvironmentVariable("NumberOfMines", numberOfMines.ToString());
            Environment.SetEnvironmentVariable("NumberOfLives", numberOfLives.ToString());
            Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

            var gameManager = new GameManager(UserInputHandlers.Object);

            gameManager.StartGame(gameData);

            Assert.AreEqual(numberOfMines, gameData.MineLocations.Count());
            Assert.AreEqual(numberOfLives, gameData.Lives);
            Assert.IsTrue(gameData.GameState == GameState.InProgress);
        }        
    }
}
