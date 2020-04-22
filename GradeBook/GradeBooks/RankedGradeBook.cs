using System;
using GradeBook.Enums;
using System.Linq;
using System.Collections.Generic;

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
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            var rankedGradeInterval = (int)Math.Ceiling(Students.Count * 0.2);
            List<Student> sortedStudents = Students.OrderByDescending(x => x.AverageGrade).ToList();

            if (averageGrade >= sortedStudents[rankedGradeInterval - 1].AverageGrade)
                return 'A';
            else if (averageGrade >= sortedStudents[(rankedGradeInterval * 2) - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= sortedStudents[(rankedGradeInterval * 3) - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= sortedStudents[(rankedGradeInterval * 4) - 1].AverageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
