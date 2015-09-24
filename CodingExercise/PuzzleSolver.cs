using System.Collections.Generic;
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

            int position = 42;
            PuzzleName puzzleName = FindPuzzleNameByKey(puzzleNames, position);

            return puzzleName.NameScore;
        }

        private static PuzzleName FindPuzzleNameByKey(IList<PuzzleName> puzzleNames, int position)
        {
            // Lookup the correct PuzzleName by its position as calculated 
            // in the BuildPuzzleNames(...) method.

            //TODO: remove this code and add your implementation here
            PuzzleName answer = puzzleNames[0];

            return answer;
        }

        private static string[] ParseNamesFile()
        {
            //TODO: remove this code and add your implementation here
            return new[] {"A","B","C"};
        }

        private static List<PuzzleName> BuildPuzzleNames(IEnumerable<string> names)
        {
            // Iterate through the list of names and build a List of PuzzleName objects.
            //
            // Note: The first PuzzleName object should have a Position property value of 1.  
            // The second is 2 and so on.
            // Position is 1 based and not zero based.

            //TODO: remove this code and add your implementation here
            return names.Select(n => new PuzzleName(n, -999)).ToList();
        }
    }
}