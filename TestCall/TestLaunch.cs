using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using testUnmanagedDLL;

namespace TestCall {
    public partial class TestLaunch : Form {
        public TestLaunch() {
            InitializeComponent();
        }
        


        private void button1_Click(object sender, EventArgs e) {
            GoodDLL.GUI_Form();
            
            MessageBox.Show("Continue method");
        }

        private void button2_Click(object sender, EventArgs e) {
            GoodDLL.FormChangeTitle(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e) {
            GoodDLL.Shutdown();
        }
    }
}
