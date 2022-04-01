using Autofac;
using MineField.Common;
using MineField.Grid.DepenencyInjection;

namespace MineField
{
    public static class ContainerSetup
    {
        public static IContainer Container { get; set; }

        public static void BuildContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterModule<GridModule>();

            Container = container.Build();
        }
    }
}
