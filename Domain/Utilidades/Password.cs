using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilidades
{
    public interface IPassword
    {
        Task<bool> VerificarPasswordAsync(string passwordIngresado, string passwordGuardado);
    }
    public class Password : IPassword 
    {

        public async Task<bool> VerificarPasswordAsync(string passwordIngresado, string passwordGuardado)
        {
            string[] partes = passwordGuardado.Split(':');

            if (partes.Length != 2)
                return false;

            string hashGuardado = partes[0];
            string saltBase64 = partes[1];

            byte[] salt = Convert.FromBase64String(saltBase64);

            using (var sha256 = SHA256.Create())
            {
                byte[] bytesCombinados = Encoding.UTF8.GetBytes(
                    passwordIngresado + Convert.ToBase64String(salt));

                byte[] hashIngresadoBytes = sha256.ComputeHash(bytesCombinados);

                string hashIngresado = Convert.ToBase64String(hashIngresadoBytes);

                return string.Equals(hashIngresado, hashGuardado);
            }
        }
    }
}
