using MineField.Common;
using System;
using System.Linq;

namespace MindField.Logic
{
    /// <summary>
    /// The base class to handle all valid user inputs.
    /// </summary>
    public abstract class BaseInputHandler
    {
        protected int GridSize => int.Parse(Environment.GetEnvironmentVariable("GridSize"));

        /// <summary>
        /// Determines if a mine has been hit, and decreases the number of lives a player has if so.
        /// </summary>
        /// <param name="currentPosition"></param>
        protected void CheckIfMineIsHit(GameData gameData, GridPosition currentPosition)
        {
            if (gameData.MineLocations.Any(x => x.Row == currentPosition.Row && x.Column == currentPosition.Column))
            {
                gameData.Lives--;
            }
        }

        /// <summary>
        /// Gets the message to be displayed to the user.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected string GetMessageForUser(GameData gameData, string message)
        {
            return string.Format(message, $"({gameData.CurrentPosition.Row}, {gameData.CurrentPosition.Column})", gameData.Lives, gameData.Moves);
        }
    }
}
