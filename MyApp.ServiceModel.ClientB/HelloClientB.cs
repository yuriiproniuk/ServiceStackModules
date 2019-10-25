using ServiceStack;
using System;

namespace MyApp.ServiceModel.ClientB
{
    [Route("/helloB")]
    [Route("/helloB/{NameClientB}")]
    public class HelloClientB : IReturn<HelloClientBResponse>
    {
        public string NameClientB { get; set; }
    }

    public class HelloClientBResponse
    {
        public string Result { get; set; }
    }
}
