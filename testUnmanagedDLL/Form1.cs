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
        private string order_id = string.Empty;
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

        private string[] setRows
        {
            set
            {
                dataGridView1.Rows.Add(value[0], value[1], value[2], value[3], value[4], value[5], value[6]);
            }

        }

        public void SetPOS(string data) {
            string[] order = data.Split('|');
            dataGridView1.Rows.Clear();
            for (int i = 0; i < order.Length-1; i++)
            {
                setRows = order[i].Split(';');

            }
        }

        public void SetBidAsk(double bid, double ask, string Symbol) {
            lb_Symbol.Text = Symbol;
            button2.Text = "BUY" + System.Environment.NewLine  + bid.ToString() ;
            button1.Text = "SELL" + System.Environment.NewLine + ask.ToString();
        }

        public void SetInfo(double Balance,double Equity) {
            lb_balance.Text = Balance.ToString();
            lb_Equity.Text = Equity.ToString();

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

        private void button3_Click(object sender, EventArgs e)
        {
            GoodDLL.res_close = "CLOSEALL";
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            order_id = row.Cells[0].Value?.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GoodDLL.res_close = order_id;
            dataGridView1.Rows.Clear();
        }
    }
}
