# ------ SSL Stuff ------ STARTS ------
. "$PSScriptRoot\..\BuildServerConfig\build-environment.ps1"

$path = $Env:Path;
if (-not $path.Contains($nugetpath)) {
    $path = $nugetpath + ";" + $path;
}
$Env:Path = $path
# ------ SSL Stuff ------ ENDS ------

dotnet run --project build/Build.csproj -- $args
exit $LASTEXITCODE;