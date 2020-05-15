using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciSequence
{
    public class Sequence
    {
        public List<int> Fibonacci()
        {
            List<int> auxList = new List<int>();
            for (int auxContagem, auxArmazenagem = 0, auxNumAnterior = 1;
                    auxArmazenagem < 350;
                        auxContagem = auxNumAnterior, auxNumAnterior = auxArmazenagem, auxArmazenagem = auxContagem + auxNumAnterior)
            {
                auxList.Add(auxArmazenagem);
            }
            return auxList;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}
