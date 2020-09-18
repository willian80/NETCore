using System;
using RestSharp;
using Newtonsoft.Json;

namespace RestSharpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Restful客户端第三方RestSharpDemo测试";
            //方法二、使用第三方RestSharp
            var client = new RestSharp.RestClient("http://127.0.0.1:7788");
            var requestGet = new RestRequest("PersonInfoQuery/{name}", Method.GET);
            requestGet.AddUrlSegment("name", "王二麻子");
            IRestResponse response = client.Execute(requestGet);
            var contentGet = response.Content;
            Console.WriteLine("GET方式获取结果：" + contentGet);

            var requestPost = new RestRequest("PersonInfoQuery/Info", Method.POST);
            Info info = new Info();
            info.ID = 1;
            info.Name = "张三";
            var json = JsonConvert.SerializeObject(info);
            requestPost.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse responsePost = client.Execute(requestPost);
            var contentPost = responsePost.Content;
            Console.WriteLine("POST方式获取结果：" + contentPost);
            Console.Read();
        }
    }

    [Serializable]
    public class Info
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
