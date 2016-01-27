using System;
using System.Collections.Generic;
using System.Configuration;
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
        /// 

        #region ResourceLocations

        ///Gets the location of the names.txt from configuration
        private static string NameFileLocation
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["NameFileLocation"]);
            }
        }

        //Gets the location of the ScoreConfigFile from configuration
        private static string ScoreConfigLocation
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings["AlphaScoreConfig"]);
            }
        }

        #endregion

        public static string Solve()
        {
            string[] names = ParseNamesFile();

            List<PuzzleName> puzzleNames = BuildPuzzleNames(names);

            int position = 42;
            PuzzleName puzzleName = FindPuzzleNameByKey(puzzleNames, position);

            //Temp for testing
            return "test";

            return puzzleName.NameScore;
        }

        private static PuzzleName FindPuzzleNameByKey(IList<PuzzleName> puzzleNames, int position)
        {
            // Lookup the correct PuzzleName by its position as calculated 
            // in the BuildPuzzleNames(...) method.

            PuzzleName answer = puzzleNames.First<PuzzleName>(pN => pN.Position == position);

            return answer;
        }

        private static string[] ParseNamesFile()
        {
            //Read the raw fileContent. Reference the property containing the Names.txt file location
            string rawContent = File.ReadAllText(NameFileLocation);

            //Get the array by splitting the content by ","
            string[] sNames = rawContent.Split(',');

            //Placeholder list for stripping of Quotations because we cannot alter vbariables in a foreach loop
            List<string> tempNames = new List<string>();

            //strip the quotations
            foreach (string name in sNames)
            {
                string cleanedName = name.Replace(@"""","");
                tempNames.Add(cleanedName);
            }

            //return the Array of strings
            return tempNames.ToArray<string>();
        }

        private static List<PuzzleName> BuildPuzzleNames(IEnumerable<string> names)
        {
            // Iterate through the list of names and build a List of PuzzleName objects.
            //
            // Note: The first PuzzleName object should have a Position property value of 1.  
            // The second is 2 and so on.
            // Position is 1 based and not zero based.

            List<PuzzleName> tempList = names.Select(n => new PuzzleName(n, -999)).ToList();

            //Sort the list using the name Variable
            tempList = tempList.OrderBy(pn => pn.Name).ToList<PuzzleName>();

            //Final returned List
            List<PuzzleName> returnList = new List<PuzzleName>();

            //Assign Position values
            PuzzleName[] pArray = tempList.ToArray<PuzzleName>();
            for (int i = 0; i < pArray.Length; i++)
            {
                PuzzleName pName = pArray[i];
                returnList.Add(new PuzzleName(pName.Name, i + 1));
            }      

            return returnList;
        }
    }
}