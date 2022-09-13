using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using NanXingCangKu.Entity;
using System.Diagnostics;

namespace NanXingCangKu.Utils
{
    class HttpUtils
    {
        MissionOrder obj2 = new MissionOrder();
        /// <summary>
        /// 调用api返回json
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>         
        public string HttpApi(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            for (int i=0;i< request.Headers.Count;i++)
            {
                Console.WriteLine(request.Headers[i].ToString());

            }
            Debug.WriteLine("37");
            Debug.WriteLine(jsonstr);
            request.Method = type.ToUpper().ToString();//get或者post
            byte[] buffer = encoding.GetBytes(jsonstr);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            Console.WriteLine(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public string HttpPost(string url, object obj, string type)
        {
           
            try
            {
                Console.WriteLine(url);
                using (var httpClient = new HttpClient())
                {
                    HttpContent body = null;
                    if (obj != null)
                    {
                        Type t = obj.GetType();
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        foreach (PropertyInfo pi in t.GetProperties())
                        {

                            //var name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                            //var value = pi.GetValue(obj, null);//用pi.GetValue获得值
                            try
                            {

                                if (pi.PropertyType == obj2.GetType())
                                {
                                    foreach (PropertyInfo pi2 in pi.PropertyType.GetProperties())
                                    {
                                        try
                                        {
                                            dic.Add(pi2.Name, pi2.GetValue(obj, null).ToString());
                                        }
                                        catch
                                        {
                                            dic.Add(pi2.Name, string.Empty);
                                        }
                                    }
                                }
                                else
                                    dic.Add(pi.Name, pi.GetValue(obj, null).ToString());
                            }
                            catch
                            {
                                dic.Add(pi.Name, string.Empty);
                            }
                        }
                        body = new FormUrlEncodedContent(dic);
                    }
                    else
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("test", "1");
                        body = new FormUrlEncodedContent(dic);
                    }
                    //body = new FormUrlEncodedContent(null);
                    var response = httpClient.PostAsync(url, body).Result;
                    var data = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(data);
                    return data.Substring(1, data.Length - 2).Replace("\\", "");
                }
            }
            catch
            {
                MessageBox.Show("数据库连接失败，请检查网络连接");
                return "";
            }
        }
    }
}
