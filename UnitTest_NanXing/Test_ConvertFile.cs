using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UnitTest_NanXing
{
   
    /// <summary>
    /// Test_ConvertFile 的摘要说明
    /// </summary>
    [TestClass]
    public class Test_ConvertFile
    {
       static StringBuilder sbing = new StringBuilder();
        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

            //
            //TODO:  在此处添加构造函数逻辑
            //
            string oldpath0 = @"F:\项目\南兴果仁\资料\微信图片_20220222155213 - 副本.jpg";

            string oldpath = @"F:\项目\南兴果仁\资料\aaa.jpg";
            string newpath = @"F:\项目\南兴果仁\资料\test.jpg";

            ///打开现有文件以进行读取。
            FileStream s = File.OpenRead(oldpath0);
            BinaryReader br = new BinaryReader(s);
            char[] cbuff = new char[s.Length];
            int a = br.Read(cbuff, 0, cbuff.Length);
            //double b = br.ReadDouble();
            br.Close();
            s.Close();
            s = File.OpenRead(oldpath);
            byte[] buff = ConvertStreamToByteBuffer(s);
            //string baseStr=Convert.ToBase64String(buff);

            //sbyte[] sbuff= ToJavaBytes(buff);


            //StringBuilder result = new StringBuilder(buff.Length * 8);

            //foreach (byte b in buff)
            //{
            //   result.Append(Convert.ToString(b, 2).PadLeft(8, '0')+"\r\n");
            //}
            //Debug.WriteLine(result.ToString());

            string text = Encoding.UTF8.GetString(buff);


            byte[] buff2 = Convert.FromBase64String(text);
            //string text1 = result.ToString();
            string text2 = byteArrToBinStr(buff);

            //byte[] buffer = GetByteArray(sb.ToString());

            FileStream fstream = null;
            fstream = File.Create(newpath);
            BinaryWriter bw = new BinaryWriter(fstream);
            //WriteByChars(cbuff, bw);
            bw.Write(buff2);
            //Write(text, bw);
            //Write(text, bw);
            //WriteSBytes(sbuff, bw);
            string text3 = sbing.ToString();
            bw.Close();
            //fstream.Write(buffer, 0, buffer.Length);
            fstream.Close();
        }

        //private static void FromByteArray(int[] bufInt) 
        //{ int version = readInt16(bufInt); 
        //    int scope = readInt16(bufInt); 
        //    long key = readInt32(bufInt); 
        //}

        public static String byteArrToBinStr(byte[] b)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                //if()
                result.Append(Convert.ToString(b[i] & 0xff, 2).PadLeft(8, '0') + "\r\n");
            }
            return result.ToString().Substring(0, result.Length - 1);
        }

        public static bool WriteByChars(char[] cbyte, BinaryWriter bw)
        {
            try
            {
                char a;
                byte[] bits;
                sbyte[] bitsb;
                for (int i = 0; i < cbyte.Length; i++)
                {
                    a = cbyte[i];
                    bits = BitConverter.GetBytes(a);
                    byte[] temsb = { bits[0] };
                    bitsb = ToJavaBytes(temsb);

                    WriteSBytes(bitsb, bw);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool Write(string s,BinaryWriter bw)
        {
            try
            {
                char a;
                byte[] bits;
                sbyte[] bitsb;
                for(int i = 0; i < s.Length; i++)
                {
                    a = s[i];
                    bits = BitConverter.GetBytes(a);
                    byte[] temsb = { bits[0] };
                    bitsb = ToJavaBytes(temsb);
                    
                    WriteSBytes(bitsb, bw);
                }

                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static sbyte[] ToJavaBytes(byte[] bytes)
        {
            int len = bytes.Length;
            sbyte[] sbs = new sbyte[len];
            for(int i = 0; i < len; i++)
            {
                var b = bytes[i];
                if (b > 127)
                    sbs[len - 1 - i] = (sbyte)(b - 256);
                else
                    sbs[len - 1 - i] = (sbyte)b;

            }
            return sbs;
        }

        public static bool WriteSBytes(sbyte[] sbytes, BinaryWriter bw)
        {
            try
            {
                int len = sbytes.Length;
                for(int i = 0; i < len; i++)
                {
                    sbyte b = sbytes[i];
                    sbing.Append(Convert.ToString(b& 0xff, 2).PadLeft(8, '0') + "\r\n");
                    bw.Write(b);
                }
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// ConvertStreamToByteBuffer：把给定的文件流转换为二进制字节数组。
        /// </summary>
        /// <param name="theStream"></param>
        /// <returns></returns>
        private byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
        {
            int b1;
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
            while ((b1 = theStream.ReadByte()) != -1)
            {
                tempStream.WriteByte(((byte)b1));
            }
            theStream.Close();
            return tempStream.ToArray();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        
    }
}
