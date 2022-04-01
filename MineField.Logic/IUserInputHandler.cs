using MineField.Common;
using System;

namespace MindField.Logic
{
    /// <summary>
    /// The interface to process the user's key press instructions.
    /// </summary>
    public interface IUserInputHandler
    {
        /// <summary>
        /// Updates the current game state in accordance with the user's key press instructions.
        /// </summary>
        /// <returns></returns>
        string UpdateCurrentGameData(GameData gameData);
    }
}
