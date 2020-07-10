using Newtonsoft.Json;

namespace CicekSepetiCase.Core.Helpers
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
