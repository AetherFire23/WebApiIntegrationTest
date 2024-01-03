using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Xunit.Abstractions;

namespace ControllerTest;

public static class FunObjLog
{
    public static void LogObject(this ITestOutputHelper self, object obj, string message = "")
    {
        var settings = new JsonSerializerSettings();
        settings.Formatting = Formatting.Indented;

        var serialized = JsonConvert.SerializeObject(obj, settings);

        var lines = serialized.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        if (!string.IsNullOrEmpty(message)) self.WriteLine(message);

        lines.ToList().ForEach(x => self.WriteLine(x));

        var separator = "     ---";

        self.WriteLine(separator);
    }
}
