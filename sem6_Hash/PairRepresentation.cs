using System;

namespace sem6_Hash
{
    //Клас, що буде представляти собою пару чисел які нам потрібні
    //і зберігатимемо об'єкт цього класу в в словнику (в класі ArrayRepresentation)
    public class PairRepresentation
    {
        private int first;
        private int second;

        public PairRepresentation( int first, int second)
        {
            this.first = first;
            this.second = second;
        }
        public string ShowPair(int[] arr)
        {
            return $"{arr[first]} + {arr[second]}";
        }
    }
}