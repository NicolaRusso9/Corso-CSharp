
namespace CorsoCSharp
{
    /// <summary>
    /// If a class implements an interface it must implement all method that aren't implemented yet.
    /// 
    /// Common Interface        |   Short Description   
    /// IComparable                 Define a comparison method that a type implements to order or sort its instances
    /// IComparer                   Define a comparison method that a secondary type implements to order or sort instances of a primary type
    /// IDisposable                 Define a disposal method to release unmanaged resources more efficiently tha waiting for a finalizer
    /// IFormattable                Define a culture-aware method to format the value of an object into a string rapresentation
    /// IFormatter                  Define method to convert an object to and from stram of bytes for storage or transfer
    /// IFormatProvider             Define a method to format inputs based on a language and region
    /// </summary>

    // Custom Interface like game action
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop()
        {
            Console.WriteLine("Game stopped");
        }
    }

    public class _23_Interfaces : IPlayable
    {
        public void Pause()
        {
            Console.WriteLine("Game in pause");
        }

        public void Play()
        {
            Console.WriteLine("Play game");
        }
    }
}