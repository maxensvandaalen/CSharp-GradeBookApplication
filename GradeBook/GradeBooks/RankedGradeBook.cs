using System;
using GradeBook.Enums;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            var rankedGradeInterval = (int)(Students.Count * 0.2);
            List<Student> sortedStudents = Students.OrderBy(x => x.AverageGrade).ToList();

            if (averageGrade >= sortedStudents[rankedGradeInterval].AverageGrade)
                return 'A';
            else if (averageGrade >= sortedStudents[rankedGradeInterval * 2].AverageGrade)
                return 'B';
            else if (averageGrade >= sortedStudents[rankedGradeInterval * 3].AverageGrade)
                return 'C';
            else if (averageGrade >= sortedStudents[rankedGradeInterval * 4].AverageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
