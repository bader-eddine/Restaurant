using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Admin.Helpers
{
    public class Helper
    {
    }
    public class RecetteApi {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44354/");
            return client;
        }
    }
}
