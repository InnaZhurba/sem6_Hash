using System;

namespace sem6_Hash
{
    class Program
    {
        //Для заданого масиву A цілих чисел
        //довжиною n потрібно знайти всі такі
        //четвірки елементів a, b, c, d, що a + b = c + d.
        //
        //Алгоритм:
        //1. Проходимо по масиву беручи і-ий ел та і+1 ел
        //2. Знаходимо їх суму і шукаємо чи є вона як ключ у словнику
        //3. Якщо є, то повертаємо і виводимо
        //4. Якщне немає - то заносимо в словник
        public static void task5()
        {
            int[] arr = new int[] {3, 4, 7, 1, 12, 9};
            ArrayRepresentation a = new ArrayRepresentation();
            a.findPair(arr);
        }
        //Дано два рядки s та t довжиною n та m відповідно. Потрібно знайти підрядок
        //рядка s мінімальної довжини який містить усі символи рядка t (включаючи повторення).
        //Якщо такого підрядка немає, поверніть пустий рядок “”.
        public static void task10()
        {
            String s = "EABANC";
            String t = "ABC";
 
            Console.WriteLine(MinMatchStr.findSubString(s, t));
        }
        static void Main(string[] args)
        {
            //TASK 5
            task5();
            
            //TAASK 10
            //task10();
        }
    }
}