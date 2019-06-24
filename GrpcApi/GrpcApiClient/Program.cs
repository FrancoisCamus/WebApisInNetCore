using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number here must match the port of the gRPC server
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
            var client = new AuthorService.AuthorServiceClient(channel);


            var authors = client.GetAll(new Empty());
            var responseStream = authors.ResponseStream;
            while (await responseStream.MoveNext())
            {
                Console.WriteLine(ObjectDumper.Dump(responseStream.Current));
            }

            var author = client.GetAuthorById(new Int32Value { Value = 1});
            Console.Write(ObjectDumper.Dump(author));
 
            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
