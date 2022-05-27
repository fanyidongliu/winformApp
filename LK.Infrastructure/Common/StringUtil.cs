using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LK.Infrastructure.Common
{
    public static class StringUtil
    {

        /// <summary>
        /// 从第一个匹配到的串(尾巴)开始到最后一个串(前一个字符处)截断
        /// </summary>
        public static string GetSp(this string line, string start, string end)
        {
            Regex reg = new Regex(start + "(.+)" + end);
            Match match = reg.Match(line);
            string value = match.Groups[1].Value;
            return value;
        }
    }
}
