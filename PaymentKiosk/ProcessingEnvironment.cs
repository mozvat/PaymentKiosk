using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentKiosk.Transactions
{
    public sealed class ProcessingEnvironment
    {
        private static volatile ProcessingEnvironment instance;
        private static object syncRoot = new Object();
        public string EndPoint { get;set; }
        private bool _debug;

        public bool Debug 
        {
            get 
            {
                return _debug;
            }
            set 
            {
                _debug = value;
                if (_debug)
                {
                    EndPoint = @"https://w1.mercurydev.net/ws/ws.asmx"; 
                }
                else
                {
                    EndPoint = @"https://w1.mercurypay.com/ws/ws.asmx";
                }
            } 
        }


        private ProcessingEnvironment()
        {
            //This should be read from a ConfigFile
            //Default Processing EndPoint is Production
            Debug = true;
        }

        public static ProcessingEnvironment Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ProcessingEnvironment();
                    }
                }
                return instance;
            }
        }
    }
}
