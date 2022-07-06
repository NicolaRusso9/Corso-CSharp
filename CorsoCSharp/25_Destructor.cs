namespace CorsoCSharp
{
    class _25_Destructor : IDisposable
    {
        bool disposed = false;      // have resources been released?

        public _25_Destructor()     // Constructor
        {
            
        }

        ~_25_Destructor()           // Finalizer - Destructor
        {
            if (disposed) return;
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            // tell garbage collector it does not need tocall the finalizer
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            // deallocate unmanaged resource
            // ...

            if (disposing)
            {
                // deallocate other managed resources
                //...
            }

            disposed = true;
        }
    }
}
