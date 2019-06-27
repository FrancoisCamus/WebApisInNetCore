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


            Console.Write("Fetching Author...");
            var author = await client.GetAuthorByIdAsync(new Int32Value { Value = 1 });
            Console.Write(ObjectDumper.Dump(author));
            Console.Write("Press any key to continue");
            Console.ReadKey();


            Console.Write("Add Author...");
            author = new Author
            {
                Id = 4,
                Name = "My New Author",
                Bio = "My New Author has just been created"
            };
            author = await client.AddAuthorAsync(author);
            Console.Write("Inserted !");
            Console.Write("Press any key to continue");
            Console.ReadKey();


            Console.Write("Fetching All Authors...");
            var authors = client.GetAll(new Empty());
            var responseStream = authors.ResponseStream;
            while (await responseStream.MoveNext())
            {
                Console.WriteLine(ObjectDumper.Dump(responseStream.Current));
            }

            Console.Write("Press any key to continue");
            Console.ReadKey();

            await channel.ShutdownAsync();

        }
    }
}
