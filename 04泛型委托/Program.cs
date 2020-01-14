using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04泛型委托
{
    #region 输出整形数组的最大值
    //public delegate int DelCompare(int num,int ma);
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int[] nums = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
    //        int max = GetMax(nums,delegate(int num,int ma){return num-ma;});
    //        Console.WriteLine(max);
    //        Console.ReadKey();
    //    }


    //    public static int GetMax(int[] nums ,DelCompare del)
    //    {

    //        int max = nums[0];
    //        for (int i = 1; i < nums.Length ; i++)
    //        {
    //            if (del(nums[i],max)>0 )
    //            {
    //                max = nums[i];
    //            }
    //        }
    //        return max;
    //    }
    //} 
    #endregion
    ///我们把上面的整形用T代替，使之能够替换任何类型，即泛型
    ///注意不仅变量的类型换为T，委托和函数也要在名字后面加上<T>
    
    public delegate int DelCompare<T>(T  num, T  ma);
    //注意委托的返回值应该是整形，你要知道这个返回值在GetMax函数中是用来与0比较的
    class Program
    {
        /// <summary>
        /// 实现不同类型的数组使用同一个函数取最大值
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///-------------------------------------------------------------double 类型的数组取最大值
            //double [] nums = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
            //double  max = GetMax<double>(nums, delegate(double num, double ma) { return (int)(num-ma); });



            ///-------------------------------------------------------------字符串类型数组取最长值
            string[] str = { "a", "a", "aaa" };
            string max=GetMax<string>(str, delegate(string num, string ma) { return num.Length - ma.Length; });


            Console.WriteLine(max);
            Console.ReadKey();
        }
        

        public static T  GetMax<T>(T[] nums, DelCompare<T> del)
        {
            
           T  max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (del(nums[i], max)>0)
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }
}
