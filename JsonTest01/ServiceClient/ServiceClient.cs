using System;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lib
{
    public static class ServiceClient
    {
        public static async Task<DataTable> Get(string url)
        {
            using (WebClient svc = new WebClient())
            {
                try
                {
                    var response = await svc.DownloadStringTaskAsync(new Uri(url));
                    return DataTableJsonTool.Deserialize(response);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
