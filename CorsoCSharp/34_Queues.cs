
namespace CorsoCSharp
{
    // QUEUE is FIFO element type
    internal class _34_Queues
    {
        public void starter()
        {
            Queue<string> queues = new();
            queues.Enqueue("Primo elemento");
            queues.Enqueue("Ultimo elemento");

            string element = queues.Dequeue();  // server handles next element in queues
            Console.WriteLine(element);         // Primo elemento

            element = queues.Dequeue();  // server handles next element in queues
            Console.WriteLine(element);         // Ultimo elemento

            queues.Peek();              // Ritorna il primo valore nella "lista" senza rimuoverlo


            PriorityQueue<string, int> queuePriority = new();
            queuePriority.Enqueue("pamela", 1);
            queuePriority.Enqueue("rebecca", 3);
            queuePriority.Enqueue("juliet", 2);
            queuePriority.Enqueue("ian", 1);


            OutputQueue("Current queue for vaccination: ", queuePriority.UnorderedItems);
        }


        public static void OutputQueue<TElement, TPriority>(string title, IEnumerable<(TElement, TPriority)> collection){

            foreach ((TElement, TPriority) item in collection)
            {
                Console.WriteLine($"{item.Item1}: {item.Item2} ");
            }
        }
    }
}
