using System.Reflection;

namespace Navis.Repository.Mappings
{
    public class Mappings
    {
        private static bool _initialized = false;

        public static void RegisterAll()
        {
            var targetAssembly = Assembly.GetExecutingAssembly();
            var targetNamespace = typeof(BrandMapping).Namespace!;

            if (_initialized)
            {
                return;
            }

            var types = targetAssembly
                .GetTypes()
                .Where(x => x.Namespace == targetNamespace)
                .Where(x => x.IsClass && x.GetMethods().Any(x => x.Name == "Register"));

            foreach (var type in types)
            {
                var method = type.GetMethod("Register", BindingFlags.Public | BindingFlags.Static);
                method?.Invoke(null, null);
            }

            _initialized = true;
        }
    }
}
