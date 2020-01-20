﻿using CefSharp;
using CefSharp.WinForms;
using Sharptron.Core.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharptron
{
    static class SharptronApp
    {
        public static string AppDir { get; set; } = Application.StartupPath;
        public static string BinsDir { get; set; }
        public static string ResourcesDir { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            Cef.Initialize(settings);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(BinsDir = Path.Combine(AppDir, "bins")))
                Directory.CreateDirectory(BinsDir);

            if (!Directory.Exists(ResourcesDir = Path.Combine(AppDir, "resources")))
                Directory.CreateDirectory(ResourcesDir);

            // Find main entry point in "bins" folder

            // Run this when no valid binary has been found.
            BrowserWindow window = new BrowserWindow(Path.Combine(ResourcesDir, "default\\index.html"));
            window.SyncTitle = false;
            window.SetTitle("Sharptron");
            Application.Run(window.BaseWindow);

            //Application.Run(new BrowserWindowBase("http://ptb.discordapp.com/app"));
        }
    }
}
