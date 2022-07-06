namespace CorsoCSharp
{
    class _15_FunctionParam
    {
        public void Starter()
        {
            int test2 = 9;
            PassingParameters(optional:7, y:ref test2, z:out int test, x: 3);       // Call method with naming param. In this way order of variable is not important. Note that out variable is declared inline.
        }

        // Method withouth params
        public void PassingParameters()
        {
            return;
        }

        /// <summary>
        /// Method with same name but with different sign. This is an overload.
        /// </summary>
        /// <param name="x">variabile passata per valore, la sua modifica non comporta modifiche nella variabile originale.</param>
        /// <param name="y">variabile passata per riferimento, la sua modifica comporta modifiche nella variabile originale.</param>
        /// <param name="z">variabile passata per riferimento, la sua modifica è richiesta in quanto viene riconosciuto come parametro di output.</param>
        /// <param name="optional"> This variable is optional because it have declared defualt value. Optional params must be at last of the list of the method's param.</param>
        public void PassingParameters(int x, ref int y, out int z, int optional = 5)
        {
            z = 5;
        }

    }
}
