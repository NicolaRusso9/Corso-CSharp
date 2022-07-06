// See https://aka.ms/new-console-template for more information

//#error version
using CorsoCSharp.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ClassLibrary;
using BenchmarkDotNet.Running;

Console.WriteLine($"Versione sistema operativo: {Environment.OSVersion.VersionString}");

//new Reflection().starter();     // trovo la classe senza using perche inserito il namespace nelle include del proj 	  <Using Include="CorsoCSharp"/>
//new _01_Variable().starter();




//_16_Partial partialClass = new();
//partialClass.numero = "3";
//partialClass.testo = "ciao";

//new TestRecord().Starter();

//new _51_LinqMultiThread();

if (args.Length > 0)
{

}
else
{

}



#region Parte di EF Core
//Console.WriteLine($"Using {ProjectConstants.DataBaseProvider} database provider.");
//QueryingCategories();
//FilteredIncludes();
//ShowSQLQueryAndLogging();
//QueryingWithLike();

//if (AddProduct(categoryId: 1, productName: "Cioccolato", price: 3.00M))
//{
//    Console.WriteLine("Add product successful");
//}
//ListProducts();

//IncreaseProductPrice("Bob", 20M);
//DeleteProducts("Bob");
#endregion

#region Monitoraggio Risorse
//Console.WriteLine("Processing. Please wait");
//MonitoringLib.Start();

//// simulate a process that requires some memory resources
//int[] largeArrayOfInts = Enumerable.Range(start: 1, count: 10_000).ToArray();

//Thread.Sleep(new Random().Next(5,10) * 1000);
//MonitoringLib.Stop();

BenchmarkRunner.Run<_54_StringBenchmark>();
#endregion