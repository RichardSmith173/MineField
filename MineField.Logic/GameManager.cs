using MineField.Common;
using MineField.Common.Enumerations;
using MindField.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineField.Logic
{
    /// <summary>
    /// Manages the state of the game
    /// </summary>
    public class GameManager : IGameManager
    {
        private readonly Dictionary<ConsoleKey, IUserInputHandler> _userInputHandlers;

        private readonly List<ConsoleKey> ValidGamePlayCharacters = new List<ConsoleKey> { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow };

        public GameManager(Dictionary<ConsoleKey, IUserInputHandler> userInputHandlers)
        {
            _userInputHandlers = userInputHandlers;
        }

        /// <summary>
        /// Starts the game and sets the grid up.
        /// </summary>
        public void StartGame(GameData gameData)
        {
            var numberOfMines = int.Parse(Environment.GetEnvironmentVariable("NumberOfMines"));
            var gridSize = int.Parse(Environment.GetEnvironmentVariable("GridSize"));
            var lives = int.Parse(Environment.GetEnvironmentVariable("NumberOfLives"));

            if (gridSize <= 1) throw new ArgumentException(nameof(gridSize), "Grid size must be greater than one.");
            if (lives <= 0) throw new ArgumentException(nameof(lives), "Lives must be greater than zero.");
            if (numberOfMines > (gridSize * gridSize)) throw new ArgumentException(nameof(numberOfMines), "There are more mines than positions in the grid.");

            gameData.Lives = lives;

            int i = 0;
            while (i < numberOfMines)
            {
                var rowCoordinate = new Random().Next(0, gridSize - 1);
                var columnCoordinate = new Random().Next(0, gridSize - 1);

                if (gameData.MineLocations.Any(x => x.Row == rowCoordinate && x.Column == columnCoordinate)) continue;

                gameData.MineLocations.Add(new GridPosition { Row = rowCoordinate, Column = columnCoordinate });

                i++;
            }

            gameData.GameState = GameState.InProgress;
        }

        /// <summary>
        /// Progresses the game in accordance with the user's instruction.
        /// </summary>
        /// <returns></returns>
        public string ProgressGame(GameData gameData)
        {
            var keyEntered = Console.ReadKey();
            var message = string.Empty;

            if (gameData.GameState == GameState.InProgress)
            {
                if (!ValidGamePlayCharacters.Contains(keyEntered.Key)) return UserMessages.InvalidUserInput;

                gameData.Moves++;
                message = _userInputHandlers[keyEntered.Key].UpdateCurrentGameData(gameData);
            }      

            return message;
        }
    }
}
