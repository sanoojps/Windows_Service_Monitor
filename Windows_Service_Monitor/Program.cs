using System;
using System.Collections.Generic;
using System.Text;


namespace Windows_Service_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsServiceMonitor nuMON = 
                new WindowsServiceMonitor();

            while (true)
            {
                nuMON.StartMonitor();
                //Console.ReadLine();
                //System.Threading.Thread.Sleep(10000);

            }

           

        }
    }
}
