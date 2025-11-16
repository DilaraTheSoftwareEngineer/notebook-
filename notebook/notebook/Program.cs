using System;
using System.Windows.Forms;

namespace notebook
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run((Form)new Form1());
        }
    }
}