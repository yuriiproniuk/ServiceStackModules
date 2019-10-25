using ServiceStack;
using System;

namespace MyApp.ServiceModel.ClientA
{
    [Route("/helloA")]
    [Route("/helloA/{NameClientA}")]
    public class HelloClientA : IReturn<HelloClientAResponse>
    {
        public string NameClientA { get; set; }
    }

    public class HelloClientAResponse
    {
        public string Result { get; set; }
    }
}
