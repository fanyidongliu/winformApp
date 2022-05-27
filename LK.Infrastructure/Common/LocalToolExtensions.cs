using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace LK.Infrastructure.Common
{
    public class LocalToolExtensions
    {
        /// <summary>
        /// 获取引用类型的内存地址方法
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetMemoryAddr(object o)
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
            return "0x" + addr.ToString("X");
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        public IPAddress GetIP(bool isPublic = false)
        {
            //内网(局域网)IP
            IPAddress LocalIP = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily.ToString().Equals("InterNetwork")).FirstOrDefault();
            if (isPublic)
                return LocalIP;

            //外网(公网)IP
            Stream stream = null;
            StreamReader streamReader = null;
            try
            {
                stream = WebRequest.Create("https://www.ipip5.com/").GetResponse().GetResponseStream();
                streamReader = new StreamReader(stream, Encoding.UTF8);
                var str = streamReader.ReadToEnd();
                int first = str.IndexOf("<span class=\"c-ip\">") + 19;
                int last = str.IndexOf("</span>", first);
                var ip = str.Substring(first, last - first);
                IPAddress PublicIP = IPAddress.Parse(ip);       //这里就得到了
                return PublicIP;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"出错了，{ex.Message}。获取失败");
            }
            finally
            {
                streamReader?.Dispose();
                stream?.Dispose();
            }
            return null;
        }
    }
}
