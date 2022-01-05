using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibAsync;

namespace WorkerWinForms
{
    public partial class Form1 :Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(Object sender,EventArgs e)
        {

        }

        public void GetFileSync()
        {
            richTextBox1.Text = "";
            AsynMethods ss = new AsynMethods();
            var value = ss.GetRead("sample.txt");
            if (value != null)
                richTextBox1.Text = value;
        }
        public async Task<string> GetFileAsync()
        {
            richTextBox1.Text = "";
            AsynMethods ss = new AsynMethods();
            var value = ss.GetReadAsyn("sample.txt");
            return await value;
        }
        private void btnReadSync_Click(Object sender,EventArgs e)
        {
            Stopwatch ss = new Stopwatch();
            ss.Start();
            GetFileSync();
            ss.Stop();
            MessageBox.Show($"Gecen Sure=={ss.Elapsed.TotalSeconds}");
        }

        private async void btnReadDocAsync_Click(Object sender,EventArgs e)
        {
            Stopwatch ss = new Stopwatch();
            ss.Start();
            
            //cevap bekleniyorsa bu şekilde await isleminde islem bekler/
            var val = await GetFileAsync();
            
            
            //string data = string.Empty;
            //var val2 = GetFileAsync();
            ////bu arada baska islemler yapilabilir
            //data = await val2;

            richTextBox1.Text = val;
            ss.Stop();
            MessageBox.Show($"Gecen Sure=={ss.Elapsed.TotalSeconds}");
        }

        private void btnCounter_Click(Object sender,EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
