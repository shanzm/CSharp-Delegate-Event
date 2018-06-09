using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02从委托到匿名函数2
{

    public delegate string DelProStr(string name);

    class Program
    {
        static void Main(string[] args)
        {
            string[] name = { "ABCfgh", "IJKimn", "OPQrst", "UVWyze" };

            ProStr(name, delegate(string item) { return item.ToUpper(); });
            //注意这一个参数：“ delegate(string item) { return item.ToUpper(); } ”  这就是匿名函数
            //当你的那个要作为另外一个函数的参数的方法就执行一次时，可以使用匿名函数
            foreach (string item in name)
            {

                Console.WriteLine(item);
            }

            Console.ReadKey();

        }


        public static void ProStr(string[] name, DelProStr del)
        {
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = del(name[i]);
            }

        }

        
        ///下面这三个函数我不写了，怎么处理呢？我在使用委托的时候在现定义,就是匿名函数
        //public static string ProStrUpper(string name)
        //{
        //    return name.ToUpper();
        //}
        //public static string ProStrLower(string name)
        //{
        //    return name.ToLower();
        //}
        //public static string ProStrSub(string name)
        //{
        //    return name.Substring(0, 3);
        //}

    }
}

