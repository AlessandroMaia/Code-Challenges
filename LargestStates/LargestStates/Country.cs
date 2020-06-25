using System;
using System.Globalization;
using System.Linq;

namespace LargestStates
{
    public class Country
    {
        public State[] Top10StatesByArea()
        {
            return LoadSates()
                .OrderByDescending(e => e.Extension)
                .Take(10)
                .ToArray();
        }

        private State[] LoadStates()
        {
            return new State[]
            {
                new State("Acre", "AC", 164123.040d),
                new State("Alagoas", "AL", 27778.506d),
                new State("Amapá", "AP", 142828.521d),
                new State("Amazonas", "AM", 1559159.148d),
                new State("Bahia", "BA", 564733.177d),
                new State("Ceará", "BE", 148920.472d),
                new State("Distrito Federal", "DF", 5779.999d),
                new State("Espírito Santo", "ES", 46095.583d),
                new State("Goiás", "GO", 340111.783d),
                new State("Maranhão", "MA", 331937.450d),
                new State("Mato Grosso", "MT", 903366.192d),
                new State("Mato Grosso do Sul", "MS", 357145.532d),
                new State("Minas Gerais", "MG", 586522.122d),
                new State("Pará", "PA", 1247954.666d),
                new State("Paraíba", "PB", 56585.000d),
                new State("Paraná", "PR", 199307.922d),
                new State("Pernambuco", "PE", 98311.616d),
                new State("Piauí", "PI", 251577.738),
                new State("Rio de Janeiro", "RJ", 43780.172d),
                new State("Rio Grande do Norte", "RN", 52811.047d),
                new State("Rio Grande do Sul", "RS", 281730.223d),
                new State("Rondônia", "RO", 237590.547d),
                new State("Roraima", "RR", 224300.506),
                new State("Santa Catarina", "SC", 95736.165d),
                new State("São Paulo", "SP", 248222.362d),
                new State("Sergipe", "SE", 21915.116d),
                new State("Tocantins", "TO", 277720.520d)
            };
        }
    }
}

