using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CaesarCipher
{
    public class Configuracoes
    {
        ModelCipher propriedade = new ModelCipher();
        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        string localDoArquivo =  @"\answer.json";
        string token = "";

        public string ObtendoJson()
        {
            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=" + this.token);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            File.WriteAllText(localDoArquivo, response.Content);
            return response.Content;
        }
        public void DecripitandoSalvandoArquivoJson(TextBox text)
        {
            var arquivo = File.ReadAllText(localDoArquivo);
            var arquivoLido = JsonConvert.DeserializeObject<ModelCipher>(arquivo);

            propriedade = arquivoLido;
            Decriptando();
            text.Text = arquivoLido.ToString();

            string texto = javaScriptSerializer.Serialize(propriedade);
            File.WriteAllText(localDoArquivo, texto);
        }
        private void Decriptando()
        {
            string texto = propriedade.cifrado is null ? throw new ArgumentNullException() : "";
            string textoCifrado = propriedade.cifrado.ToLower();
            for (int i = 0; i < textoCifrado.Length; i++)
            {
                int aux;
                int letra = textoCifrado[i];
                if (char.IsWhiteSpace(Convert.ToChar(letra)) || Char.IsNumber(Convert.ToChar(letra)))
                    aux = letra;
                else if (letra - casaParaPular >= numMinAlfabetoASCMenosNumCasas && letra - casaParaPular < numMinAlfabetoASC)
                    aux = (letra - casaParaPular) + tamanhoDoAlfabeto;
                else if (letra >= numMinAlfabetoASC && letra <= numMaxAlfabetoASC)
                    aux = letra - casaParaPular;
                else
                    aux = letra;

                texto += Char.ConvertFromUtf32(aux);
            }
            propriedade.decifrado = texto;
            propriedade.cifrado = propriedade.cifrado;
        }
        public void GerandoResumoCriptografico(TextBox text)
        {
            var arquivo = File.ReadAllText(localDoArquivo);
            var arquivoLido = JsonConvert.DeserializeObject<ModelCipher>(arquivo);

            propriedade = arquivoLido;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(propriedade.decifrado);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty).ToLower();

                propriedade.resumo_criptografico = hash;
            }
            text.Text = arquivoLido.ToString();
            string texto = javaScriptSerializer.Serialize(propriedade);
            File.WriteAllText(localDoArquivo, texto);
        }
        public void UploadDoArquivo()
        {
            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=" + this.token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("answer", localDoArquivo);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }

        public const int casaParaPular = 3;
        public const int numMaxAlfabetoASC = 122;
        public const int numMinAlfabetoASC = 97;
        public const int numMinAlfabetoASCMenosNumCasas = 94;
        public const int tamanhoDoAlfabeto = 26;
    }
}
