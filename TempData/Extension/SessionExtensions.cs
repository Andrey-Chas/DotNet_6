using System.Runtime.CompilerServices;
using System.Text.Json;
using TempData.Models;

namespace TempData.Extension
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            string valueToStore = JsonSerializer.Serialize<T>(value);
            session.SetString(key, valueToStore);
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
