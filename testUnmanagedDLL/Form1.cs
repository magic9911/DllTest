using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testUMD {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {


        }

        public void SetPOS(string data) {
            listBox1.Items.Add(data);
        }

        public void SetBid(double bid) {
            button2.Text = "BUY" + System.Environment.NewLine  + bid.ToString() ;
        }

        public void SetAsk(double ask) {
            button1.Text = "SELL" + System.Environment.NewLine + ask.ToString();
        }
    }
}
