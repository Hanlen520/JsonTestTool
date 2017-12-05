using System;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using JsonTestClient.Util;
using Newtonsoft.Json.Serialization;

namespace Util
{
    class HttpUtil
    {
        CookieContainer cookie = new CookieContainer();

        public string HttpPost(string Url, string postDataStr)
        {
            string retString = string.Empty;
            HttpWebRequest request = null;
            try
            {
                //Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                //byte[] postDataByte = encode.GetBytes(postDataStr);
                byte[] postDataByte = System.Text.Encoding.Default.GetBytes(postDataStr);

                request = (HttpWebRequest)WebRequest.Create(Url);
                Thread.Sleep(250);
                request.Method = "POST";
                request.ContentType = "multi-part form data";
                request.ContentLength = postDataByte.Length;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(postDataByte, 0, postDataByte.Length);
                myRequestStream.Close();

                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.Default);
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                //JObject jo = JObject.Parse(retString);
                //string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();

                return retString;
            }
            catch (Exception ex)
            {
                if (request != null)
                {
                    request.Abort();
                }
                throw;
            }
            finally
            {
            }

        }

        public string HttpPostUTF8(string Url, string postDataStr)
        {
            string retString = string.Empty;
            HttpWebRequest request = null;
            try
            {
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                byte[] postDataByte = encode.GetBytes(postDataStr);

                request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataByte.Length;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(postDataByte, 0, postDataByte.Length);
                myRequestStream.Close();

                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                if (request != null)
                {
                    request.Abort();
                }
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally
            { }

        }

        public string HttpGet(string Url, string postDataStr)
        {
            string retString = string.Empty;
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                if (request != null)
                {
                    request.Abort();
                }
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally { }
        }

        /// <summary>
        /// 格式化json字符串，添加 "\r\n"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ConvertJsonString(string str)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }


        /// <summary>
        /// 通过对应的Json对象返回对应的Json String,内容为Request说明
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected internal string JsonStringCreator(string type)
        {
            string temp = string.Empty;
            try
            {
                //通过TreeView节点的Name，获取对应的枚举值
                JsonMethodType jsonMethodType = (JsonMethodType)Enum.Parse(typeof(JsonMethodType), type);
                JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
                //解析时忽略Null Value的属性
                jsonSetting.NullValueHandling = NullValueHandling.Ignore;
                //可以解析继承类
                jsonSetting.TypeNameHandling = TypeNameHandling.Auto;
                jsonSetting.ConstructorHandling = ConstructorHandling.Default;
                jsonSetting.Formatting = Formatting.None;
                jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //object tempObj= null;
                string tempJsonStr = string.Empty;
                switch (jsonMethodType)
                {
                    case JsonMethodType.Version:
                    case JsonMethodType.RunStatus:
                    case JsonMethodType.PlatList:
                    case JsonMethodType.PlatInfo:
                    case JsonMethodType.RmsFtpInfo:
                    case JsonMethodType.AllPlanSearch:
                    case JsonMethodType.StopPreview:
                        JsonObjVersion joV = new JsonObjVersion();
                        joV.method = type;
                        tempJsonStr = JsonConvert.SerializeObject(joV, jsonSetting);
                        break;
                    default:
                        break;
                }
                temp = ConvertJsonString(tempJsonStr);
                return temp;
            }
            catch(Exception ex)
            {
                return string.Format("An error occurred ", ex.Message);
            }
        }
    }
}
