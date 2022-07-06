using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;

using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CorsoCSharp
{
    class _47_serialization
    {
        public void SerializeXML()
        {
            // New list of person to serialize
            List<Person> people = new()  {
                new Person(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14),
                },
                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1964, 3, 22),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName="Sally",
                            LastName = "Smith",
                            DateOfBirth = new DateTime(2000,1,11)
                        }
                    }
                },
            };

            // create object that will format a list of persona as xml
            XmlSerializer xs = new (people.GetType());

            // Create file to write to
            string path = Combine(CurrentDirectory, "people.xml");

            using(FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, people);
            }

            Console.WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(path).Length,
                arg1: path);

            // Display the serialized object graph
            Console.WriteLine(File.ReadAllText(path));
        }

        public void SerializeXMLCompact()
        {
            List<PersonCompact> people1 = new()
            {
                new PersonCompact(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14),
                },
                new PersonCompact(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1964, 3, 22),
                    Children = new HashSet<PersonCompact>
                    {
                        new PersonCompact(0M)
                        {
                            FirstName="Sally",
                            LastName = "Smith",
                            DateOfBirth = new DateTime(2000,1,11)
                        }
                    }
                },
            };

            // create object that will format a list of persona as xml
            XmlSerializer xs1 = new(people1.GetType());

            // Create file to write to
            string path1 = Combine(CurrentDirectory, "people1.xml");

            using (FileStream stream = File.Create(path1))
            {
                xs1.Serialize(stream, people1);
            }

            Console.WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(path1).Length,
                arg1: path1);

            // Display the serialized object graph
            Console.WriteLine(File.ReadAllText(path1));
        }

        public void DeserializeXML()
        {
            // Get file to read
            string path = Combine(CurrentDirectory, "people.xml");


            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                // deserialize and cast the object graph into a list of person
                List<Person>? loadedPeople = new XmlSerializer(new List<Person>().GetType()).Deserialize(xmlLoad) as List<Person>;
            }
        }

        public void SerializeNewtonsoftJSon()
        {
            string jsonPath = Path.Combine(CurrentDirectory, "people.json");

            // New list of person to serialize
            List<Person> people = new()
            {
                new Person(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14),
                },
                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1964, 3, 22),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName="Sally",
                            LastName = "Smith",
                            DateOfBirth = new DateTime(2000,1,11)
                        }
                    }
                },
            };

            // Serialization into json
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, people);
            }

            Console.WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(jsonPath).Length,
                arg1: jsonPath);

            // Display the serialized object graph
            Console.WriteLine(File.ReadAllText(jsonPath));
        }

        public void SerializeJSonNet()
        {
            Book csharp10 = new(title: "C# 10")
            {
                Author = "Mark J Price",
                PublishDate = new(year: 2021, month: 11, day: 9),
                Pages = 23,
                Created = DateTimeOffset.UtcNow
            };

            JsonSerializerOptions options = new()
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            string filePath = Path.Combine(CurrentDirectory, "book.json");

            using(Stream fileStream = File.Create(filePath))
            {
                JsonSerializer.Serialize<Book>(utf8Json: fileStream, value: csharp10, options);
            }

            Console.WriteLine("Written {0:N0} bytes of XML to {1}",
              arg0: new FileInfo(filePath).Length,
              arg1: filePath);

            // Display the serialized object graph
            Console.WriteLine(File.ReadAllText(filePath));
        }
    }

    public class Person
    {
        public Person() { }

        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person>? Children { get; set; }
        public decimal Salary { get; set; }
    }

    [Serializable]
    public class PersonCompact
    {
        public PersonCompact(decimal initialSalary)
        {
            Salary = initialSalary;
        }

        [XmlAttribute("FirstName")]
        public string? FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string? LastName { get; set; }

        [XmlAttribute("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [XmlAttribute("Children")]
        public HashSet<PersonCompact>? Children { get; set; }

        [XmlAttribute("Salary")]
        public decimal Salary { get; set; }
    }

    public class Book
    {
        public Book(string title)
        {
            Title = title;
        }


        public string Title { get; set; }       // this is a property, alway included
        public string? Author { get; set; }     // this is a property, alway included

        [JsonInclude]                           // include this field - required if you want include field when                IncludeFields = false
        public DateOnly PublishDate;

        [JsonInclude]                           // include this field - required if you want include field when                IncludeFields = false
        public DateTimeOffset Created;

        public ushort Pages;                    // IncludeFields = false    this field isn't included               

    }
}
