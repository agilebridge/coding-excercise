using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

            /*
             * Yobe     :       14/10/2015
             * Get the name at the position passed in
             */
            PuzzleName answer = puzzleNames[position];


            return answer;
        }

        private static string[] ParseNamesFile()
        {
            //TODO: remove this code and add your implementation here
            //return new[] {"A","B","C"};

            /*
             * Yobe     :   14/10/2015
             * Get names from file and return string array
             */
            string[] namesInFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\names.txt").ToString().Split(',');

            // This is used to build an alphabet based name as the IEnumerable list returns has other characters in the words 
            StringBuilder nameBuilder = new StringBuilder();

            // This is the return list
            string[] loadedNames = new string[namesInFile.Length];

            // Loop through the list and get final names with only letters of the alphabet
            for (int i = 0; i <= namesInFile.Length - 1;i++)
            {
                // Current name
                string name = namesInFile[i];

                // Loop through the characters in name and rmove any characters that is not a letter
                foreach (var s in name)
                {
                    // Use a regular expression to to only get letters
                    Match match = Regex.Match(s.ToString(), @"^[A-Za-z]+", RegexOptions.None);

                    if (match.Success)
                    {
                        // Make sure it all uppercase
                        char upper = char.ToUpper(s);

                        // Make sure the letters are between A and Z
                        if (upper >= 'A' || upper <= 'Z')
                        {
                            // Put the name back together again
                            nameBuilder.Append(s);
                        }
                    }
                }

                // Add to list
                loadedNames[i] = nameBuilder.ToString();

                // Clear the StringBuilder
                nameBuilder.Clear();
            }


            return loadedNames;

        }

        private static List<PuzzleName> BuildPuzzleNames(IEnumerable<string> names)
        {
            // Iterate through the list of names and build a List of PuzzleName objects.
            //
            // Note: The first PuzzleName object should have a Position property value of 1.  
            // The second is 2 and so on.
            // Position is 1 based and not zero based.

            //TODO: remove this code and add your implementation here
            //return names.Select(n => new PuzzleName(n, -999)).ToList();

            /*
             * Yobe     - 14/10/2015
             * 
             * Build list of puzzle objects
             * 
             */
            List<PuzzleName> puzzleNames = new List<PuzzleName>();

            // Convert to generic list
            List<string> sNames = names.ToList();

            // Sort the list alphabetically
            sNames.Sort();

            // Loop through the list and build puzzle objects
            for (int i = 0; i <= sNames.Count - 1; i++)
            {
                // Get current name
                string name = sNames[i];

                // Get position of the name in list
                int iPosition = sNames.IndexOf(name);

                // Add 1 so Position is not zero based
                iPosition += 1;

                // New object
                PuzzleName puzzleName = new PuzzleName(name, iPosition);
        

                puzzleNames.Add(puzzleName);
            }


            return puzzleNames;
        }
    }
}