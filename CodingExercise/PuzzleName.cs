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
            return 0;
        }

        public PuzzleName(string name, int position)
        {
            Name = name;
            Position = position;
        }
    }
}
