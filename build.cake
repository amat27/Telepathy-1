#load build/paths.cake

var target = Argument("Target", "Build");
var configuration = Argument("Configuration", "Debug");

Task("Restore")
.Does(() =>
{
	NuGetRestore(Paths.SolutionFiles, new NuGetRestoreSettings { ArgumentCustomization = args => args.Append("-recursive") });
});

Task("Build")
.IsDependentOn("Restore")
.Does(() =>
{
	foreach (var path in Paths.SolutionFiles)
	{
		MSBuild(path, settings => settings.SetConfiguration(configuration).WithTarget("Build").SetPlatformTarget(PlatformTarget.MSIL));
	}	
});

Task("ReBuild")
.IsDependentOn("Restore")
.Does(() =>
{
	foreach (var path in Paths.SolutionFiles)
	{
		MSBuild(path, settings => settings.SetConfiguration(configuration).WithTarget("ReBuild").SetPlatformTarget(PlatformTarget.MSIL));
	}	
});

RunTarget(target);
