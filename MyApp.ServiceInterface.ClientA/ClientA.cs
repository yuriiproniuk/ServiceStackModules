using MyApp.ServiceModel.ClientA;
using ServiceStack;
using System;

namespace MyApp.ServiceInterface.ClientA
{
    public class ClientA: Service
    {
        public object Any(HelloClientA request)
        {
            return new HelloClientAResponse { Result = $"Hello, {request.NameClientA} A!" };
        }
    }
}
