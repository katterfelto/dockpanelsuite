using System;
using Autofac;
using Cake.Common.Tools.MSBuild;
using Cake.FileHelpers;
using Cake.Frosting;

[TaskName("Build")]
[IsDependentOn(typeof(RestoreTask))]
public sealed class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var settings = new MSBuildSettings()
            .SetConfiguration(context.MsBuildConfiguration);

        context.MSBuild(context.SolutionName, settings);
    }
}