using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;


namespace Zenga.Web.Handler
{
    public partial class ValidCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //设定生成几位随机数
            string tmp = RndNum(4, 1);
            //存储随机数
            HttpCookie cookie = new HttpCookie("ValidCode");
            //将随机字符转用ＭＤ５加密
            cookie.Value = Md5(tmp, 16);
            Response.Cookies.Add(cookie);
            //生成校验码的图片
            ValidateCode(tmp);
        }
        public string RndNum(int VcodeNum, int type)
        {
            string Vchar;
            switch (type)
            {
                case 0:
                    Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
                    break;
                case 1:
                    Vchar = "0,1,2,3,4,5,6,7,8,9";
                    break;
                case 2:
                    Vchar = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
                    break;
                default:
                    Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
                    break;
            }
            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = "";
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                VNum += VcArray[rand.Next(VcArray.Length)];
            }
            return VNum;
        }
        public string Md5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            else//32位加密 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
        }
        public void ValidateCode(string checkCode)
        {
            //int iwidth = (int)(checkCode.Length * 13);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(55, 18);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.Silver);
            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Brown, Color.DarkCyan, Color.Purple };

            string[] font = { "Arial" };

            Random rand = new Random();
            //随机输出噪点
            for (int i = 0; i < 20; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //输出不同字体和颜色的验证码字符
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(c.Length);
                int findex = rand.Next(font.Length);

                Font f = new System.Drawing.Font(font[findex], 11, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                //字符上下位置不同
                int ii = 0;
                //if ((i + 1) % 2 == 0)
                //{
                //    ii = 1;
                //}
                g.DrawString(checkCode.Substring(i, 1), f, b, 1 + (i * 13), 1);
            }
            //输出到浏览器
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            this.Response.ClearContent();
            this.Response.ContentType = "image/Jpeg";
            this.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }
    }
}
