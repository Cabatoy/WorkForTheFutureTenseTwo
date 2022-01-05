using System;
using System.Collections.Generic;
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
            var firstData = await Task.WhenAny(tasklist.ToArray());
            Console.WriteLine($"{firstData.Result.Site}---{firstData.Result.Lenght}");
        }


        #endregion

    }
}
