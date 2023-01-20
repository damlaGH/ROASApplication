namespace ROASApplication.Data
{
    public class FileOperations
    {
        private const string fileRoad = "data.txt";
        public static void Write(string data)
        {
            File.WriteAllText(fileRoad, data);
        }
        public static string Read()
        {   if(File.Exists(fileRoad))
            return File.ReadAllText(fileRoad);
            return string.Empty;
        }
    }
}