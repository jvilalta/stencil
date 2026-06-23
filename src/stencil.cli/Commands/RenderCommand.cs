using Scriban;
using System.CommandLine;

namespace stencil.cli.Commands
{
    internal class RenderCommand : Command
    {
        public RenderCommand() : base("render", "Render a template")
        {
            var templateOption = new Option<string>(
                name: "--template")
            {
                Description = "The path to the template file to render",
                Required = true
            };

            this.Options.Add(templateOption);
            var outputOption = new Option<string>(
                name: "--output")
            {
                Description = "The path to the output file",
                Required = true
            };
            this.Options.Add(outputOption);

            var dataOption = new Option<string>(
                name: "--data")
            {
                Description = "The path to the data file",
                Required = true
            };
            var dataTypeOption = new Option<DataTypeEnum>(
                name: "--data-type")
            {
                Description = "The type of the data file (json, yaml, xml)",
                Required = true
            };
            this.Options.Add(dataTypeOption);
            this.Options.Add(dataOption);
            this.SetAction(async (context) =>
            {
                var templatePath = context.GetValue(templateOption) ?? throw new ArgumentNullException("Template path is required");
                var outputPath = context.GetValue(outputOption) ?? throw new ArgumentNullException("Output path is required");
                var dataPath = context.GetValue(dataOption) ?? throw new ArgumentNullException("Data path is required");
                var dataType = context.GetValue(dataTypeOption);
                var template = Template.Parse(File.ReadAllText(templatePath));
                switch (dataType)
                {
                    case DataTypeEnum.TXT:
                        await ProcessTextData(template, dataPath, outputPath);
                        break;
                }
            });
        }

        private async Task ProcessTextData(Template template, string dataPath, string outputPath)
        {
            var lines = File.ReadAllLines(dataPath);
            using (var writer = new StreamWriter(outputPath))
            {
                await writer.WriteAsync(template.Render(new { Lines = lines }));
            }
        }
    }
}
