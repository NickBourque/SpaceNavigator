using ChatLibrary;
//using LoggerLibrary;
using LogLib;
using Microsoft.Practices.Unity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //STEP 1 - Using constructor injection to introduce logger.
            //Application.Run(new ChatWindow(new Client(new Logger())));  


            //STEP 2 - Unity IOC Container implementation
            //UnityContainer container = new UnityContainer();
            //container.RegisterType<ILoggingService, Logger>();
            //Application.Run(container.Resolve<ChatWindow>());


            //STEP 2 - Ninject IOC Container implementation
            //StandardKernel kernel = new StandardKernel();
            //kernel.Bind<ILoggingService>().To<NickBourque_Logger>();
            //Application.Run(kernel.Get<ChatWindow>());


            //STEP 3 - NLog Logging & Unity
            //UnityContainer container = new UnityContainer();
            //container.RegisterType<ILoggingService, NickBourque_Logger>();
            //Application.Run(container.Resolve<ChatWindow>());


            //STEP 4 - Using Mike Sturdy's log4net logger (NOTE: must change in Client too).
            UnityContainer container = new UnityContainer();
            container.RegisterType<ILoggingService, MikeSturdy_logger>();
            Application.Run(container.Resolve<ChatWindow>());

        }
    }
}
