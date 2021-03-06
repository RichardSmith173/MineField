using MineField.Common;
using MineField.Common.Enumerations;

namespace MindField.Logic
{
    /// <summary>
    /// The class to handle to a left arrow key press.
    /// </summary>
    public class LeftArrowHandler : BaseInputHandler, IUserInputHandler
    {
        /// <summary>
        /// Updates the game data to store the result of a left arrow key press.
        /// </summary>
        /// <returns></returns>
        public string UpdateCurrentGameData(GameData gameData)
        {
            var currentPosition = gameData.CurrentPosition;

            if (currentPosition.Column - 1 < 0)
            {
                return GetMessageForUser(gameData, UserMessages.OffTheLeftOfTheBoard);
            }

            currentPosition.Column--;

            CheckIfMineIsHit(gameData, currentPosition);

            if (gameData.Lives == 0)
            {
                gameData.GameState = GameState.Finished;
                return GetMessageForUser(gameData, UserMessages.EndOfGame);
            }
            else
            {
                return GetMessageForUser(gameData, UserMessages.Current_Status);
            }
        }
    }
}
