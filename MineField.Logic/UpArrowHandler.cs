using MineField.Common;
using MineField.Common.Enumerations;

namespace MindField.Logic
{
    /// <summary>
    /// The class to handle to an up arrow key press.
    /// </summary>
    public class UpArrowHandler : BaseInputHandler, IUserInputHandler
    {
        /// <summary>
        /// Updates the game data to store the result of an up arrow key press.
        /// </summary>
        /// <returns></returns>
        public string UpdateCurrentGameData(GameData gameData)
        {
            var currentPosition = gameData.CurrentPosition;

            currentPosition.Row++;

            CheckIfMineIsHit(gameData, currentPosition);

            if (gameData.Lives == 0)
            {
                gameData.GameState = GameState.Finished;
                return GetMessageForUser(gameData, UserMessages.EndOfGame);
            }
            else if (currentPosition.Row == GridSize - 1)
            {
                gameData.GameState = GameState.Finished;
                return GetMessageForUser(gameData, UserMessages.Congratulations);
            }
            else
            {
                return GetMessageForUser(gameData, UserMessages.Current_Status);
            }
        }
    }
}
