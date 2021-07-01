using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seleniumtestportal
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Console.WriteLine("[ hwid ] Getting fingerprint...");
            string fingerprint = HWID.GetHwid();
            Console.WriteLine("[ hwid ] Done fingerprinting!");
            Console.WriteLine("[ db ] Initializing db..");
            if (MongoDB.initializeDatabase())
            {
                Console.WriteLine("[ db ] Initialized no problems..");
            }
            else
            {
                return; 
            }

            if(!MongoDB.validateHwid(fingerprint)) //if in base dont exists hwid of  computer 
            {
                Console.WriteLine("Unathorized");
                Thread.Sleep(1000);
                return;
            }

           // Console.WriteLine(HWID.Value());
            Console.Write("Link to testportal.com [test] -> ");
            Chrome.chujdll(Console.ReadLine());
            

        }
    }
}
