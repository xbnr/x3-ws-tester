﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace ConsoleWSTester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        
    }
}