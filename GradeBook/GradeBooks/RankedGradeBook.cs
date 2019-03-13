using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) :base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)

                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");

            var thershold = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> averageGrades = new List<double>();
            foreach (Student student in Students)
            { 
                averageGrades.Add(student.AverageGrade);
            } 
            double[] arrayAverageGrades = averageGrades.ToArray();
            double numb;
            for (int i = 0; i <= Students.Count; i++)
            {
                for (int j = 0; j <= Students.Count - 1; j++)
                {
                    if (arrayAverageGrades[j] < arrayAverageGrades[j + 1])
                    {
                        numb = arrayAverageGrades[j];
                        arrayAverageGrades[j] = arrayAverageGrades[j + 1];
                        arrayAverageGrades[j + 1] = numb;

                    }
                }
            }
            if (averageGrade >= arrayAverageGrades[thershold - 1])
            {
                return 'A';
            }
            else if (averageGrade >= arrayAverageGrades[(thershold * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= arrayAverageGrades[(thershold * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= arrayAverageGrades[(thershold * 4) - 1])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        }
    }

