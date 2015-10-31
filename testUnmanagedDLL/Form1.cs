using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using testUnmanagedDLL;

namespace testUMD {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Lot = 1.0M;
        }

        private decimal lot;
        public decimal Lot {
            get {
                return lot;
            }
            set {
                lot = decimal.Round(value, 2);
                if (lot < 0M) {
                    lot = 0M;
                }
                txtLot.Text = lot.ToString("0.00");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            GoodDLL.res = "BUY;" + Lot.ToString();

        }

        public void SetPOS(string data) {
            //listBox1.Items.Add(data);
        }

        public void SetBid(double bid) {
            button2.Text = "BUY" + System.Environment.NewLine  + bid.ToString() ;
        }

        public void SetAsk(double ask) {
            button1.Text = "SELL" + System.Environment.NewLine + ask.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            GoodDLL.res = "SELL;" + Lot.ToString();
        }

        private void btnIncreaseLot_Click(object sender, EventArgs e) {
            Lot = decimal.Add(Lot, 0.01M);
        }

        private void btnDecreaseLot_Click(object sender, EventArgs e) {
            Lot = decimal.Subtract(Lot, 0.01M);
        }

        private void txtLot_TextChanged(object sender, EventArgs e) {
            decimal result;
            if (decimal.TryParse(txtLot.Text, out result)) {
                lot = result;
            }
        }
    }
}
