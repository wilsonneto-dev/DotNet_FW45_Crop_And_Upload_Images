using AppImagensTeste.App.DI;
using AppImagensTeste.Domain.Util.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppImagensTeste
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel();
            kernel.Load(new DIContainer());
            MainForm mainForm = kernel.Get<MainForm>();

            Application.Run(mainForm);
        }
    }
}
