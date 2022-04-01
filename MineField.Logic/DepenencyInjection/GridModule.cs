using Autofac;
using Autofac.Core;
using MineField.Logic;
using MindField.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Grid.DepenencyInjection
{
    /// <summary>
    /// Responsible for adding all dependencies into the DI container within the current project.
    /// </summary>
    public class GridModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameManager>()
                .AsImplementedInterfaces()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.Name == "userInputHandlers",
                    (pi, ctx) => ctx.ResolveKeyed<Dictionary<ConsoleKey, IUserInputHandler>>("UserInputHandlers")));

            builder.RegisterInstance(new Dictionary<ConsoleKey, IUserInputHandler>
            {
                [ConsoleKey.UpArrow] = new UpArrowHandler(),
                [ConsoleKey.DownArrow] = new DownArrowHandler(),
                [ConsoleKey.LeftArrow] = new LeftArrowHandler(),
                [ConsoleKey.RightArrow] = new RightArrowHandler(),
            }).Keyed<Dictionary<ConsoleKey, IUserInputHandler>>("UserInputHandlers");

            base.Load(builder);
        }
    }
}
