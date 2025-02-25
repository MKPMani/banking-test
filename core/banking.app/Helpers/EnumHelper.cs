using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace banking.app.Helpers
{
    public class EnumHelper
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
