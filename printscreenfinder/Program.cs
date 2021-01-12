using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace printscreenfinder
{
    class Program
    {
        static List<string> linkerl = new List<string>();
        static void Main(string[] args)
        {
            char[] harfler = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
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
                                            linkerl.Add(imgUrl);
                                            using (WebClient client = new WebClient())
                                            {
                                                client.DownloadFile(
                                                    new Uri(imgUrl),
                                                    @"resimler\" + Guid.NewGuid() + ".png");
                                            }
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
            Console.WriteLine("Olasılık: " + counter);
            Console.ReadKey();
        }
    }
}
