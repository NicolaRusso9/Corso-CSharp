using SixLabors.ImageSharp;                 // System.Drawing is really bad solution for modern application
using SixLabors.ImageSharp.Processing;

namespace CorsoCSharp
{
    /// <summary>
    /// Crea un'anteprima dell'immagine in scala di grigi. L'anteprima viene salvata nella directory dove sono presenti le immagini
    /// </summary>
    class _41_Images
    {
        static _41_Images()
        {
            string imagesFolder = Path.Combine(Environment.CurrentDirectory, "images");
            IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);

            foreach (string imagePath in images)
            {
                string thumbnailPath = Path.Combine(
                    Environment.CurrentDirectory, "images",
                    Path.GetFileNameWithoutExtension(imagePath)
                    + "-thumbnail" + Path.GetExtension(imagePath)
                );

                using (Image image = Image.Load(imagePath))
                {
                    image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
                    image.Mutate(x => x.Grayscale());
                    image.Save(thumbnailPath);
                }
            }
        }
    }
}
