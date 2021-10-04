using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;


namespace gradingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("C:/Users/agnese.broka/source/repos/gardingTask/input.txt");
            int[] grades = text.Split(',').Select(int.Parse).ToArray();
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
