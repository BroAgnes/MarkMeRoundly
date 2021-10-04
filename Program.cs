using System;
using System.Linq;
using System.IO;
using System.Reflection;


namespace gradingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = AppDomain.CurrentDomain.BaseDirectory + "//input.txt";
            string text = System.IO.File.ReadAllText(inputPath);
            int[] grades = text.Split(',').Select(g => g.Trim() == "" ? 0 : Convert.ToInt32(g)).ToArray();
            Console.WriteLine(String.Join(", ", grades));
            for(int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 38) continue;
                int gradeLeft = (grades[i] / 10) * 10;
                int gradeRight = grades[i] % 10;
                int gradeRoundToNumber = gradeRight > 5 ? gradeLeft + 10 : gradeLeft + 5;
                int roundedGrade = gradeRoundToNumber - grades[i] >= 3 ? grades[i] : gradeRoundToNumber;
                grades[i] = roundedGrade;
            }

            File.WriteAllText("output.txt", String.Join(", ", grades));
            text = System.IO.File.ReadAllText("output.txt");
            Console.WriteLine(text);

        }
    }
}
