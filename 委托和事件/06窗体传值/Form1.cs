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
    /// <summary>
    /// 在窗体2中有一个TextBox，在窗体1中有一个了label
    /// 当窗体1的按钮点击时，弹出窗体2，
    /// 当窗体2按钮点击时，窗体2中Testbox 的值传给窗体1中的label
    /// 
    /// 窗体1中有给label赋值的方法ShowMsg但没有textBox的值
    /// 窗体2有TextBox的值，没有给label赋值的方法ShowMsg
    /// 
    /// 我们在窗体1的类中，使用了窗体2的构造函数，
    /// 所以我们就想能不能，通过构造函数吧窗体1中给label赋值的函数传给form2类中？
    /// 毫无疑问，当然是可以的，所以我们在Form2类中，定义了一个委托类型的字段，
    /// Form2的构造函数当然要给该字符赋值，而该字段的值是一个函数（因为该字段的类型是委托类型的）
    /// 当我们在Form1中使用Form2的构造函数时，要给一个函数作为参数，我们就把赋值函数ShowMsg给他当参数
    /// 这也就是实现了把Form1类中的赋值函数传到了Form2类中
    /// 
    /// 我们在Form2 中拿到了给label赋值的函数ShowMsg，
    /// 这时我们在Form2 类中调用我们就可以使用这个赋值方法了
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(ShowMsg );
          
            frm.Show();
        }

        void ShowMsg(string str)
        {
            label1.Text = str;
        }
    }
}
