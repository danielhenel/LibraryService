using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLib
{
    public class LibraryService : ILibrary
    {
        public string GetData(int value)
        {
            Console.WriteLine("Received number {0}",value);
            return string.Format("You entered: {0}", value);
        }
    }
}
