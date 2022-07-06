using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.IO.Compression;

namespace CorsoCSharp
{
    class _45_Stream
    {
        static string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };

        public void FileStream()
        {
            string textFile = Combine(CurrentDirectory, "stream.txt");

            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            foreach(string item in callsigns)
            {
                text.WriteLine(item);
            }

            text.Close();

            Console.WriteLine("{0} contains {1:N0} bytes.", 
                arg0: textFile,
                arg1: new FileInfo(textFile).Length);

            Console.WriteLine(File.ReadAllText(textFile));
        }

        public void XMLStream()
        {
            string xmlFile = Combine(CurrentDirectory, "streams.xml");
            FileStream xmlFileStream = File.Create(xmlFile);

            // wrap the file stream in an XML writer helper and automatically indent nested elements
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

            xml.WriteStartDocument();

            xml.WriteStartElement("callsigns");
            
            foreach(string item in callsigns)
            {
                xml.WriteElementString("callsigns", item);
            }

            xml.WriteEndElement();

            xml.Close();
            xmlFileStream.Close();

            Console.WriteLine("{0} contains {1:N0} bytes.",
                arg0: xmlFile,
                arg1: new FileInfo(xmlFile).Length);

            Console.WriteLine(File.ReadAllText(xmlFile));
        }

        /// <summary>
        /// XML compression.
        /// </summary>
        public void WorkWithCompression()
        {
            string gzipFilePath = Combine(CurrentDirectory, "stream.gzip");

            FileStream gzipFile = File.Create(gzipFilePath);

            using (GZipStream compressor = new(gzipFile, CompressionMode.Compress))
            {
                using(XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");

                    foreach(string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsigns", item);
                    }
                }
            }

            Console.WriteLine("{0} contains {1:N0} bytes.", gzipFilePath, new FileInfo(gzipFilePath).Length);
            Console.WriteLine("The compressed contents:");
            Console.WriteLine(File.ReadAllText(gzipFilePath));

            Console.WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);

            using (GZipStream decompressor = new (gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "callsigns")
                        {
                            reader.Read();
                            Console.WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// XML compression Brotli. PAG. 317
        /// </summary>
        public void CompressionBrotli(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";
            string filePath = Combine(CurrentDirectory, $"strams.{fileExt}");

            FileStream file = File.Create(filePath);

            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor)
            {
                using (XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");

                    foreach (string item in callsigns)
                    {
                        xml.WriteElementString("callsigns", item);
                    }
                }
            }

            Console.WriteLine("{0} contains {1} bytes.", filePath, new FileInfo(filePath).Length);
            Console.WriteLine(File.ReadAllText(filePath));

            Console.WriteLine("Reading compressed XML file:");
            file = File.Open(filePath, FileMode.Open);

            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }

            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "callsigns")
                        {
                            reader.Read();
                            Console.WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
        }
    }
}
