using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PluginParser
{
    /// <summary>
    /// Load dynamic assemblies that instances a T type
    /// </summary>
    /// <typeparam name="T">Type to search in the assembly</typeparam>
    public class PluginParser<T>
    {
        public IReadOnlyCollection<T?> Parse()
        {
            var cfg = File.ReadAllText("__parserCfg.json");
            var directory = string.Empty;
            var list = new List<T?>();
            using (JsonDocument doc = JsonDocument.Parse(cfg))
            {
                JsonElement root = doc.RootElement;
                directory = root.GetProperty("PluginsDirectory").GetString();
            }
            var dlls = Directory.GetFiles(directory!, "*.dll", SearchOption.AllDirectories);
            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll);
                foreach (var type in assembly.GetTypes())
                    if (typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        list.Add((T?)Activator.CreateInstance(type));
            }
            return list;

        }
    }
}
