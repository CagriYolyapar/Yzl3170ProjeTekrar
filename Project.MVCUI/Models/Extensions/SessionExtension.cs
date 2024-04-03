using Newtonsoft.Json;

namespace Project.MVCUI.Models.Extensions
{
    public static class SessionExtension
    {
        public static void SetSession(this ISession session, string key, object value)
        {
            string stringObject = JsonConvert.SerializeObject(value);
            session.SetString(key, stringObject);
        }



        public static T GetSession<T>(this ISession session, string key) where T : class
        {
            string stringObject = session.GetString(key);
            if (!string.IsNullOrEmpty(stringObject))
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(stringObject);
                return deserializedObject;
            }
            return null;
        } 
    }
}
