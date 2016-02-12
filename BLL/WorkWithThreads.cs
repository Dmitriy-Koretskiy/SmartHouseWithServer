using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkWithThreads
    {
        public async Task Periodic(Action func, TimeSpan period, CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                func();

                await Task.Delay(period);
            }
        }
    }
}
