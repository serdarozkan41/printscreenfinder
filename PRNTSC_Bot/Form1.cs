using HtmlAgilityPack;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace PRNTSC_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] harfler = "efghijklmnopqrstuvwxyz".ToCharArray();
            char[] rakamlar = "0123456789".ToCharArray();
            int counter = 0;
            for (int i = 0; i < harfler.Length; i++)
            {
                char ilkharf = harfler[i];
                for (int j = 0; j < harfler.Length; j++)
                {
                    char ikinciharf = harfler[j];
                    for (int q = 0; q < rakamlar.Length; q++)
                    {
                        char ilkrakam = rakamlar[q];
                        for (int w = 0; w < rakamlar.Length; w++)
                        {
                            char ikincirakam = rakamlar[w];
                            for (int c = 0; c < rakamlar.Length; c++)
                            {
                                char ucuncurakam = rakamlar[c];
                                for (int a = 0; a < rakamlar.Length; a++)
                                {
                                    char dorduncurakam = rakamlar[a];

                                    string hedef =
                                        $"{ilkharf}{ikinciharf}" +
                                        $"{ilkrakam}{ikincirakam}" +
                                        $"{ucuncurakam}{dorduncurakam}";
                                    counter++;

                                    try
                                    {
                                        HtmlWeb web = new HtmlWeb();
                                        var htmlDoc = web.Load($"https://prnt.sc/{hedef}");

                                        string imgUrl = htmlDoc.GetElementbyId("screenshot-image").Attributes[1].Value;

                                        if (imgUrl != "//st.prntscr.com/2020/12/09/2233/img/0_173a7b_211be8ff.png")
                                        {

                                            pictureBox1.LoadAsync(imgUrl);
                                            Application.DoEvents();
                                            Thread.Sleep(1000);
                                        }
                                        Console.WriteLine(imgUrl);
                                    }
                                    catch (Exception)
                                    {


                                    }

                                    Console.WriteLine(hedef);
                                }
                            }
                        }
                    }
                }


            }
        }
    }
}
