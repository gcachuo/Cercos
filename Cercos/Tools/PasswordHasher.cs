using System;
using System.Security.Cryptography;

namespace Cercos.Tools
{
    public class PasswordHasher
    {
        // Genera un hash seguro de una contraseña
        public static string HashPassword(string password)
        {
            // Genera una sal aleatoria
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Deriva una clave de la contraseña utilizando PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            // Obtiene el hash resultante
            byte[] hash = pbkdf2.GetBytes(20);

            // Combina la sal y el hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convierte el hash a una cadena base64
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        // Verifica si una contraseña coincide con su hash
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extrae la sal del hash
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Deriva una clave de la contraseña utilizando la misma sal y número de iteraciones
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compara los hashes
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}