namespace CodingExercise
{
    class PuzzleName
    {
        public string Name { get; private set; }

        public int AlphabeticalValue
        {
            get { return GetAlphabeticalValue(Name); }
        }

        public int Position { get; private set; }

        public long Score
        {
            get { return Position * AlphabeticalValue; }
        }

        public string NameScore
        {
            get { return string.Format("{0}{1}", Name, Score); }
        }

        private static int GetAlphabeticalValue(string name)
        {
            int score = 0;

            foreach (char character in name)
            {
                score = score + GetSingleAlphaScore(character);
            }

            return score;
        }

        /// <summary>
        /// Calculate the character index and return it
        /// </summary>
        /// <param name="c">Character to calcualte</param>
        /// <returns></returns>
        private static int GetSingleAlphaScore(char c)
        {

            //Do a quick calculation to the find the value value from the character.
            //This can be replaced with a configurable scoring mechanism when you can customize how 
            //scores are calculated, but this will do for now.
            int score = char.ToUpper(c) - 64;
            return score;
        }

        public PuzzleName(string name, int position)
        {
            Name = name;
            Position = position;
        }
    }
}
