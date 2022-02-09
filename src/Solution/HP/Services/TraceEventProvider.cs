using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP.Services
{
    public class TraceEventProvider
    {
        public TraceEventProvider(string key)
        {
           AppCenter.Start(key, typeof(Analytics));
        }
    }
}
