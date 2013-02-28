using System;
using System.Collections.Generic;
using System.Text;
using PaymentKiosk.Configurations;

namespace PaymentKiosk.Board
{
    public sealed class BoardFailures
    {
        private static volatile BoardFailures instance;
        private static object syncRoot = new Object();
        private static int _count = 0;
        private static int _threshold = 0;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public int Threshold
        {
            get { return _threshold; }
        }

        private BoardFailures()
        {
            int result;
            if (int.TryParse(BoardFailureThresholdConfig.GetConfig(), out result))
            {
                _threshold = int.Parse(BoardFailureThresholdConfig.GetConfig());
            }
        }

        public static BoardFailures Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new BoardFailures();
                    }
                }
                return instance;
            }
        }
    }
}
