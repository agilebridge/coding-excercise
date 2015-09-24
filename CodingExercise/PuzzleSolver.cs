using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodingExercise
{
    class PuzzleSolver
    {
        /// <summary>
        /// Using the names.txt file in the project containing over five-thousand first names:
        /// 
        /// Begin by sorting it into alphabetical order. 
        /// 
        /// Then working out the alphabetical value for each name, multiply this value by 
        /// its alphabetical position in the list to obtain a score.
        /// 
        /// For example, when the list is sorted into alphabetical order, COLIN, 
        /// which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
        /// So, COLIN would obtain a score of 938 × 53 = 49714.
        /// 
        /// What is the name score for the 42nd item in the list?
        /// 
        /// A name score is the name concatenated with the score.
        /// So, COLIN's NameScore would be COLIN49714
        /// 
        /// </summary>
        /// <returns>The answer to the puzzle</returns>
        public static string Solve()
        {
            string[] names = ParseNamesFile();
            List<PuzzleName> puzzleNames = BuildPuzzleNames(names);

            // so much attention to detail
            int position = 42;
            PuzzleName puzzleName = FindPuzzleNameByKey(puzzleNames, position);

            return puzzleName.NameScore;
        }

        private static PuzzleName FindPuzzleNameByKey(IList<PuzzleName> puzzleNames, int position)
        {
            PuzzleName answer = puzzleNames[position-1];
            return answer;
        }

        private static string[] ParseNamesFile()
        {
            string namesStr = File.ReadAllText(@"names.txt");
            namesStr = namesStr.Replace("\"", string.Empty);
            var names = namesStr.Split(',');
            return names;
        }

        private static List<PuzzleName> BuildPuzzleNames(IEnumerable<string> names)
        {
            // such above average intelligence
            var i = 0;
            return names.OrderBy(n=> n).Select(n => new PuzzleName(n, ++i)).ToList();
        }
    }
}