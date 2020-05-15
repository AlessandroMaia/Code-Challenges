using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class ModelCipher
    {
        [JsonProperty("numero_casas")]
        public int numero_casas { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("cifrado")]
        public string cifrado { get; set; }

        [JsonProperty("decifrado")]
        public string decifrado { get; set; }
        [JsonProperty("resumo_criptografico")]
        public string resumo_criptografico { get; set; }

        public override string ToString()
        {
            return "Número de casas: " + this.numero_casas + Environment.NewLine +
                    "Token: " + this.token + Environment.NewLine +
                    "Cifrado: " + this.cifrado + Environment.NewLine +
                    "Decifrado: " + this.decifrado + Environment.NewLine +
                    "Resumo Criptografado: " + this.resumo_criptografico;
        }
    }
}
