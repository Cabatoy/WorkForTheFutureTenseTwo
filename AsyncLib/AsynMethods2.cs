using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAsync
{
    public class AsynMethods2
    {

        /// <summary>
        /// islem cagrildiktan sonra baska islemlerde yapilabilir.
        /// </summary>
        /// <param name="path">Dosya Adresi verilmeli</param>
        /// <returns></returns>
        public async Task<string> GetReadAsyn(string path)
        {
            var asyncLock = new AsyncLock();
            using (StreamReader s = new StreamReader(path))
            {
                _ = Task.Delay(10000);
                Task<string> task = s.ReadToEndAsync();
                //burada başka işler yapılabilir.

                return await task;
            }
        }

        public Task<string> GetReadAsyncTwo(string path)
        {
            StreamReader s = new StreamReader(path);

            return s.ReadToEndAsync();

        }




        /// <summary>
        /// bir sonraki islem icin islemin bitmesi beklenir.
        /// </summary>
        /// <param name="path">Dosya Adresi verilmeli</param>
        /// <returns></returns>
        public string GetRead(string path)
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader(path))
            {
                Thread.Sleep(10000);
                data = s.ReadToEnd();
            }
            return data;
        }

    }
}
