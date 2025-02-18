﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentCount = Students.Count;
            if (studentCount < 5)
                throw new InvalidOperationException("At least 5 students are needed to rank grades");

            var studentsAboveCount = Students.Where(student => student.AverageGrade > averageGrade).Count();

            var studentsAboveRatio = studentsAboveCount / (double)studentCount;

            if (studentsAboveRatio < 0.2)
                return 'A';
            else if (studentsAboveRatio < 0.4)
                return 'B';
            else if (studentsAboveRatio < 0.6)
                return 'C';
            else if (studentsAboveRatio < 0.8)
                return 'D';
            else 
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
