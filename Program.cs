using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Collections.Generic;
namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> lst = new List<dynamic>();
            string result = null;
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                result = client.DownloadString("https://jsonmock.hackerrank.com/api/transactions/search?userId=2"); //URI  

            }
            JObject studentObj = JObject.Parse(result);

            dynamic data = studentObj["data"];

            foreach (dynamic song in data)
            {


                if (song.location.id == 8)
                {

                    var ip = song.ip.ToString().Substring(0, song.ip.ToString().IndexOf("."));
                    if (Convert.ToInt32(ip) > 20 && Convert.ToInt32(ip) < 140)
                    {
                        lst.Add(song);
                    }

                }

            }
            double dresult=0;
            foreach (dynamic d in lst)
            {

                dresult = dresult + Convert.ToDouble(d.amount.ToString().Substring(1, d.amount.ToString().Length - 1));
            }
            Console.WriteLine(dresult);
            Console.ReadLine();
        }
    }
}
