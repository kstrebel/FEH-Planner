using Microsoft.AspNetCore.Http;
using Newtonsoft.Json; //using this bc of error with system.text.json
//using System.Text.Json;

namespace FEH_Planner.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
            //session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var valueJSON = session.GetString(key);

            if (string.IsNullOrEmpty(valueJSON))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(valueJSON);
                //return JsonSerializer.Deserialize<T>(valueJSON);
            }
        }
    }
}
