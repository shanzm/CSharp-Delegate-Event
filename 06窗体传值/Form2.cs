using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _06窗体传值
{
    //在窗体2中声明一个委托
    public delegate void DelTest(string str);

    public partial class Form2 : Form
    {
        public DelTest _del;
        //注意，我们在Form2 中添加了一个字段，所以我们要修改默认的构造函数
        public Form2(DelTest ShowMsg)
        {
            InitializeComponent();
            this._del = ShowMsg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //我们知道，在Form1中使用From2的构造函数时，给字段_del的值是ShowMsg
            _del(textBox1.Text);
        }
    }
}
