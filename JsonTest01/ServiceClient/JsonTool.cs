using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib
{
    public static class JsonTool
    {
        public static T Deserialize<T>(string jsonString) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }

    public static class DataTableJsonTool
    {
        public static DataTable Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<DataTable>(jsonString);
        }

        public static string Serialize(DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }
    }

    public static class DataRowJsonTool
    {
        public static DataRow Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<DataRow>(jsonString);
        }

        public static string Serialize(DataRow table)
        {
            return JsonConvert.SerializeObject(table);
        }
    }
}
