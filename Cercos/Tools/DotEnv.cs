using System;
using System.IO;

namespace Cercos.Tools
{
    public class DotEnv
    {
        public static void Load()
        {
            string filePath = string.Concat(Directory.GetCurrentDirectory(), "/", ".env");

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    var envVariable = line.Split('=');
                    Environment.SetEnvironmentVariable(envVariable[0], envVariable[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }
    }
}