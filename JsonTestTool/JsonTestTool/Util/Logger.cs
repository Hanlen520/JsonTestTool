using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTestTool.Util
{
    static class Logger
    {
        /// <summary>
        /// 测试开始时创建一个Log文件
        /// </summary>
        /// <param name="path">Log保存路径，文件名不需要传入，通过当前时间来自动生成</param>
        /// <returns></returns>
        public static string CreateLogFile(string path)
        {
            try
            {
                string name = string.Format("Log_{0}.txt", DateTime.Now.ToString("yyyyMMdd_HHmm_ssfff"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(Path.Combine(path, name)))
                {
                    File.Create(Path.Combine(path, name)).Close();
                }
                return Path.Combine(path, name);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 添加Log内容
        /// </summary>
        /// <param name="fullPath">日志文件完整路径</param>
        /// <param name="message">需要添加的日志内容</param>
        public static void WriteLog(string fullPath, string message)
        {
            try
            {
                //正常使用中，如果文件不存在只能说明被删除了，重新创建即可
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Close();
                }
                if (File.Exists(fullPath))
                {
                    using (StreamWriter writer = File.AppendText(fullPath))
                    {
                        writer.WriteLineAsync(message);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        /// <summary>
        /// 生成Report CSV文件，添加属性头：
        /// 编号,节点名称,测试时间,测试结果,测试请求,测试返回结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateReportCSV(string path)
        {
            try
            {
                string name = string.Format("JsonTestReport_{0}.csv", DateTime.Now.ToString("yyyyMMdd_HHmm_ssfff"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(Path.Combine(path, name)))
                {
                    File.Create(Path.Combine(path, name)).Close();
                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, name), true, Encoding.UTF8))
                {
                    //为CSV文件添加头
                    sw.WriteLine("编号,节点名称,测试时间,测试结果,测试请求,测试返回结果");
                    sw.Close();
                }
                return Path.Combine(path, name);
            }
            catch (ApplicationException aEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 生成自动测试Report，添加属性头：
        /// 编号,节点名称,测试时间,请求路径，请求方法，测试结果,测试请求,测试返回结果
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateAutoReportCSV(string path)
        {
            try
            {
                string name = string.Format("JsonAutoTestReport_{0}.csv", DateTime.Now.ToString("yyyyMMdd_HHmm_ssfff"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(Path.Combine(path, name)))
                {
                    File.Create(Path.Combine(path, name)).Close();
                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, name), true, Encoding.UTF8))
                {
                    //为CSV文件添加头
                    sw.WriteLine("编号,节点名称,测试时间,请求路径,请求方法,测试结果,测试请求,测试返回结果");
                    sw.Close();
                }
                return Path.Combine(path, name);
            }
            catch (ApplicationException aEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一行Report内容
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="message"></param>
        public static void WriteReport(string fullPath,string message)
        {
            try
            {
                //正常使用中，如果文件不存在只能说明被删除了，重新创建即可
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Close();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLineAsync(message);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                //do nothing
            }
        }

    }
}
