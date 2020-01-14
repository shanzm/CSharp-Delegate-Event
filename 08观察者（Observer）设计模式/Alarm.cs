#region
// ===============================================================================
// Project Name        :    _08观察值_Observer_设计模式
// Project Description :   
// ===============================================================================
// Class Name          :    Alarm
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-9 21:06:00
// Update Time         :    2018-6-9 21:06:00
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
        /// 订阅器--- 警报器
        /// </summary>
        public class Alarm
        {
            public void MakeAlert(int param)
            {
                Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
            }
        }
    
}
