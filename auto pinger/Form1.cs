using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace auto_pinger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string secili = listBox1.Items[listBox1.SelectedIndex].ToString();
            
                textBox1.Text = secili;
            listBox1.SelectedIndex =listBox1.SelectedIndex+1;
          
            
            
            label1.Text = PingHost(textBox1.Text).ToString();
            if(label1.Text=="True")
            {
                listBox4.Items.Add(textBox1.Text);
            }

            if(listBox1.SelectedIndex==listBox1.Items.Count-1)
            {
                timer1.Enabled = false;
                MessageBox.Show("BİTTİ :))");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                MessageBox.Show("başlangıç noktasını seçiniz....");
            }
            else
            {
                timer1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return  pingable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                listBox2.Items.Add(textBox2.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int sayi = listBox2.Items.Count;
            for (int a=0;a<sayi;a++)
            {
                listBox2.SelectedIndex = a;
                listBox1.Items.Add(listBox2.Text);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            int bas = int.Parse(textBox3.Text);
            int bit = int.Parse(textBox4.Text);
            if (bas > bit)
            {
                MessageBox.Show("BİTİŞ DEĞERİ BAŞLANGIÇ DEĞERİNDEN YÜKSEK OLMALIDIR");
            }
            else if (bas < bit)
            {
                if (bas < 0 || bit > 255 || bas > 255 || bit < 0)
                {
                    MessageBox.Show("BU ARALIKLARDA LOCAL İP BULUNAMAZ.örneğin başlangıç=0 bitiş =255. :)");
                }
                else
                for (int i = bas; i <= bit; i++)
                {
                    listBox2.Items.Add(label2.Text + i.ToString());
                }
            }

            

            else
            { MessageBox.Show("iki değer birbirine eşit olmamalıdır."); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
              if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen Sayısal Değerler Giriniz :)");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen Sayısal Değerler Giriniz :)");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = textBox5.Text;
            label5.Text = textBox5.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(timer2.Enabled == true)
            {
                timer2.Enabled = false;
            }
            if(timer2.Enabled==false)
            { timer2.Enabled = true; }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.Listeners.Clear();
            System.Diagnostics.Trace.Listeners.Add(
               new System.Diagnostics.TextWriterTraceListener(Console.Out));
        }
    }
}
