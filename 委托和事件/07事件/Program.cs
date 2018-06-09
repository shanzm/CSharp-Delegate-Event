using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07事件
{
    ///事件
    ///定义：事件类似异常，因为他们都是由对象引发的，并且可以由我们提供的代码来处理
    ///订阅一个事件的含义：是提供代码在事件发生时执行这些代码，这些代码称为事件处理程序


    ///我们都知道委托是类似c语言中的函数指针，是一种函数指针在OO中的封装，
    ///是一种函数回调机制（回调函数就是一个通过函数指针调用的函数。如果你把函数的指针（地址）作为参数传递给另一个函数，当这个指针被用来调用其所指向的函数时，我们就说这是回调函数。）；
    ///事件是用户与应用程序交互的基础，它是回调机制的一种应用。
    ///简而言之：委托的本质是引用类型，用于包装回调函数，委托用于实现回调机制；事件的本质是一个类型安全的（多播）委托，事件是回调机制的一种应用。


    ///事件和委托的关系
    ///事件的委托类似属性和字段,事件是对委托的封装，这句话意思就是：事件是一个类型安全的委托
    ///事件比委托有更多的限制
    ///1、事件只能同“+=”和“-=”来绑定方法（在事件中这个方法叫事件的处理程序），其实这这种绑定方法就是多播委托的绑定方法
    ///2、只能在类的内部调用（触发）事件（见第77行），但是委托就可以在类外像调用函数那样调用


    class Program
    {
        ///代码实际背景：
        ///当裁判的发令枪响起，触发事件，事件触发执行的动作就是运动员跑起来了
        ///裁判是发布者，触发事件的方法是发令枪响，运动员是事件的订阅者，事件发生后就开跑 
        static void Main(string[] args)
        {
            //实例化事件发布者
            RunSporters runsporter = new RunSporters();
            //实例化事件订阅者
            Judgment judgment = new Judgment();

            /// 订阅事件
            /// 订阅事件的语法如下：
            /// 事件名+=new 委托名（方法名）;
            /// 这里就是当事件eventRun发生了，他的订阅者RUnsport的Run函数开始执行
            /// 委托实例添加到产生事件对象的事件列表中去，这个过程又叫订阅事件。

            // 在发布器Judgment类中的委托delegateRun()调用订阅器RunSporters类中的事件处理程序Run()。
            judgment.eventRun += new Judgment.delegateRun(runsporter.Run);



            ///执行引发事件的方法，这句代码之后事件的订阅者中的事件处理程序Run()开始运行
            judgment.Begin();



            Console.ReadKey();
        }
    }




    /// <summary>
    /// 事件发布者，也称发布器（publisher）
    /// 发布器（publisher） 是一个包含事件和委托定义的对象。事件和委托之间的联系也定义在这个对象中。
    /// 发布器（publisher）类的对象调用这个事件，并通知其他的对象。
    /// </summary>
    class Judgment
    {

        //定义一个委托（这个委托在主函数中被赋值的函数，就是事件eventRunde的订阅者，也就是事件触发后执行的代码）
        public delegate void delegateRun();

        ///事件的声明与之前委托变量delegate1的声明唯一的区别是多了一个event关键字，且委托写“()”，事件不需要
        //定义一个事件
        public event delegateRun eventRun;

        //引发事件的方法
        //当方法Begin()被执行了，此时就会触发事件 eventRun
        public void Begin()
        {
            if (eventRun != null)
            {
                //被引发的事件
                eventRun();//☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆注意这里就是体现“事件只能在类的内部调用”的地方，你在这个发布者类之外没不能调用事件eventRun 
            }

        }
    }




    /// <summary>
    /// 事件订阅者，也称订阅器（subscriber）
    /// 订阅器（subscriber） 是一个接受事件并提供事件处理程序的对象。
    /// 在发布器（publisher）类中的委托调用订阅器（subscriber）类中的方法（事件处理程序）。
    /// 一个事件可以有多个订阅者，事件的发布者也可以是事件的订阅者。
    /// </summary>
    public class RunSporters
    {
        //事件处理程序
        public void Run()
        {
            Console.WriteLine("运动员跑起来了");
        }
    }

}
