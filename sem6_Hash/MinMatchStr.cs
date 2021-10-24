using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace sem6_Hash
{
    public class MinMatchStr
    {
        public static String findSubString(String s,
            String t)
        {
            //ініціалізуємо розміри стрічок, які подали на вхід ф-ції
            int n = s.Length;
            int m = t.Length;
            //Якщо розмір стрічки, в якій ми будемо шукати іншу стрічку,
            //менший - то подальший пошук не можливий
            if (n < m) return "";
            
            int start = 0; //початок у стрічці s символів з t -
                           //використовується для просування по рядку s
                           //та знаходження першого символу у s з стрічки t
            int start_index = -1; //індекс початку підстрічки-результату - чисельно дорівнює start
            int min_len = int.MaxValue; //мінімальна довжина знайденого підрядку

            //словники: симлол - к-сть появ у рядку
            Dictionary<char, int> s_char_occurance = new Dictionary<char, int>();
            Dictionary<char, int> t_char_occurance = new Dictionary<char, int>();
            
            //заповнюємо словник для стрічки, що будемо шукати
            for(int i=0;i<m;i++)
                if (t_char_occurance.ContainsKey(t[i]))
                    t_char_occurance[t[i]]++;
                else
                    t_char_occurance.Add(t[i],1);

            int count = 0;//к-сть елементів з t знайдених у s (має дорівнювати к-сті ел у t)
            for (int j = 0; j < n; j++)//проходимо по рядку s - посимвольно
            {
                //заповнюємо посимвольно словник для s
                if(s_char_occurance.ContainsKey(s[j]))
                    s_char_occurance[s[j]]++;
                else
                    s_char_occurance.Add(s[j],1);
                //Якщо такий символ існує у t та його поява там така ж (або більша) за появу у стрічці s
                //тобто перевірка чи в s є всі елементи з t
                //зрозуміло, що якщо буде виконуватись ця умова - то в t, в s - буде хоча б один такий символ
                if(t_char_occurance.ContainsKey(s[j]) && s_char_occurance[s[j]] <= t_char_occurance[s[j]])
                    count++;
                //виконується, якщо знайдено у s всі символи з t
                if (count == m)
                {
                    while (true)
                    {
                        //Якщо в s є символ, якого немає в t - ми зменшуємо к-сть його появ у словнику s,
                        //та переходимо до наступного символу (правильніше сказати - зміщуємо початок перевірки символів у s);
                        //Якщо в t є цей символ і його появ там менше ніж в s - зменшуємо появи в s і переходимо до наступного ел
                        if (t_char_occurance.ContainsKey(s[start]) &&
                            t_char_occurance[s[start]] < s_char_occurance[s[start]])
                        {
                            s_char_occurance[s[start]]--;
                            start++;
                        }
                        else if (!t_char_occurance.ContainsKey(s[start]))
                        {
                            s_char_occurance[s[start]]--;
                            start++;
                        }
                        //якщо к-сть появ наступного символу у s вже == появам y t - виходимо з циклу
                        if (t_char_occurance.ContainsKey(s[start]) && t_char_occurance[s[start]] >= s_char_occurance[s[start]])
                            break;
                    }
                    //рахуємо відстань між першим ел знайденим і останнім
                    int len_substring = j - start + 1;//6
                    if (min_len > len_substring)
                    {
                        min_len = len_substring;
                        start_index = start;
                    }
                }
            }

            if (start_index == -1)
            {
                return "";
            }

            return s.Substring(start_index, min_len);
        }
    }
}