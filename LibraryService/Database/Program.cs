using ClassLib;
using ServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryServiceContext context = new LibraryServiceContext();

            if (context.Database.EnsureCreated()) DataLoader.loadData();

            Uri baseAddress = new Uri("http://localhost:8000/LibraryService/");

            ServiceHost selfHost = new ServiceHost(typeof(LibraryService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ILibrary), new WSHttpBinding(), "LibraryService");
                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
