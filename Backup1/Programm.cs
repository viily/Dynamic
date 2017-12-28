// Licensed Material - Property of IBM
// © Copyright IBM Corp. 2003, 2009
using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_2_0;

namespace DynamicPages
{
    public class Programm
	{
        private contentManagerService1 cBICMS = null;

        [STAThread]
        static void Main(string[] args)
		{
            MainDlg dlgObject = new MainDlg(); ;
            SamplesConnect connectDlg = new SamplesConnect();

            if (args.Length != 0)
            {
                string biUrl = args[0];
                string userNamespace = args[1];
                string userName = args[2];
                string userPass = args[3];
                string reportPath = args[4];
                string contentPath = args[5];
                string gatewayUri = args[6];

                bool a = false;

                Console.SetWindowSize((int)Math.Round(Console.LargestWindowWidth*0.9),(int)Math.Round(Console.LargestWindowHeight*0.8));
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight*10);
                Console.WriteLine("Подключение к: "+biUrl);
                Console.WriteLine("Авторизация: "+userNamespace+"@"+userName+":"+userPass);

                if (connectDlg.makeCLConnection(ref biUrl, ref userName, ref userPass, ref userNamespace, ref a))
                {
                    Console.WriteLine("Подключение выполнено");
                    dlgObject.GUIMode = false;
                    dlgObject.setConnection(connectDlg.CBICMS);
                    Console.WriteLine("Генерация контента отчета \"" + reportPath + "\" из \"" + contentPath + "\"");
                    dlgObject.run(reportPath, contentPath, gatewayUri);
                }
                else
                {
                    Console.WriteLine("Не удалось подключиться");
                }
            }
            else
            {
                connectDlg.ShowDialog();
                if (connectDlg.IsConnectedToCBI() == true)
                {
                    dlgObject.setConnection(connectDlg.CBICMS);
                    dlgObject.ShowDialog();
                }
            }
            return;
		}
    } 
}

