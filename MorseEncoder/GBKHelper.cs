using System;
using System.Collections.Generic;
using System.Text;

namespace MorseEncoder
{
    public static class GBKHelper
    {
        static GBKHelper()
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// 汉字转区位码方法
        /// </summary>
        /// <param name="chinese">汉字</param>
        /// <returns>区位码</returns>
        public static string ChineseToCoding(string chinese)
        {
            string pCode = "";
            byte[] pArray = new byte[2];
            pArray = Encoding.GetEncoding("GB2312").GetBytes(chinese);//得到汉字的字节数组
            int front = (short)(pArray[0] - '\0') - 160;//将字节数组的第一位160
            int back = (short)(pArray[1] - '\0') - 160;//将字节数组的第二位160
            pCode = front.ToString("D2") + back.ToString("D2");//再连接成字符串就组成汉字区位码
            return pCode;
        }

        /// <summary>
        /// 区位码转汉字方法
        /// </summary>
        /// <param name="coding">区位码</param>
        /// <returns>汉字</returns>
        public static string CodingToChinese(string coding)
        {
            string chinese = "";

            byte[] pArray = new byte[2];
            string front = coding.Substring(0, 2);//区位码分为两部分
            string back = coding.Substring(2, 2);
            pArray[0] = (byte)(Convert.ToInt16(front) + 160);//前两位加160,存入字节数组
            pArray[1] = (byte)(Convert.ToInt16(back) + 160);//后两位加160,存入字节数组
            chinese = Encoding.GetEncoding("GB2312").GetString(pArray);//由字节数组获得汉字
            return chinese;
        }
    }
}
