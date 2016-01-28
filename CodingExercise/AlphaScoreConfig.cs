using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise
{
    /// <summary>
    /// Container class for scoring configuration
    /// </summary>
    public class AlphaScoreConfig
    {
        public List<ScoreConfig> ScoreConfigs { get; set; }
    }

    /// <summary>
    /// Container class for housing of one score config. One letter and its corresponding character
    /// </summary>
    public class ScoreConfig
    {
        public string Character { get; set; }

        public int CharacterValue { get; set; }
    }
}
