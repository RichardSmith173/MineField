using MindField.Logic;
using Moq;
using System;
using System.Collections.Generic;

namespace MineField.Tests
{
    public class TestBase
    {
        public Mock<Dictionary<ConsoleKey, IUserInputHandler>> UserInputHandlers { get; set; } = new Mock<Dictionary<ConsoleKey, IUserInputHandler>>();
    }
}