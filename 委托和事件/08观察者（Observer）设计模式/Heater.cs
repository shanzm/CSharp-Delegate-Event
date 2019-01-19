#region
// ===============================================================================
// Project Name        :    _08观察值_Observer_设计模式
// Project Description :   
// ===============================================================================
// Class Name          :    Heater
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-9 21:01:05
// Update Time         :    2018-6-9 21:01:05
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08观察者_Observer_设计模式
{


    /// <summary>
    /// 发布者---监视对象Subject
    /// </summary>
    public class Heater
    {
        private int temperature;
         public delegate void BoilHandler(int param);   //声明委托
         public event BoilHandler BoilEvent;            //声明事件


        // 烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;

                //当温度大于95度开始触发事件
                if (temperature > 95)
                {
                    //如果有对象注册
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature);  //调用所有注册对象的方法（事件处理程序）
                    }
                }
            }
        }
    }


}
