﻿using _233606_Lab06;
using System;
using System.Windows.Forms;

namespace winforms_visual_lab
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}