using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Common
{
    /// <summary>
    /// 数据加密解密
    /// </summary>
    public class SecurityHelper
    {
        #region MD5加密
        public static string MD5Encrypt16(string str)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(str)), 4, 8);
            return t2.Replace("-", "");
        }

        public static string MD5Encrypt32(string str)
        {
            string s = "";
            MD5 md5 = MD5.Create();
            byte[] bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < bs.Length; i++)
            {
                s = s + bs[i].ToString();
            }
            return s;
        }

        public static string MD5Encrypt64(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(s);
        }

        public static string md5(string str, int length)
        {
            if (!string.IsNullOrEmpty(str))
            {
                switch (length)
                {
                    case 16:
                        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
                    case 32:
                        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
                }
            }
            return string.Empty;
        }
        #endregion

        #region 数据解密
        /// <summary>
        /// DES数据解密
        /// </summary>
        /// <param name="targetValue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string targetValue, string key="")
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            var returnValue = new StringBuilder();
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(targetValue);
            // 通过两次哈希密码设置对称算法的初始化向量  
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                  Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥  
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                  .Substring(0, 8), "md5").Substring(0, 8));
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            foreach (byte b in ms.ToArray())
            {
                returnValue.AppendFormat("{0:X2}", b);
            }
            return returnValue.ToString();
        } 
        #endregion

    }
}
