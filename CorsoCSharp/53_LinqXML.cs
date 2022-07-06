

using CorsoCSharp.EFCore;
using System.Xml.Linq;

namespace CorsoCSharp
{
    internal class _53_LinqXML
    {

        // Generate XML using LINQ
        void OutputProductAsXML()
        {
            using (NorthwindContext db = new())
            {
                Product[] productsArray = db.Products.ToArray();
                XElement xml = new("products",
                    from p in productsArray
                    select new XElement("product",
                    new XAttribute("id", p.ProductId),
                    new XAttribute("price", p.Cost!.Value),
                    new XElement("name", p.ProductName)));

                Console.WriteLine(xml.ToString());
            }
        }

        // Read XML using LINQ
        void ReadProductAsXML()
        {
            XDocument doc = XDocument.Load("fileXML.xml");

            var appSettings = doc.Descendants("appSettings")
                .Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key")?.Value,
                    Value = node.Attribute("value")?.Value
                }).ToArray();

            foreach(var item in appSettings)
                Console.WriteLine($"{item.Key} : {item.Value}");
            
        }
    }
}
