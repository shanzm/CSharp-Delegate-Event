using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01委托定义
{
    ///定义：委托是C#中函数回调机制，就是c语言中的函数指针在面向对象中的封装；
    ///     它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递。
    ///     
    ///     委托和类相似，都是用户自定义的一种类型，只不过类表示的数据的集合，而委托表示的是一个或多个方法
    ///     
    ///理解：类比“string name ”，其中string 是一个类，定义了name参数所能代表的值的种类，也就是name参数的类型。
    ///
    ///作用与意义：种将方法动态地赋给参数的做法，可以避免在程序中大量使用If-Else(Switch)语句，同时使得程序具有更好的可扩展性。
    /// 
    ///使用方法：关键字 delegate
    ///         委托和所引用的方法必须保持一致：
    ///         1、参数个数、类型、顺序必须完全一致。
    ///         2、返回值必须一致。




    //声明一个委托指向一个函数,注意只是声明在同一个命名空间
    public delegate void DelSayhi(string name);


    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------------------------------------------法1
            //DelSayhi del=new DelSayhi (SayhiChinese );
            //☆☆☆☆☆☆☆☆☆☆☆☆注意函数名直接赋值给委托，不需要在函数名之后加括号
            //Sayhi("张三", del);
            //委托就是为把一个函数当参数，但这样不明显


            //------------------------------------------------------------------------------法2
            //可以直接把一个函数给委托
            //DelSayhi del = SayhiChinese;
            //☆☆☆☆☆☆☆☆☆☆☆☆☆注意函数名直接赋值给委托，不需要在函数名之后加括号
            //Sayhi("张三", del);


            //------------------------------------------------------------------------------法3
            //既然可以法2 ，那干脆直接如下，这样你就可以发现函数作为了参数
            //Sayhi ("张三", SayhiChinese);

            //------------------------------------------------------------------------------多播委托
            //委托可以将多个方法赋给同一个委托，或者叫将多个方法绑定到同一个委托，
            //这就是---多播委托
            //当调用这个委托的时候，将依次调用其所绑定的方法。在这个例子中，语法如下
            //DelSayhi del=new DelSayhi (SayhiChinese );
            //del += SayhiEnglish;//使用+=给此委托变量再绑定一个方法
            //Sayhi("张三", del);


            //-------------------------------------------------------------------------------取消绑定
            //既然给委托可以绑定一个方法，
            //那么也应该有办法取消对方法的绑定，很容易想到，这个语法是“-=”：
            //DelSayhi del = new DelSayhi(SayhiChinese);
            //del += SayhiEnglish;//使用+=给此委托变量再绑定一个方法
            //Sayhi("张三", del);

            //del -= SayhiChinese;//使用-=给此委托变量取消绑定一个方法
            //Sayhi("张三风", del);


            //不使用SayHi函数，在新建了了委托对象后直接使用委托作函数
            //注:当然我们知道可以在这里直接使用SayhiChinese和SayHiEnglish俩个函数，我们在这里就是举例子
            DelSayhi del = new DelSayhi(SayhiChinese);
            if (null != del)//注意调用委托的时候一定要先判断委托是否为空，为空时会抛异常
            {
                del("张三");
            }

            Console.ReadKey();

        }

        /// <summary>
        ///这个函数就是为了把下面两个函数SayhiChinese和SayhiEnglish统一起来
        ///我想在这个函数中调用这两个函数,也就是有一个函数作为参数，但具体哪一个不确定
        ///所以我定义了一个委托DelSayhi指向这两个函数
        /// </summary>
        /// <param name="name"></param>
        public static void Sayhi(string name, DelSayhi del)
        {
            del(name);
        }


        public static void SayhiChinese(string name)
        {
            Console.WriteLine("你好" + name);
        }

        public static void SayhiEnglish(string name)
        {
            Console.WriteLine("Hello" + name);
        }
    }
}
