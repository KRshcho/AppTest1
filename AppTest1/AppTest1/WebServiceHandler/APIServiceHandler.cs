using AppTest1.APIModel.Request;
using AppTest1.APIModel.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace AppTest1.WebServiceHandler
{
    public class APIServiceHandler
    {
        public ResPostOffice FindPostAddress(APIServiceConfig service, object obj)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                //webClient.Headers.Add("ApiKey", apikey);
                webClient.Encoding = Encoding.UTF8;

                try
                {
                    var uri = Extensions.Extensions.GetDescription(service);
                    var data = JsonConvert.SerializeObject(obj);

                    var result = webClient.UploadString(uri, data);                    
                    return JsonConvert.DeserializeObject<ResPostOffice>(result);
                }
                catch (WebException wex)
                {
                    return new ResPostOffice { ResultCode = "99", ResultMessage = wex.Message };
                }
                catch (Exception ex)
                {
                    return new ResPostOffice { ResultCode = "99", ResultMessage = ex.Message };
                }
            }
        }

        // 다른 클래스에서 접근할때 생성자 생성 안해도 접근 할 수 있도록 함
        #region singleton member

        public static APIServiceHandler Instance
        {
            get { return Nested.Instance; }
        }

        private static class Nested
        {
            public static readonly APIServiceHandler Instance = new APIServiceHandler();
        }

        #endregion
    }
}
