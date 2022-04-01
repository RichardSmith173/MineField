using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindField.Logic;
using MineField.Common;
using MineField.Common.Enumerations;
using System;

namespace MineField.Tests
{
    [TestClass]
    public class ArrowHandlerTests : TestBase
    {
        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.UpArrowHandler_UpdateCurrentGameData), typeof(DynamicDataSources))]
        public void UpArrowHandler_UpdateCurrentGameData(GridPosition currentPosition, GridPosition mineLocation, int lives, GameState gameState, int gridSize, GameState expectedGameState, string returnValue)
        {
            var gameData = new GameData();

            gameData.GameState = gameState;
            gameData.CurrentPosition = currentPosition;
            gameData.Lives = lives;
            gameData.MineLocations.Add(mineLocation);
            Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

            var arrowHandler = new UpArrowHandler();

            var userMessage = arrowHandler.UpdateCurrentGameData(gameData);

            Assert.AreEqual(userMessage, returnValue);
            Assert.IsTrue(gameData.GameState == expectedGameState);
        }

        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.DownArrowHandler_UpdateCurrentGameData), typeof(DynamicDataSources))]
        public void DownArrowHandler_UpdateCurrentGameData(GridPosition currentPosition, GridPosition mineLocation, int lives, GameState gameState, int gridSize, GameState expectedGameState, string returnValue)
        {
            var gameData = new GameData
            {
                GameState = gameState,
                CurrentPosition = currentPosition,
                Lives = lives
            };
            gameData.MineLocations.Add(mineLocation);
            Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

            var arrowHandler = new DownArrowHandler();

            var userMessage = arrowHandler.UpdateCurrentGameData(gameData);

            Assert.AreEqual(userMessage, returnValue);
            Assert.IsTrue(gameData.GameState == expectedGameState);
        }

        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.LeftArrowHandler_UpdateCurrentGameData), typeof(DynamicDataSources))]
        public void LeftArrowHandler_UpdateCurrentGameData(GridPosition currentPosition, GridPosition mineLocation, int lives, GameState gameState, int gridSize, GameState expectedGameState, string returnValue)
        {
            var gameData = new GameData();

            gameData.GameState = gameState;
            gameData.CurrentPosition = currentPosition;
            gameData.Lives = lives;
            gameData.MineLocations.Add(mineLocation);
            Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

            var arrowHandler = new LeftArrowHandler();

            var userMessage = arrowHandler.UpdateCurrentGameData(gameData);

            Assert.AreEqual(userMessage, returnValue);
            Assert.IsTrue(gameData.GameState == expectedGameState);
        }

        [TestMethod]
        [DynamicData(nameof(DynamicDataSources.RightArrowHandler_UpdateCurrentGameData), typeof(DynamicDataSources))]
        public void RightArrowHandler_UpdateCurrentGameData(GridPosition currentPosition, GridPosition mineLocation, int lives, GameState gameState, int gridSize, GameState expectedGameState, string returnValue)
        {
            var gameData = new GameData();

            gameData.GameState = gameState;
            gameData.CurrentPosition = currentPosition;
            gameData.Lives = lives;
            gameData.MineLocations.Add(mineLocation);
            Environment.SetEnvironmentVariable("GridSize", gridSize.ToString());

            var arrowHandler = new RightArrowHandler();

            var userMessage = arrowHandler.UpdateCurrentGameData(gameData);

            Assert.AreEqual(userMessage, returnValue);
            Assert.IsTrue(gameData.GameState == expectedGameState);
        }
    }
}
