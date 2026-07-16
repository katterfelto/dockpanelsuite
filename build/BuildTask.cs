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
            .SetConfiguration(context.MsBuildConfiguration)
            .WithProperty("ThreePartVersion", $"{context.MajorVersion}.{context.MinorVersion}")
            .WithProperty("VersionRevision", context.SvnRevision);

        context.MSBuild(context.SolutionName, settings);

        context.FileWriteLines(
            $"{context.BuildTarget}/Revision.txt", 
            new string[]
            {
                "<RepositoryData>",
                $"  <Repository> {context.SvnUrl} </Repository>",
                $"  <Revision> {context.SvnRevision} </Revision>",
                $"  <BuildDate> {DateTime.Now} </BuildDate>",
                "</RepositoryData>"
            });
    }
}