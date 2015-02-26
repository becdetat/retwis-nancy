using Retwis.Web.Plumbing;

namespace Retwis.Web
{
    using System;
    using Nancy.Hosting.Self;

    class Program
    {
        static void Main(string[] args)
        {
            var uri =
                new Uri("http://localhost:3579");

            var container = IoC.LetThereBeIoC();
            var bootstrapper = new Bootstrapper(container);
            using (var host = new NancyHost(uri, bootstrapper))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
