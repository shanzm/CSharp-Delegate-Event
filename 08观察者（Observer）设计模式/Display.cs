#region
// ===============================================================================
// Project Name        :    _08观察值_Observer_设计模式
// Project Description :   
// ===============================================================================
// Class Name          :    Display
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-9 21:09:37
// Update Time         :    2018-6-9 21:09:37
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
    /// 订阅器---显示器
    /// </summary>
  
        // 显示器
        public class Display
        {
            //静态方法
            public static void ShowMsg(int param)
            { 
                Console.WriteLine("Display：水快烧开了，当前温度：{0}度。\n", param);
            }
        }
    
}
