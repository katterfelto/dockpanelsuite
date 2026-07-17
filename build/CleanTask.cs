using System.Linq;
using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Common.Tools.NuGet;
using Cake.Common.Tools.NuGet.Delete;
using Cake.Common.Tools.NuGet.List;
using Cake.Frosting;

[TaskName("Clean")]
public sealed class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CleanDirectory("../DockSample/bin");
        context.CleanDirectory("../Tests/bin");
        context.CleanDirectory("../Tests2/bin");
        context.CleanDirectory("../Tests3/bin");
        context.CleanDirectory("../WinFormsUI/bin");
    }
}