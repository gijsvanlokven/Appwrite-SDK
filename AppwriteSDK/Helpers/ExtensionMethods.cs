using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AppwriteSDK.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToJson(this Dictionary<string, object> dict)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(dict, settings);
        }

        public static string ToQueryString(this Dictionary<string, object> parameters)
        {
            var query = new List<string>();

            foreach (var parameter in parameters.Where(parameter => parameter.Value != null))
            {
                if (parameter.Value is List<object>)
                {
                    foreach (object entry in (dynamic)parameter.Value)
                    {
                        query.Add(parameter.Key + "[]=" +
                                  Uri.EscapeUriString(entry.ToString() ?? throw new InvalidOperationException()));
                    }
                }
                else
                {
                    query.Add(parameter.Key + "=" +
                              Uri.EscapeUriString(parameter.Value.ToString() ?? throw new InvalidOperationException()));
                }
            }

            return string.Join("&", query);
        }
    }
}