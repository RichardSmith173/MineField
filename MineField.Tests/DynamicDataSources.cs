using MineField.Common;
using MineField.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Tests
{
    public static class DynamicDataSources
    {
        public static IEnumerable<object[]> GameManager_StartOfGame_SalienceChecks
        {
            get
            {
                yield return new object[]
                {
                        0,
                        0,
                        1,
                        typeof(ArgumentException)
                };

                yield return new object[]
                {
                        2,
                        2,
                        0,
                        typeof(ArgumentException)
                };

                yield return new object[]
                {
                        5,
                        2,
                        1,
                        typeof(ArgumentException)
                };
            }
        }

        public static IEnumerable<object[]> GameManager_StartOfGame
        {
            get
            {
                yield return new object[]
                {
                        2,
                        4,
                        1
                };
            }
        }

        public static IEnumerable<object[]> UpArrowHandler_UpdateCurrentGameData
        {
            get
            {
                yield return new object[]
                {
                        new GridPosition { Row = 2, Column = 2 },
                        new GridPosition { Row = 3, Column = 2 },
                        1,
                        GameState.InProgress,
                        4,
                        GameState.Finished,
                        "Game Over, you have run out of lives at position (3, 2), lives remaining: 0, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        3,
                        GameState.Finished,
                        "Well done, you have won at position (2, 2), lives remaining: 2, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        5,
                        GameState.InProgress,
                        "Your current status is: position (2, 2), lives remaining: 2, moves made: 0"
                };
            }
        }

        public static IEnumerable<object[]> DownArrowHandler_UpdateCurrentGameData
        {
            get
            {
                yield return new object[]
                {
                        new GridPosition { Row = 0, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        3,
                        GameState.InProgress,
                        "You are already at the bottom of the board. Current position (0, 2), lives remaining: 2, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 3, Column = 2 },
                        new GridPosition { Row = 2, Column = 2 },
                        1,
                        GameState.InProgress,
                        4,
                        GameState.Finished,
                        "Game Over, you have run out of lives at position (2, 2), lives remaining: 0, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        5,
                        GameState.InProgress,
                        "Your current status is: position (0, 2), lives remaining: 2, moves made: 0"
                };
            }
        }

        public static IEnumerable<object[]> LeftArrowHandler_UpdateCurrentGameData
        {
            get
            {
                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 0 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        3,
                        GameState.InProgress,
                        "You are already at the left edge of the board. Current position (1, 0), lives remaining: 2, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 2, Column = 3 },
                        new GridPosition { Row = 2, Column = 2 },
                        1,
                        GameState.InProgress,
                        4,
                        GameState.Finished,
                        "Game Over, you have run out of lives at position (2, 2), lives remaining: 0, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        5,
                        GameState.InProgress,
                        "Your current status is: position (1, 1), lives remaining: 2, moves made: 0"
                };
            }
        }

        public static IEnumerable<object[]> RightArrowHandler_UpdateCurrentGameData
        {
            get
            {
                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 7 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        3,
                        GameState.InProgress,
                        "You are already at the right edge of the board. Current position (1, 7), lives remaining: 2, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 2, Column = 2 },
                        new GridPosition { Row = 2, Column = 3 },
                        1,
                        GameState.InProgress,
                        4,
                        GameState.Finished,
                        "Game Over, you have run out of lives at position (2, 3), lives remaining: 0, moves made: 0"
                };

                yield return new object[]
                {
                        new GridPosition { Row = 1, Column = 2 },
                        new GridPosition { Row = 1, Column = 2 },
                        2,
                        GameState.InProgress,
                        5,
                        GameState.InProgress,
                        "Your current status is: position (1, 3), lives remaining: 2, moves made: 0"
                };
            }
        }
    }
}
