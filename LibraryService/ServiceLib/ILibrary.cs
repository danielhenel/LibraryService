using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLib
{
    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        string GetData(int value);
    }
}
