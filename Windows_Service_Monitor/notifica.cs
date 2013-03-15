using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NotificationWindow;

namespace Windows_Service_Monitor
{
    public partial class notifica : Form
    {
        private WindowsServiceMonitor mon;
        public notifica()
        {
            InitializeComponent();

           // Thread T = new Thread(ShowPopup);
            //T.Start();
           // ShowPopup();
            this.WindowState = FormWindowState.Minimized;
            this.button1.PerformClick();

            this.mon = new WindowsServiceMonitor();

            this.mon.MessageRecieved +=
                new WindowsServiceMonitor.MessageReceivedHandler(mon_MessageReceived);

        }


        void mon_MessageReceived(string message)
        {
            ShowPopup();
        }


        public void ShowPopup()
        {
            //titleText
            popupNotifier1.TitleText =
                "Staples® EasyTech™ Small Business Class";

            //bodyColor
            popupNotifier1.BodyColor =
                System.Drawing.Color.White;

          
            //Titlefont
            popupNotifier1.TitleFont =
                new System.Drawing.Font("Microsoft Sans Serif", 
                    9.75F, 
                    ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //titleColor

            popupNotifier1.TitleColor = System.Drawing.Color.Black;

            //ContentFont

            popupNotifier1.ContentFont =
                 new System.Drawing.Font("Microsoft Sans Serif",
                     9.00F,
                     ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //ContentText

            popupNotifier1.ContentText =
                "Success!  Staples® EasyTech™ Small Business Class has detected and fixed a potential issue with this computer";


            popupNotifier1.ContentColor =
                 System.Drawing.Color.Black;
               

            popupNotifier1.ShowCloseButton = true;

            popupNotifier1.ShowOptionsButton = false;

            popupNotifier1.ShowGrip = true;

            //Delay in ms

            popupNotifier1.Delay = int.Parse("3000");

            //animation Interval

            popupNotifier1.AnimationInterval = int.Parse("10");

            //Animation Duration

            popupNotifier1.AnimationDuration = int.Parse("1000");

            //Title padding

            popupNotifier1.TitlePadding = new Padding(int.Parse("0"));

            //Content padding 

            popupNotifier1.ContentPadding = new Padding(int.Parse("2"));

            //Image Padding

            popupNotifier1.ImagePadding = new Padding(int.Parse("7"));

            //scroll

            popupNotifier1.Scroll = true;


            //showpopup

            popupNotifier1.Popup();

            //grip

            popupNotifier1.ShowGrip = false;

           //Image

            //popupNotifier1.Image =
              //  Properties.Resources._157_GetPermission_48x48_72
                ;


            popupNotifier1.ContentHoverColor =
                System.Drawing.Color.FromArgb(((int)(((byte)(100)))),
                ((int)(((byte)(118)))),
                ((int)(((byte)(135)))));

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPopup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

    }
}
