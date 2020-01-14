using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08观察者_Observer_设计模式
{
    ///观察者模式：
    ///Subject：监视对象，它往往包含着其他对象所感兴趣的内容。
    ///在本范例中，热水器就是一个监视对象，它包含的其他对象所感兴趣的内容，就是temprature字段，当这个字段的值快到100时，会不断把数据发给监视它的对象。

    ///Observer：监视者，它监视Subject，当Subject中的某件事发生的时候，会告知Observer，而Observer则会采取相应的行动。
    ///在本范例中，Observer有警报器和显示器，它们采取的行动分别是发出警报和显示水温。

    ///在本例中，事情发生的顺序应该是这样的：
    ///警报器和显示器告诉热水器，它对它的温度比较感兴趣(注册)。
    ///热水器知道后保留对警报器和显示器的引用。
    ///热水器进行烧水这一动作，当水温超过95度时，通过对警报器和显示器的引用，自动调用警报器的MakeAlert()方法、显示器的ShowMsg()方法。

    ///其实你可以发现观察者模式就是 和 发布-订阅模式 一样
    ///监视对象就是发布者，监视者就是订阅者



    class Program
    {
        /// <summary>
        /// 代码实际背景
        /// 热水器仅仅负责烧水，有一个温度字段temperature ，它不能发出警报也不能显示水温；
        /// 在水烧开时由警报器发出警报、
        /// 显示器显示提示和水温。
        /// </summary>
        static void Main(string[] args)
        {
            //注意我们不需要实例化Display类，为什么呢？因为我们只是使用它里面的一个静态方法，直接使用类名点
            Heater heater = new Heater();
            Alarm alarm = new Alarm();


            //注册方法(订阅事件）
            ///法1
            heater.BoilEvent += new Heater.BoilHandler(alarm.MakeAlert);

            ///法2
            ///heater.BoilEvent += (new Alarm()).MakeAlert;     //给匿名对象注册方法

            heater.BoilEvent += Display.ShowMsg;            //注册静态方法，静态类中的方法调用直接使用类名点

            heater.BoilWater();                            //触发事件，会自动调用注册过对象的方法

            Console.ReadKey();
        }
    }
}
