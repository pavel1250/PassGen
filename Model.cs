using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Media;

namespace PassGen
{
    public class Model
    {
        private ViewModel ViewModel = null;
        public void SetViewModel(ViewModel viewModel) { ViewModel = viewModel; }
        public string GeneratePassword(int len, bool withSymbols)
        {
            string Password = string.Empty;
            
            Random ran = new Random();
            Random type = new Random();
            
            for (int i = 0; i < len; i++)
            {
                int type_num = type.Next(0, 2);
                if (type_num == 0)
                {
                    int value = ran.Next(0, 9);
                    Password += value.ToString();
                    continue;
                }
                if (withSymbols == true)
                {
                    char value = (char)ran.Next(33, 125);
                    if (value == '\\' || value == '/')
                    {
                        value = (char)ran.Next(33, 125);
                        Password += value.ToString();
                    }
                    else
                    {
                        Password += value.ToString();
                    }
                    continue;
                }
                // int value=ran.Next(0,9);
                // PasswordText += value.ToString();
            }
            return Password;    
        }


        //Example thread
        private void ThreadInit()
        {
            __Thread = new Thread(StaticLogReadThreadEntryPoint);
            __Thread.IsBackground = true;
            __Thread.Start(this);
        }
        private Thread __Thread = null;
        private static void StaticLogReadThreadEntryPoint(object obj)
        {
            Debug.WriteLine("Protocol log read thread started");
            ((Model)obj).ThreadEntryPoint();
            Debug.WriteLine("Protocol log read thread terminated");
        }
        public void ThreadEntryPoint()
        {
            for (;;)
            {
                //In Thread
            }
        }
    }
}
