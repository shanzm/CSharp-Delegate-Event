using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05Lambda语句
{
    public delegate void Del1();
    public delegate void Del2(string str);
    public delegate int  Del3(string str);

    class Program
    {
        //lambda语句本质就是一个匿名函数
        static void Main(string[] args)
        {
            //Del1 del1 = delegate() { Console.WriteLine("无参数，无返回值"); };
            Del1 del1 = () => { Console.WriteLine("无参数，无返回值"); };

            //Del2 del2 = delegate(string name){int a=name.Length ;Console .WriteLine ("有参数,字符串长{0}",a);};
            Del2 del2 = (string name) => { int a = name.Length; Console.WriteLine("有参数,字符串长{0}", a); };

            //Del3 del3 = delegate(string name) { int a = name.Length; return a; };
            Del3 del3 = (string name) => { int a = name.Length; return a; };
            
            del1();
            del2("zhangsan");
            Console .WriteLine ( del3("zhangsan"));

            //关于Lambda在参数中的应用  
            List<int> listNums = new List<int>(){1,2,3,4,5,6,7,8,9,};
            listNums.RemoveAll(n => n > 7);//见提示Precidate <int> match，就是使用lambda输入一个条件；
            foreach (int item in listNums)
            {
                Console.WriteLine(item);
            }


             
           IEnumerable <int> aa= listNums .Where (n=> n>3);//根据提示写的返回值类型
            foreach (int item in aa)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
