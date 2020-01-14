using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09使用扩展EventArgs传递参数
{

    public class ExtendEventArgs : EventArgs
    {
        public int Tem;
        public ExtendEventArgs(int tem)
        {
            this.Tem = tem;
        }
    }



    public class Heater
    {

        public event EventHandler<ExtendEventArgs> BoilEvent;

        public void BoilWater(int tem)
        {
            if (BoilEvent != null)
            {
                BoilEvent(this, new ExtendEventArgs(tem));
            }
        }



    
}


public class Display
{

    public static void ShowMsg(object sender, ExtendEventArgs e)
    {
        Console.WriteLine("Display：水快烧开了，当前温度：{0}度。\n", e.Tem);
    }
}


public class Alarm
{
    public void MakeAlert(object sender, ExtendEventArgs e)
    {
        Console.WriteLine("Alarm：嘀嘀嘀，水已经{0} 度了：", e.Tem);
    }
}


class Program
{
    static void Main(string[] args)
    {

        Heater heater = new Heater();
        Alarm alarm = new Alarm();



        heater.BoilEvent += alarm.MakeAlert;


        heater.BoilEvent += Display.ShowMsg;

        heater.BoilWater(96);

        Console.ReadKey();
    }
}

}

