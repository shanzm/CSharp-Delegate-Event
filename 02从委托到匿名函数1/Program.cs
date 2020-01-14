using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02委托到匿名函数
{
    public delegate string  DelProStr(string name);

    class Program
    {
        static void Main(string[] args)
        {
            string[] name = { "ABCfgh", "IJKimn", "OPQrst", "UVWyze" };

            ProStr(name ,ProStrLower);
             
            foreach (string item in name)
            {
               
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }


        public static void ProStr(string[] name, DelProStr del)
        {
            for (int i = 0; i < name.Length ; i++)
            {
                name[i] = del(name[i]);
            }
            
        }

        ///你会发现  "#region原来的函数"   中的三个函数的参数都一样，功能类似,只有对数组元素的操作不一样
        ///我们可以这样改写，然后统一为上面ProStr(string[] name, DelProStr del)一个函数
        ///其实最后你发现好像代码也没有少写多少，见项目02从委托到匿名函数2
        public static string ProStrUpper(string name)
        {
            return name.ToUpper();
        }
        public static string ProStrLower(string name)
        {
            return name.ToLower();
        }
        public static string ProStrSub(string name)
        {
            return name.Substring(0,3);
        }

        #region 原来的函数

        //public static void ProStrUpper(string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = name[i].ToUpper();
        //    }
        //}



        //public static void ProStrLower( string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = name[i].ToLower();
        //    }
        //}


        //public static void ProStrSub(string[] name)
        //{
        //    for (int i = 0; i < name.Length; i++)
        //    {
        //        name[i] = name[i].Substring (0,3);
        //    }
        //} 
        #endregion
    }
}
