using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EfProject.Helper
{
    public static class Dataseed
    {
        public static List<T> Seed<T>(string filePath) 
        {
           var authorsData = File.ReadAllText(filePath);
            if(String.IsNullOrWhiteSpace(authorsData)) return new List<T>();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<List<T>>(authorsData, options) ?? new List<T>();


        }
    }
}
