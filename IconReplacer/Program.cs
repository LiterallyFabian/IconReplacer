using System.Diagnostics;

namespace IconReplacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string path = "./input";
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Input directory does not exist. Download an icon pack and put it in a folder named 'input' in the same directory as this program.");
                Console.ReadKey();
                return;
            }
            
            string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
            string icon = GetIcon();
            
            Directory.CreateDirectory("output");
            foreach (string file in files)
            {
                string output =  @".\output" + file.Replace(path, "");
                Console.WriteLine(output);
                
                if (File.Exists(output))
                {
                    File.Delete(output);
                }
                
                Directory.CreateDirectory(new FileInfo(output).DirectoryName ?? string.Empty);
                
                File.Copy(icon, output);
            }
            
            Console.WriteLine("Done. All icons have been replaced in a directory named 'output' in the same directory as this program.");
            Console.ReadKey();
        }
        
        private static string GetIcon()
        {
            string? path = null;
            
            while (path == null)
            {
                Console.Write("Enter icon path: ");
                path = Console.ReadLine()?.Trim('"');

                if (File.Exists(path)) continue;
                Console.WriteLine("File does not exist");
                path = null;
            }

            return path;
        }
    }
}