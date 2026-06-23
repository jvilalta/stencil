using stencil.cli.Commands;
using System.CommandLine;

namespace stencil.cli
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            // string basePath = "C:\\Users\\javie\\OneDrive\\js\\";
            var rootCommand = new RootCommand("Stencil CLI - A command line interface for template rendering");

            rootCommand.Add(new RenderCommand());

            var parseResult = rootCommand.Parse(args);

            await parseResult.InvokeAsync();
            return 0;
        }
    }
}
