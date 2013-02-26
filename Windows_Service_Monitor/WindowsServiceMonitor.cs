using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Diagnostics;


namespace Windows_Service_Monitor
{
    public class WindowsServiceMonitor
    {
         #region WMIQueryInitialSettings
             private static ConnectionOptions _connectionOptions;
             //ManagementScope required if a WMI query is also required to be made
             private static ManagementScope _scope;
             private static ManagementEventWatcher _eventWatcher;
             
             private static string ComputerName = @"\\.";
             private static string Namespace = @"\root\cimv2";
             private static string ManagementPath = ComputerName + Namespace;

             //design the WQl Query String 

             private static string wqlQueryString =
                            "SELECT *" +
                      "  FROM __InstanceOperationEvent " +
                      "WITHIN  " + "1" +
                      " WHERE TargetInstance ISA 'Win32_Service' ";

        public WindowsServiceMonitor()
        { 
            //get ConnectionOptions to set the appropriate Impersonation levels
             _connectionOptions = new ConnectionOptions();
             
            //set the Impersonation level to Impersonate to 
             //assume current Logged in User's Privileges
             _connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            
            //set the scope for the connection ie the Class Path 
            _scope = new ManagementScope(ManagementPath, _connectionOptions);

            //create a ManagementEvent Watcher
            _eventWatcher =
           new ManagementEventWatcher(ManagementPath, wqlQueryString);

            //Handle the EventArrived event using the EventArrivedEventHandler

            _eventWatcher.EventArrived +=
               new EventArrivedEventHandler(this.OnEventArrived);
            //OnEventArrived - the event handler function
            // private void OnEventArrived(object sender, 
            //System.Management.EventArrivedEventArgs e)


        }
     #endregion
        

        //To start the Wmi Event Monitoring Loop
        public void StartMonitor()
        {
            // Start listening for events
            _eventWatcher.Start();
            // Do something while waiting for events
            System.Threading.Thread.Sleep(10000);

        }

        //To stop the Wmi Event Monitoring Loop
        //and Dispose the eventWatcher object
        public void Dispose()
        {
            _eventWatcher.Stop();
            _eventWatcher.Dispose();
        }



        //OnEventArrived - the event handler function
        private void OnEventArrived(object sender,
           System.Management.EventArrivedEventArgs e)
        {
            string eventClassName = e.NewEvent.ClassPath.ClassName;

            //this returns a System.Management.ManagementBaseObject 
            ManagementBaseObject _TargetInstance = 
                (ManagementBaseObject)e.NewEvent["TargetInstance"];

            //class name in the query eg: in thi case > Win32_Service
           string TargetInstance_Path_Class = 
               _TargetInstance.ClassPath.ClassName.ToString();

           string TargetInstance_Properties_Name =
               _TargetInstance.Properties["Name"].Value.ToString();
           
            //Console.WriteLine(TargetInstance_Path_Class);
            //Console.WriteLine(TargetInstance_Properties_Name);
           
           switch (TargetInstance_Path_Class)
           {
               case @"Win32_Service":
                   
                   //Console.WriteLine(TargetInstance_Path_Class);
                   //Console.WriteLine(TargetInstance_Properties_Name);
                   //System.Windows.Forms.MessageBox.Show(TargetInstance_Path_Class);

                   switch (TargetInstance_Properties_Name)
                   {
                       case @"Spooler":
                           //System.Windows.Forms.MessageBox.Show(eventClassName);
                           System.Diagnostics.Debug.WriteLine(eventClassName);
                           break;

                       default:
                           break;
                   }


                   break;
                   default:
                    break;
           }


   

       
            try
            {

            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }





    }
}
