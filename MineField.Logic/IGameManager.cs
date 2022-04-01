using MineField.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Logic
{
    /// <summary>
    /// The interface for managing the game
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Starts the game and sets the grid up.
        /// </summary>
        void StartGame(GameData gameData);

        /// <summary>
        /// Progresses the game in accordance with the user's instruction.
        /// </summary>
        /// <returns></returns>
        string ProgressGame(GameData gameData);
    }
}
