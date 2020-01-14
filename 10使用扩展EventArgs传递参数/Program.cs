using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10使用扩展EventArgs传递参数
{
    ///代码背景
    ///汽车销售类CarDealer和顾客类Consumer
    ///CarDealer提供一个新车到达出发事件，Consumer类订阅该事件

    class Program
    {
        static void Main(string[] args)
        {
            CarDealer dealer = new CarDealer();
            Consumer consumer=new Consumer ("志铭");

            dealer.NewCarEvent += consumer.ConsumerReply;

            dealer.RaiseNewCarInfo("BMW");

            Console.ReadKey();

        }

       

        //扩展EventArgs类，添加一个Car属性用于传递数据
        public class CarInfoEventArgs : EventArgs
        {
            public CarInfoEventArgs(string car)
            {
                this.Car = car;
            }

            public string Car;
        }

        //发布类
        public class CarDealer
        {

            //public delegate EventHandler(object sender, CarInfoEventArgs e);//声明委托EventHandler
            //public event EventHandler NewCarEvent;//声明事件NewCarEvent

            //以上注释的两行可以用下面一行代替

            //声明事件NewCarIfno
            public event EventHandler<CarInfoEventArgs> NewCarEvent;


           

            //触发事件NewCarIfno的函数
            public void RaiseNewCarInfo(string car)
            {
                Console.WriteLine($"CarDealer :new car {car}");
                if (NewCarEvent != null)
                {
                    NewCarEvent(this, new CarInfoEventArgs(car));
                    //注意这里的参数this
                    //注意：事件的参数类型，声明事件时所用的委托的参数类型和事件处理程序的参数类型三者一样
                }
            }
        }

        //订阅类
        public class Consumer
        {
            public string Name;
            public Consumer (string name)
            {
                this.Name = name;
            }
           
            //事件处理程序，注意参数和事件的委托EventHandler<CarInfoEventArgs>一样
            public void ConsumerReply(object sender, CarInfoEventArgs e)
            {
                Console.WriteLine($"{this.Name }:car {e.Car }  very good!");
            }
        }

    }
}

