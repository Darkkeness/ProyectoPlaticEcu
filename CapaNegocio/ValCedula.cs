using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CapaDatos;
using CapaNegocio;

namespace Validaciones
{
    public class ValCedula
    {
        public string Encriptar(string texto)
        {
            try
            {

                string key = "qualityinfosolutions"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {

            }
            return texto;
        }
        public void enviarEmail(String email, String asusnto, String mensaje)
        {
            MailMessage mail = new MailMessage("darkkeness1999@gmail.com", email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("darkkeness1999@gmail.com", "kodoku1999");
            client.Host = "smtp.gmail.com";
            mail.Subject = asusnto;
            mail.Body = mensaje;
            client.Send(mail);

        }
        public bool ValidarCedula(String TxtNumeros)
        {
            int Numerico;
            var total = 0;
            int TamanoCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int provincia1 = 24;
            int Verificador = 6;

            if (int.TryParse(TxtNumeros, out Numerico) && TxtNumeros.Length == TamanoCedula)
            {
                int provincia = Convert.ToInt32(string.Concat(TxtNumeros[0], TxtNumeros[1], string.Empty));
                var digitosTres = Convert.ToInt32(TxtNumeros[2] + string.Empty);

                if ((provincia > 0 && provincia <= provincia1) && digitosTres < Verificador)
                {
                    var digitoVerificador = Convert.ToInt32(TxtNumeros[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) *
                                    Convert.ToInt32(TxtNumeros[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;


                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ?
                                                10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificador;
                }
                return false;
            }
            return false;
        }
    }
}