using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace CorsoCSharp
{
    class _43_FileSystem_Drives
    {

        public void FileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath", GetTempPath());

            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", ".System", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", ".ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", ".MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", ".Personal)", GetFolderPath(SpecialFolder.Personal));
        }

        public void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if(drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", 
                        drive.Name,
                        drive.DriveType,
                        drive.DriveFormat, 
                        drive.TotalSize, 
                        drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }
    }
}
