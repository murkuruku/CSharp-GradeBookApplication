﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) :base(name,isWeighted)
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


             double numb;
             for (int i = 0; i < Students.Count; i++)
             {
                 for (int j = 0; j < Students.Count - 1; j++)
                 {
                     if (averageGrades[j] < averageGrades[j + 1])
                     {
                         numb = averageGrades[j];
                         averageGrades[j] = averageGrades[j + 1]; 
                         averageGrades[j + 1] = numb;

                     }
                 } 
             }
             if (averageGrade >= averageGrades[thershold - 1])
             {
                 return 'A';
             }
             else if (averageGrade >= averageGrades[(thershold*2) - 1])
             {
                 return 'B';
             }
             else if (averageGrade >= averageGrades[(thershold*3) - 1])
             {
                 return 'C';
             }
             else if (averageGrade >= averageGrades[(thershold*4) - 1])
             {
                 return 'D';
             }
             else
             {
                 return 'F';
             }
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
    }

