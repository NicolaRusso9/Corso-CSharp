namespace CorsoCSharp
{
    class Padre
    {
        public string EmployCode { get; set; }
        public string HireDate { get; set; }

        public void WriteToConsole()
        {
            Console.WriteLine($"ciaoooooo");
        }

        public virtual decimal CalculatePay()        // Declared virtual so it can be overridden.
        {
            return 2;
        }

        public Padre()
        {
            Console.WriteLine("Ciao");
        }
    }

    class Figlio : Padre
    {
        public Figlio() : base(){}              // Constructor are not inherited, we must explicitly declare and explicitly call the base method

        public new void WriteToConsole()        // la keyword new nasconde il messaggio di warning override
        {
            base.EmployCode = "CDE";            // base richiama un valore della classe padre
        }

        public override decimal CalculatePay()  // Override base method. Only possible if base method is marked with virtual keyword
        {
            return 2 + 2;
        }
    }

    // Preventing hineritance from ClasseNonEreditabile
    sealed class ClasseNonEreditabile : Padre
    {
        public sealed override decimal CalculatePay()  // Override base method. Preventing override with sealed
        {
            return 2 + 2;
        }
    }


}
