using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        TestD(Console.ReadLine, Console.WriteLine, Console.WriteLine);
    }

    public static void TestD(Func<string> readLine, Action<String> writeLineStr, Action writeLine)
    {
        var testCaseCount = int.Parse(readLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            readLine();

            var tableSize = readLine().Split(' ').Select(int.Parse).ToList();
            var n = tableSize[0];
            var m = tableSize[1];

            var rows = new List<List<int>>(n);
            for (int j = 0; j < n; j++)
            {
                var row = readLine().Split(' ').Select(int.Parse).ToList();
                rows.Add(row);
            }

            var numClicks = int.Parse(readLine());
            var clicks = readLine().Split(' ').Select(int.Parse).ToList();

            for (int j = 0; j < clicks.Count; j++)
            {
                var clickOn = clicks[j] - 1;
                BubbleSort(rows, clickOn);
                // rows.Sort((list1, list2) => list1[clickOn] - list2[clickOn]);
            }

            for (int j = 0; j < rows.Count; j++)
            {
                writeLineStr(String.Join(" ", rows[j]));
            }
            
            writeLine();
        }
    }

    private static void BubbleSort(List<List<int>> list, int columnIndex)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - i -1; j++)
            {
                if (list[j][columnIndex] > list[j + 1][columnIndex])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }
        }
    }

    public static void TestC()
    {
        var testCaseCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < testCaseCount; i++)
        {
            var numProgrammers = int.Parse(Console.ReadLine());
            var programmerSkills = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int j = 0; j < numProgrammers; j++)
            {
                var prog = programmerSkills[j];
                if (prog > 0)
                {
                    var curMin = float.PositiveInfinity;
                    var curMinIdx = j + 1;
                    for (int k = j + 1; k < programmerSkills.Count; k++)
                    {
                        var nextMin = Math.Abs(prog - programmerSkills[k]);
                        if (curMin > nextMin && programmerSkills[k] > 0)
                        {
                            curMin = nextMin;
                            curMinIdx = k;
                        }
                    }

                    programmerSkills[j] = -1;
                    programmerSkills[curMinIdx] = -1;
                    Console.WriteLine($"{j + 1} {curMinIdx + 1}");
                }
            }
        }
    }

    public static void TestB()
    {
        var testCaseCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < testCaseCount; i++)
        {
            var totalPrice = 0;
            
            var goodsCount = int.Parse(Console.ReadLine());
            var goodsPrice = Console.ReadLine().Split(' ')
                .Select(str => int.Parse(str))
                .GroupBy(val => val);
            
            foreach (var goods in goodsPrice)
            {
                var num = goods.Count();
                totalPrice += goods.Key * (num - num / 3);
            }
            
            Console.WriteLine(totalPrice);
        }
    }

    public static void TestA()
    {
        var testCaseCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < testCaseCount; i++)
        {
            var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
            Console.WriteLine(collection.Sum());
        }
    }
}