using System;

namespace Semenar10_CSharp_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            
                /*
                Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех
                чисел на группы, так чтобы в одной группе все числа были взаимно просты (все
                числа в группе друг на друга не делятся)? Найдите M при заданном N и получите
                одно из разбиений на группы N ≤ 10²⁰.
                25 мин
                Например, для N = 50, M получается 6
                - Группа 1: 1
                - Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
                - Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
                - Группа 4: 8 12 18 20 27 28 30 42 44 45 50
                - Группа 5: 7 16 24 36 40
                - Группа 6: 5 32 48

                Другой пример разбиения на группы с тем же N:
                - Группа 1: 1
                - Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
                - Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
                - Группа 4: 8 12 18 20 27 28 30 42 44 45 50
                - Группа 5: 16 24 36 40
                - Группа 6: 32 48
                 */

                // Задача 73: 

                Console.WriteLine("Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех " +
                "чисел на группы, так чтобы в одной группе все числа были взаимно просты (все " +
                "числа в группе друг на друга не делятся) ? Найдите M при заданном N.");

            Console.WriteLine("Введите число N:");

            bool numberCheck = int.TryParse(Console.ReadLine(), out int task73_N);
            while (!numberCheck)
            {
                Console.WriteLine("Введено не число. Повторите ввод:");
                numberCheck = int.TryParse(Console.ReadLine(), out task73_N);
            }

            double task73_findM = task73_N;
            int task73_M = 1;


            // определяем максимальный уровень группы (максимальное количество простых делителей чисел
            while (task73_findM >= 2)
            {
                task73_findM /= 2.0;
                task73_M++;

            }

            // считано число N

            int[,] arr73_outcome = new int[task73_N + 1, task73_M + 1]; // количество чисел по группам

            arr73_outcome[0, 1] = 1; //в первой группе только 1 число
            arr73_outcome[1, 1] = 1; //и это - 1

            for (int i = 2; i <= task73_M; i++)
                arr73_outcome[0, i] = 0; // в каждой следующей группе группе 0 чисел


            int task73_level = 2; // минимальный уровень - уровень простых чисел
            bool task73_groupNotPassed = true; // уровень глубины может быть увеличен, если число не взаимно-простое с числами группы
            int task73_delitel = 1; // индекс делителя в группе
            int task73_current = 1;

            for (int i = 2; i <= task73_N; i++) //все натуральные числа
            {

                task73_level = 2; // группа простоты - первично по количеству простых делителей числа
                task73_current = i; // записываем в переменную, чтобы вычленять простые делители

                
                // проверить деление только на простые делители
                while ((task73_delitel <= arr73_outcome[0, 2]) && (task73_current >= 2))
                {
                    if (task73_current % arr73_outcome[task73_delitel, 2] == 0) //делиться на этот простой делитель?
                    {
                        //Console.WriteLine(arr73_outcome[task73_delitel, 2] + " - делитель числа " + i + " индекс делителя - " + task73_delitel);
                        // контроль
                        task73_current /= arr73_outcome[task73_delitel, 2]; //вычленяем из числа найденный простой делитель.
                        task73_delitel = 1; // снова ищем с 1 делителя (группа простых чисел)
                        task73_level++; // уровень группы повышен (для числа)

                    }
                    else
                        task73_delitel++; // следующий в группе простых чисел
                }

                if (task73_level > 2)
                {
                    task73_level--;
                }

                task73_groupNotPassed = true; // группа не определена
                task73_delitel = 1;

                // проверяем делимость на каждый из делителей чисел группы
                while (task73_groupNotPassed)
                {

                    task73_groupNotPassed = false; // доказывает от противного
                    for (int j = 1; j <= arr73_outcome[0, task73_level]; j++) // каждое число на текущем уровне группы
                    {
                        if (i % arr73_outcome[j, task73_level] == 0)
                        {
                            task73_groupNotPassed = true; // группа не найдена
                            //Console.WriteLine(arr73_outcome[j, task73_level] + " - делитель числа " + i
                            // контроль
                        }

                    }

                    if (task73_groupNotPassed)
                    {
                        //Console.WriteLine(task73_level + " уровень - не подходит числу " + i);
                        // контроль
                        task73_level++; // и мы идём к следующей
                    }
                }

                //Console.WriteLine(task73_level + " уровень - позиция " + (arr73_outcome[0, task73_level] + 1) + " - число " + i);
                // контроль

                task73_delitel = 1;
                arr73_outcome[0, task73_level]++;
                arr73_outcome[arr73_outcome[0, task73_level], task73_level] = i;


            }

            Console.WriteLine("M = " + task73_M);

            for (int i = 1; i <= task73_M; i++)
            {
                Console.Write("Группа " + i + ": ");
                for (int j = 1; j <= arr73_outcome[0, i]; j++)
                {
                    Console.Write("{0,4}", arr73_outcome[j, i]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\n");
        }
    }
}

