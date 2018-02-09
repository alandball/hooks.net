using System.IO;
using System.Reflection;

namespace HooksNet
{
    public static class TemplateUtil
    {
        public static string ReadTemplate(string path)
        {
            var fileStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"HooksNet.ScriptTemplates.{path}.sh");
            var template = new StreamReader(fileStream).ReadToEnd();
            return template;
        }
    }
}