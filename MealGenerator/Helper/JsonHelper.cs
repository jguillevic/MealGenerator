using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace MealGenerator.Helper
{
    public static class JsonHelper
    {
        public static void Serialize(object data, Stream stream, bool isIndent = false)
        {
            using (var sw = new StreamWriter(stream, Encoding.UTF8, 512, true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    var serializer = JsonSerializer.CreateDefault();
                    serializer.Formatting = isIndent ? Formatting.None : Formatting.Indented;
                    serializer.Serialize(jw, data);
                }
            }
        }

        public static T Deserialize<T>(Stream stream)
        {
            using (var sr = new StreamReader(stream, Encoding.UTF8, false, 512, true))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    return JsonSerializer.CreateDefault().Deserialize<T>(jr);
                }
            }
        }
    }
}
