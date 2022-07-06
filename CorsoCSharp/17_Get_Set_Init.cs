namespace CorsoCSharp
{
    internal class _17_Get_Set_Init
    {

        public string Origin { get; set; }  // auto-syntax
        public string SetOrigin2 { get; set; } = $"Test";
        public string SetImmutable { get; init; } = $"Test";    // con init, una volta instanziato non può essere più modificato

        //public required string Obbligatorio { get; set; }  disponibile dalla versione .net 7 //  Required obbliga l'inizializzazione di una variabile

        // Indexers
        public Person this[int index]
        {
            get { return this[index]; }
            set { this[index] = value; }
        }


        #region READ ONLY PROPERTIES
        public string GetOrigin
        {
            get 
            {
                return $"Test";
            }
        }

        public string LambdaGetOrigin => $"Test";
        #endregion


        #region SETTABLE PROPERTIES
        public string SetOrigin
        {
            set
            {
                switch (value)
                {
                    case "red":
                        this.SetOrigin = value;
                        break;
                }
            }
        }
        #endregion
    }
}
