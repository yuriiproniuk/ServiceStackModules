using MyApp.ServiceModel.ClientB;
using ServiceStack;
using System;

namespace MyApp.ServiceInterface.ClientB
{
    public class ClientB: Service
    {
        public object Any(HelloClientB request)
        {
            return new HelloClientBResponse { Result = $"Hello, {request.NameClientB} B!" };
        }
    }
}
