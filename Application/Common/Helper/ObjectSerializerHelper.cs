using Newtonsoft.Json;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Helper
{
    public static class ObjectSerializerHelper
    {
        public static string Serialize(this IPayLoadObject obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
