﻿using System.Text;
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


        [DllExport("Data_POST", CallingConvention = CallingConvention.StdCall)]
        public static void Data_POST(double Bid,double Ask ,string Pos) {
            
        }

        [DllExport("Get_NewOrder", CallingConvention = CallingConvention.StdCall)]
        public static string Get_NewOrder() {

            return null;
        }

        [DllExport("Get_CloseOrder", CallingConvention = CallingConvention.StdCall)]
        public static string Get_CloseOrder() {

            return null;
        }


        [DllExport("FormChangeTitle", CallingConvention = CallingConvention.StdCall)]
        public static void FormChangeTitle(string title) {
            if (null == oneForm)
                return;

            oneForm.Invoke(new Action(() => {
                oneForm.Text = title;
            }));
        }
    }
}

