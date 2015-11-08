using System.Text;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using testUMD;
using System.Threading;
using System;

namespace testUnmanagedDLL {
    public class GoodDLL {

        private static Form1 oneForm;
        private static Thread appThread;

        public static string res = string.Empty;
        public static string res_close = string.Empty;

        [DllExport("GUI_Form", CallingConvention = CallingConvention.StdCall)]
        public static void GUI_Form() {
            appThread = new Thread(new ThreadStart(OpenForm));
            appThread.Start();
        }

        public static void OpenForm() {
            Application.Run(oneForm = new Form1());
        }

        [DllExport("Shutdown", CallingConvention = CallingConvention.StdCall)]
        public static void Shutdown() {
            if (null == oneForm)
                return;

            oneForm.Invoke(new Action(() => {
                oneForm.Close();
                oneForm.Dispose();
                oneForm = null;
            }));
            
        }

        [DllExport("Data_BidAsk", CallingConvention = CallingConvention.StdCall)]
        public static void Data_BidAsk(double Bid, double Ask, IntPtr Symbol)
        {
            if (null == oneForm)
                return;

            var sym = Marshal.PtrToStringAnsi(Symbol);
            oneForm.Invoke(new Action(() => {
                oneForm.SetBidAsk(Bid, Ask, sym);
            }));
        }

        [DllExport("Data_POST", CallingConvention = CallingConvention.StdCall)]
        public static void Data_POST(double Balance,double Equity, IntPtr charPos) {
            if (null == oneForm)
                return;

            var Pos = Marshal.PtrToStringAnsi(charPos);
            oneForm.Invoke(new Action(() => {
                oneForm.SetPOS(Pos);
                oneForm.SetInfo(Balance, Equity);
            }));
        }

        [DllExport("Get_NewOrder", CallingConvention = CallingConvention.StdCall)]
        public static IntPtr Get_NewOrder() {
            string temp = res;
            if (res != string.Empty) {
                res = string.Empty;
                return Marshal.StringToHGlobalUni(temp);
            }
            return Marshal.StringToHGlobalUni(res);
        }

        [DllExport("Get_CloseOrder", CallingConvention = CallingConvention.StdCall)]
        public static IntPtr Get_CloseOrder() {
            string temp = res_close;
            if (res_close != string.Empty)
            {
                res_close = string.Empty;
                return Marshal.StringToHGlobalUni(temp);
            }
            return Marshal.StringToHGlobalUni(res_close);
        }


        [DllExport("FormChangeTitle", CallingConvention = CallingConvention.StdCall)]
        public static void FormChangeTitle(string title) {
            if (null == oneForm)
                return;

            oneForm.Invoke(new Action(() => {
                oneForm.Text = title;
                oneForm.SetPOS(title);
            }));
        }
    }
}

