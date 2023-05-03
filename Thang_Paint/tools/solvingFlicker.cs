using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thang_Paint.tools
{
    public  static class solvingFlicker
    {
        public static void setDoubleBuffered(this Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
    null, panel, new object[] { true }); ;
        }
    }
}
