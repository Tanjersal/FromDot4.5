using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Configuring.Infrastructure
{
    public class UptimeService
    {
        private Stopwatch timer;

        public UptimeService()
        {
            timer = new Stopwatch();
        }

        /// <summary>
        /// Display uptime in milliseconds
        /// </summary>
        public long Uptime => timer.ElapsedMilliseconds;
    }
}
