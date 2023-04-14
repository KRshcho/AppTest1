using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AppTest1.WebServiceHandler
{
    public enum APIServiceConfig
    {
        [Description("http://192.168.0.24:5454/api/FindAddress/GetPostAddress")]
        API_POSTOFFICE,
        [Description("TEST")]
        API_KEY
    }    
}
