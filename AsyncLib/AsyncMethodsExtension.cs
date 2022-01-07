using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibAsync
{
    public class AsyncMethodsExtension
    {
        #region ContinueWith
        public async Task TaskContinue()
        {
            Console.WriteLine("Calisan Ilk Thread=>{0}",Thread.CurrentThread.ManagedThreadId);
            await new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith(
                  (data) =>
                  {
                      WorkWork(data);
                  });
        }

        private static void WorkWork(Task<string> data)
        {
            Console.WriteLine("Veri Uzunlugu==>{0}, Calisan Thread=>{1}",data.Result.Length,Thread.CurrentThread.ManagedThreadId);
        }

        public async Task TaskContinueSampleWithEtcJobs()
        {
            Console.WriteLine("Calisan Ilk Thread=>{0}",Thread.CurrentThread.ManagedThreadId);
            var mytask = new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith(WorkWork);
            //baska baska isler
            await mytask;
        }
        #endregion



        #region whenAll

        public class Content
        {
            public string Site { get; set; }
            public int Lenght { get; set; }
        }

        public async static Task TaskWhenAll()
        {
            List<Task<Content>> tasklist = new List<Task<Content>>();
            tasklist = getList();

            var contects = Task.WhenAll(tasklist.ToArray());
            var data = await contects;
            data.ToList().ForEach(x =>
            {
                Console.WriteLine("Calisan Site==>{0}   uzunluk==>{1}",x.Site,x.Lenght);
            });

        }

        public async static Task<Content> GetContent(string url)
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            c.Site = url;
            c.Lenght = data.Length;
            Console.WriteLine("Calisan ThreadId=>{0}",Thread.CurrentThread.ManagedThreadId);
            return c;
        }

        #endregion

        #region whenAny
        public async static Task TaskWhenAny()
        {
            List<Task<Content>> tasklist = new List<Task<Content>>();
            tasklist = getList();
            var firstData = await Task.WhenAny(tasklist.ToArray());
            Console.WriteLine($"{firstData.Result.Site}---{firstData.Result.Lenght}");
        }


        #endregion



        #region waitAll  //bloklama yapar.
        public async static Task TaskWaitAll()
        {
            List<Task<Content>> tasklist = new List<Task<Content>>();
            tasklist = getList();
            Stopwatch st = new Stopwatch();

            Console.WriteLine($"İşlemler Başlıyor.Saat={DateTime.Now.ToShortTimeString()}");
            st.Start();
            Task.WaitAll(tasklist.ToArray()); //İşlemler bitene kadar bir alt satıra geçmez. aslında asekron yapıda sekron bir işlem gibi çalışır.

            var val = Task.WaitAll(tasklist.ToArray(),3000);  //verilen sure kadar zamanda islem biterse true bitmezse false döner . performans takibi yapılabilir.

            st.Stop();
            Console.WriteLine($"İşlemler Bitti.Saat={DateTime.Now.ToShortTimeString()}  -- Gecen Sure={st.Elapsed.TotalSeconds} saniye");

        }

        #endregion

        #region waitAny   //bloklama yapar.
        public async static Task TaskWaitAny()
        {
            List<Task<Content>> tasklist = new List<Task<Content>>();
            tasklist = getList();
            Stopwatch st = new Stopwatch();

            Console.WriteLine($"İşlemler Başlıyor.Saat={DateTime.Now.ToShortTimeString()}");
            st.Start();


            var val = Task.WaitAny(tasklist.ToArray());  // ilk tamamlanan arkadaşın bilgilerini döner.
            var vale = Task.WaitAny(tasklist.ToArray(),300);  //verilen süre içerisinde ilk tamamlanan arkadaşın bilgilerini döner.


            Console.WriteLine($"Süresiz çalıştırıldığında dönen cevap  {tasklist[val].Result.Site}");
            Console.WriteLine($"Süresiz çalıştırıldığında dönen cevap  {tasklist[vale].Result.Site}");

            st.Stop();
            Console.WriteLine($"İşlemler Bitti.Saat={DateTime.Now.ToShortTimeString()}  -- Gecen Sure={st.Elapsed.TotalSeconds} saniye");

        }



        #endregion






        private static List<Task<Content>> getList()
        {
            Console.WriteLine("Main ThreadId=>{0}",Thread.CurrentThread.ManagedThreadId);
            List<string> lst = new List<string>();
            lst.Add("https://www.google.com/");
            lst.Add("https://www.amazon.com/");
            lst.Add("https://www.mynet.com/");
            lst.Add("https://www.oracle.com/");
            lst.Add("https://www.twitter.com/");
            lst.Add("https://www.hurriyet.com/");

            List<Task<Content>> tasklist = new List<Task<Content>>();
            lst.ToList().ForEach(x =>
            {
                tasklist.Add(GetContent(x));
            });
            return tasklist;
        }
    }
}
