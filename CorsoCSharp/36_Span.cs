
namespace CorsoCSharp
{
    class _36_Span
    {
        // gli span sono un ottimo metodo per ottimizzare l'utilizzo della memoria quando si ha la necessità di creare
        // dei sotto insiemi di array. Creare un sottoinsieme con gli span non crea una copia in memoria ma offre
        // una finestra sull'array. Non funziona su collection perché gli indirizzi di memoria devono essere contigui

        public _36_Span(){
            string m = "samanta jones";

            int lengthOfFirst = m.IndexOf(' ');
            int lengthOfLast = m.Length - lengthOfFirst - 1;

            string firstName = m.Substring(
                startIndex: 0,
                length: lengthOfFirst
            );

            string lastName = m.Substring(
                startIndex: m.Length - lengthOfLast,
                length: lengthOfLast
            );

            ReadOnlySpan<char> nameAsSpan = m.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];
        }
    }
}
