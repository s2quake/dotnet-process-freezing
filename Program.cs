using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var json = GetString(args[0]);
        Console.WriteLine(json);
    }

    private static string GetString(string fileName)
    {
        var process = new Process();
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.FileName = $"jq";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.Arguments = $". -C \"{fileName}\"";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        process.WaitForExit();
        return process.StandardOutput.ReadToEnd();
    }
}