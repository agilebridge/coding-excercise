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
            //TODO: remove this code and add your implementation here
            //return 0;
             
            /*
             * Yobe  - 14/10/2015
             * 
             * Get alphabetic value of name.
             * 
             * 1. Declare a string with all uppercase letters of alphabet.
             * 2. Use this to get the index of every letter in the name.
             * NOTE: Index is 0 (zero) based so add 1 to force it start at 1 = A
             */

            int iAlphabeticalValue = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Get each letter of the name
            foreach (var s in name)
            {
                // Convert it to uppercase before comparison
                char letter = char.ToUpper(s);

                // Must be between A and Z
                if (letter >= 'A' || letter <= 'Z')
                {
                    // Get index and add 1
                    int iIndex = alphabet.IndexOf(letter) + 1;

                    // Add up the indexes
                    iAlphabeticalValue += iIndex;
                }

            }

            return iAlphabeticalValue;
        }

        public PuzzleName(string name, int position)
        {
            Name = name;
            Position = position;
        }
    }
}
