using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PostmanCollectionGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Any(a => a.Equals("--help") || a.Equals("-h") || a.Equals("/?"))) 
            {
                Console.WriteLine(@"
PostmanCollectionGenerator
A CLI tool to create postman collection from a folder full of request file and a collection template.

Arguments:
 arg0: sourceFolder
 arg1: destinationFolder
 arg2: collectionSource
 arg3: collectionName

Argument descritpions:
 sourceFolder: The folder with all the request file.
 destinationFolder: Where the collection generated will be located.
 collectionSource: The collection to start with. Use as a template to generate the new collection.
 collectionName: The name of the new collection.

Exemple:
PostmanCollectionGenerator.exe E:\frederic\Bureau\xmls E:\frederic\Bureau\ ""E:\frederic\Bureau\Default collection.postman_collection.json"" Generated.postman_collection.json
");

                return;
            }

            try
            {
                Generate(args);
            }
            catch (Exception? ex)
            {
                while (ex != null)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }

        static void Generate(string[] args)
        {
            var sourceFolder = args[0];
            var destinationFolder = args[1];
            var collectionSouce = args[2];
            var collectionName = args[3];

            Console.WriteLine($"Read and Deserialize {collectionSouce}");

            var collection = JsonSerializer.Deserialize<Models.PostmanCollection>(File.ReadAllText(collectionSouce));

            if (collection is null) throw new InvalidOperationException("collection cannot be null");

            var item0 = collection.item[0];

            collection.item = new System.Collections.Generic.List<Models.Item>();

            Console.WriteLine($"Enumerate {sourceFolder} files");

            foreach (var request in Directory.EnumerateFiles(sourceFolder))
            {
                Console.WriteLine(request);

                var clone = JsonSerializer.Deserialize<Models.Item>(JsonSerializer.Serialize(item0));

                if (clone == null) throw new InvalidOperationException("clone cannot be null");

                clone.request.body.raw = File.ReadAllText(request);

                collection.item.Add(clone);
            }

            Console.WriteLine($"collection.item.Count: {collection.item.Count}");

            var path = Path.Combine(destinationFolder, collectionName);

            File.WriteAllText(path, JsonSerializer.Serialize(collection, new JsonSerializerOptions
            {
                WriteIndented = true
            }));

            Console.WriteLine($"Collection saved: {path}");
        }
    }
}
