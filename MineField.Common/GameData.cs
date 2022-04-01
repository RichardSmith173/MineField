using MineField.Common.Enumerations;
using System;
using System.Collections.Generic;

namespace MineField.Common
{
    /// <summary>
    /// Stores data relevant to the game.
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// The number of lives the player has.
        /// </summary>
        public int Lives { get; set; }

        /// <summary>
        /// The number of moves the player has taken.
        /// </summary>
        public int Moves { get; set; }

        /// <summary>
        /// The current position of the player.
        /// </summary>
        public GridPosition CurrentPosition { get; set; } = new GridPosition();

        /// <summary>
        /// The state of the game.
        /// </summary>
        public GameState GameState { get; set; }

        /// <summary>
        /// The locations of the mines.
        /// </summary>
        public List<GridPosition> MineLocations { get; set; } = new List<GridPosition>();
    }
}
