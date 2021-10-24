using System;
using System.Collections.Generic;

namespace sem6_Hash
{
    public class ArrayRepresentation
    {
        private PairRepresentation pair;

        public bool findPair(int[] arr)
        {
            //словник, де зберігатимуться пари: сума - об'єкт (де є два числа, від яких ця сума)
            Dictionary<int, PairRepresentation> dictionary = new Dictionary<int, PairRepresentation>();
            int arrLength = arr.Length;
            //О(n^2)
            for (int i = 0; i < arrLength; i++)
            {
                for (int j = i + 1; j < arrLength; j++)
                {
                    int sum = arr[i] + arr[j];
                    //якщо в словнику вже є ця сума (сума то наш ключ) - Виводимо значення тих чисел,
                    //які вже є в словнику та тих з яких ми отримали цю суму тільки що
                    //виходимо з внутрішнього циклу - це дасть нам можливість не виводити пари однакових чисел 3 + 4 = 3+ 4 (якщо вони взяті з тих самих позицій)
                    if (dictionary.ContainsKey(sum))
                    {
                        pair = dictionary[sum];
                        Console.WriteLine($"{pair.ShowPair(arr)} = {arr[i]} + {arr[j]} = {sum}");
                        break;
                    }
                    //Якщо не знайдено в словнику тої суми - записуємо її за ключем(що і є нашою сумою)
                    dictionary[sum] = new PairRepresentation(i, j);
                }
            }

            return true;
        }
    }
}