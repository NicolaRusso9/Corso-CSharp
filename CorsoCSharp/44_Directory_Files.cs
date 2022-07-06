using static System.Environment;

namespace CorsoCSharp
{
    internal class _44_Directory_Files
    {

        public  _44_Directory_Files()
        {
            // Create folder name
            string newFolderName = Path.Combine(
                GetFolderPath(SpecialFolder.Personal),
                "Code", "chapter9", "NewFolder");

            if (Directory.Exists(newFolderName))
            {
                Directory.Delete(newFolderName, recursive: true);           // Delete folder
                Directory.CreateDirectory(newFolderName);                   // Crete folder
            }
            else
            {
                Directory.CreateDirectory(newFolderName);                   // Crete folder
            }

            string textFile = Path.Combine(newFolderName, "textFile.txt");  // Create filename with full path

            if (File.Exists(textFile))
            {
                File.Delete(textFile);                                      // Delete file
            }
            else
            {
                // creation a new text file and write a line to it
                StreamWriter sw = new StreamWriter(textFile);
                sw.WriteLine("file di prova");
                sw.Flush();
                sw.Close();
            }

            File.Copy(sourceFileName: textFile, destFileName: textFile, overwrite: true);       // Copy a file

            // Read from file
            StreamReader sr = File.OpenText(path: textFile);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            // Managing path
            string? folderName = Path.GetDirectoryName(newFolderName);
            string? fileName = Path.GetFileName(textFile);
            string? fileNameWithouthExt = Path.GetFileNameWithoutExtension(textFile);
            string? fileExt = Path.GetExtension(textFile);
            string? randomFileName = Path.GetRandomFileName();      // return only name, not create it
            string? tempFileName = Path.GetTempFileName();          // ready to use


            FileInfo fileInfo = new (textFile);
            long lenght = fileInfo.Length;          // bytes
            DateTime lastAccess = fileInfo.LastAccessTime;
            bool hasReadOnly = fileInfo.IsReadOnly;
            bool compressed  = fileInfo.Attributes.HasFlag(FileAttributes.Compressed);

            fileInfo.Attributes &= ~FileAttributes.ReadOnly;    // ???


            FileStream file = File.Open(textFile,
                mode: FileMode.OpenOrCreate,                // this control what you want to do with the file
                access: FileAccess.ReadWrite,               // this control what level of access you need
                share: FileShare.ReadWrite);                // this control locks on the file to allow other process the specified level of access

           

        }
    }
}
