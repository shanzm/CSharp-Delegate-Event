using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07事件_案例
{
    class Program
    {
        /// <summary>
        /// 代码实际背景：
        /// 当铃声响，则老师和学生走出办公室
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Ring ring=new Ring ();
            Students student=new Students();
            Teachers teacher=new Teachers ();

            ring.doIt += new Ring.DoSomething(student.GoPlay);
            ring.doIt += new Ring.DoSomething(teacher.GoOffice);
            //一个事件可以有多个订阅者，也就是说一个事件可以绑定（注册）多个事件处理程序


            //执行引发事件的方法，这之后就会运行事件处理程序
            ring.RaiseEvent();

            Console.ReadKey();


        }
    }

    

    /// <summary>
    /// 发布者
    /// </summary>
    public class Ring
    {
        //声明委托
        public delegate void DoSomething();
        // 声明事件
        public event DoSomething doIt;
        // 默认的构造函数
        public Ring()
        {
        }
        // 引发事件的方法
        public void RaiseEvent()
        {
            Console.WriteLine("下课铃声响了.......");

            // 
            if (doIt !=null )
            {
                doIt(); //  如果有注册的对象,才调用它们的方法 
            }
        }
    }



    /// <summary>
    /// 订阅者1-----学生类
    /// </summary>
    public class Students
    {
        // 默认的构造函数
        public Students()
        {
        }

        //事件处理程序
        public void GoPlay()
        {
            Console.WriteLine("[学生]:下课了，出去玩了。");
        }
    }



    /// <summary>
    /// 订阅者2-----老师类
    /// </summary>
    public class Teachers
    {
        // 默认构造函数
        public Teachers()
        {
        }

         //事件处理程序
        public void GoOffice()
        {
            Console.WriteLine("[老师]:下课了，去办公室");
        }
    }

}
