using System;
using System.Collections.Generic;
using System.Web;

using System.Web.Configuration;
using System.Configuration;
using System.Text;
using System.IO;
using System.Xml;


namespace Zenga.Web.Code
{

    /// <summary>
    /// Summary description for StringUtil
    /// </summary>
    public static class StringUtil
    {

        public static string GenerateSaveFileName(string strFileName)
        {
            string strNewFileName = "";
            string strFileEnd = "";
            string[] strArray = strFileName.Split('.');
            if (strArray.Length == 1)
                strNewFileName = "";
            else
            {
                strFileEnd = strArray[strArray.Length - 1];
            }

            strNewFileName += DateTime.Now.ToString("yyyyMMddhhmmssfff") + "." + strFileEnd;
            return strNewFileName;
        }

        public static string GetFileType(string fileName)
        {
            string[] array = fileName.Split('.');
            if (array.Length == 1)
                return null;
            else
            {
                return array[array.Length - 1];
            }
        }

        public static string GetFileNameByUrl(string URL)
        {
            string[] array = URL.Split('/');
            if (array.Length == 1)
                return URL;
            else
            {
                return array[array.Length - 1];
            }
        }


        public static string GetDirectoryByFilePath(string FilePath)
        {
            FileInfo fi = new FileInfo(FilePath);
            return fi.Directory.ToString() ;
           //return  FilePath.Substring(0,FilePath.Length - 1 - FilePath.LastIndexOf("\\"));    
        }

        public static string GetFileNameNoType(string fileName)
        {
            string[] array = fileName.Split('.');
            if (array.Length == 1)
                return array[0];
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var v in array)
                {
                    sb.Append(v + ".");
                }
                string strName = sb.ToString();
                strName = strName.Remove(strName.LastIndexOf('.'));
                return strName;
            }
        }

        public static bool isValidFileType(string fileName, string[] ValidTypes)
        {
            bool isValid = false;
            string[] array = fileName.Split('.');
            if (array.Length == 1)
                return isValid = false;
            else
            {
                for (int i = 0; i < ValidTypes.Length; i++)
                {
                    if (String.Compare(ValidTypes[i], array[array.Length - 1], StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        isValid = true;
                        break;
                    }
                }
            }
            //ConfigurationManager.AppSettings["SQLConnString"];

            return isValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PreExpress">前缀</param>
        /// <returns></returns>
        public static string GetOrderCode(string PreExpress)
        {
            Random rnd = new Random(100);
            string strEnd = DateTime.Now.ToString("yyyyMMddHHmmssffff") + rnd.Next();
            return PreExpress + strEnd;
        }

        public static string Xml2String(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
    }
}