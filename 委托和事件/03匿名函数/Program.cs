using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03匿名函数
{

    ///匿名函数是一个“内联”语句或表达式，可在需要委托类型的任何地方使用。
    ///可以使用匿名函数来初始化命名委托，或传递命名委托（而不是命名委托类型）作为方法参数。
    ///共有两种匿名函数：
    ///1.匿名方法
    ///2.Lambda表达式




    class Program
    {
        public delegate void DelSayhi(string name);


        static void Main(string[] args)
        {
            //从项目01委托定义中，我们知道新建委托对象直接做函数
            //DelSayhi del = new DelSayhi(SayhiEnglish);//简写为DelsayHi del=SayHiEnglish;
            //del("张三");

            //那我们是不是可以直接结合匿名函数，把 SayhiChinese和SayhiEnglish直接省略，
            //在新建委托对象时建立一个相同功能的匿名函数
            //注意匿名函数的参数类型和个数，返回值必须和委托一样
            //DelSayhi del = delegate(string name) {  Console.WriteLine("Hello" + name); };
            //del("张三");
            //Console.ReadKey(); 


            //使用Lambda语句赋值委托
            DelSayhi del = (string name) => { Console.WriteLine("Hello" + name); };
            del("张三");
            Console.ReadKey();

        }

        //public static void SayhiChinese(string name)
        //{
        //    Console.WriteLine("你好" + name);
        //}

        //public static void SayhiEnglish(string name)
        //{
        //    Console.WriteLine("Hello" + name);
        //}
    }
}
