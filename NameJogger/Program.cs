using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BNSharp;
using BNSharp.BattleNet;
using BNSharp.Net;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NameJogger
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

        }

    }
}
