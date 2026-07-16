using Cake.Common.Tools.NuGet.Push;
using Cake.Common.Tools.NuGet;
using Cake.Frosting;
using Cake.Common.IO;
using Cake.Common.Diagnostics;
using System.Linq;
using System.IO;

[TaskName("Publish")]
[IsDependentOn(typeof(PackTask))]
public sealed class PublishTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var packages = context.GetFiles("../**/DockPanel*.nupkg");

        if (context.PublishToNuGet && packages.Count > 0)
		{
            var settings = new NuGetPushSettings()
            {
                Source = context.NuGetServerUrl,
                ApiKey = context.NuGetServerKey
            };

            foreach (var package in packages)
            {
                PublishToNugetServer(
                    context, 
                    Path.Combine(package.GetDirectory().ToString(), package.GetFilenameWithoutExtension().ToString()), 
                    settings);
            }
        }
    }

    private void PublishToNugetServer(BuildContext context, string filename, NuGetPushSettings settings)
    {
        context.NuGetPush($"{filename}.nupkg", settings);

        if (context.PublishSourceToNuGet)
        {
            context.NuGetPush($"{filename}.snupkg", settings);
        }
    }
}