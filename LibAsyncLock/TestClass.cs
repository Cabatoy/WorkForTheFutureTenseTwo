using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAsyncLock
{
   
    public class ParallelExecutionTests
    {
       
        public async Task ParallelExecution()
        {
            await Task.WhenAll(Enumerable.Range(0,1).Select(SomeMethod));
        }

        private static async Task SomeMethod(int i)
        {
            var asyncLock = new AsyncLock();
            System.Diagnostics.Debug.WriteLine($"Outside {i}");
            await Task.Delay(100);
            using (await asyncLock.LockAsync())
            {
                System.Diagnostics.Debug.WriteLine($"Lock1 {i}");
                await Task.Delay(100);
                using (await asyncLock.LockAsync())
                {
                    System.Diagnostics.Debug.WriteLine($"Lock2 {i}");
                    await Task.Delay(100);
                }
            }
        }
    }
}
