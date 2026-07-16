using Cake.Common.IO;
using Cake.Common.Tools.NuGet;
using Cake.Frosting;

[TaskName("Restore")]
[IsDependentOn(typeof(CleanTask))]
public sealed class RestoreTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.NuGetRestore(context.SolutionName);
    }
}