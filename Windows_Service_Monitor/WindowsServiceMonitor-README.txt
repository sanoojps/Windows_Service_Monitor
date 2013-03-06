Step 1) //using System.Management; add reference as well
        //using System.Diagnostics;
		
Step 2) //get ConnectionOptions to set the appropriate Impersonation levels
        
		private static ConnectionOptions connectionOptions = 
            new ConnectionOptions();
Step 3) //get computer name and WMI Namespace name

        private static string ComputerName = @"\\.";
        private static string Namespace = @"\root\cimv2";
        private static string ManagementPath = ComputerName + Namespace;
		
Step 4) //set the scope for the connection

        private static ManagementScope scope = 
            new ManagementScope(ManagementPath, connectionOptions);

			scope.Connect() can be used to connect to 
			//Connect to Management Scope to actual WMI Scope
			//if a WMI Query is to be done in the given Context 
			
Step 5)	//design the WQl Query String 

       private static string wqlQueryString = 
                      "SELECT *" +
				"  FROM __InstanceOperationEvent " + 
				"WITHIN  " + "2" +
				" WHERE TargetInstance ISA 'Win32_Process' " ;
				
Step 6) //create a ManagementEvent Watcher 

       private static ManagementEventWatcher eventWatcher =
           new ManagementEventWatcher(ManagementPath, wqlQueryString);
		   
Step 7) //set the Impersonation level to Impersonate to 
            //assume current Logged in User's Privileges

            connectionOptions.Impersonation =
                       System.Management.ImpersonationLevel.Impersonate;
					   
Step 8) //add an event handler for  ManagementEventWatcher 's EventArrived

			eventWatcher.EventArrived += 
                new EventArrivedEventHandler(this.OnEventArrived);

Step 9) //Start the eventWtacher

			eventWatcher.Start();

Step 10)//To Stop the eventWatcher()
			
			eventWacther.Stop();
			eventWatcher.Dispose();

Step 11) //Coding the event Handler 
				
				private void OnEventArrived(object sender, 
            System.Management.EventArrivedEventArgs e)
			{
			}

Step 12) //paramters
			
			//EventclassName - helps in determining the nature of the event

			string eventName = e.NewEvent.ClassPath.ClassName;
			
			eg: __InstanceCreationEvent
			    __InstanceDeletionEvent
				__InstanceOperationEvent
				__InstanceModificationEvent

			//ClassPath
            
			e.NewEvent.ClassPath.ToString()

			eg:\\.\root\CIMV2:__InstanceModificationEvent

			//to derive Property values of the class 
			//we need The ManagementBaseObject class of 
			//System.Management.ManagementObject
			//this makes it an Iterable object

			//TargetInstance --which is the WMI Class included in the WMI query

				ManagementBaseObject wmiDevice = 
                        (ManagementBaseObject)e.NewEvent["TargetInstance"];

						//this returns a System.Management.ManagementBaseObject
					TargetInstance = wmiDevice.ClassPath.ClassName 
					
					or 

					 ManagementBaseObject wmiD =
                      (ManagementBaseObject)e.NewEvent["TargetInstance"];

						TargetInstance = wmiD.ClassPath.ClassName 
					









			
				



				 
				 



					   		   										   