using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AlohaScoreSeeder
{
    class Program
    {
        //This is a quick program I slapped together to generate the initial score configuration
        static void Main(string[] args)
        {
            AlphaScoreConfig Config = new AlphaScoreConfig();
            Config.ScoreConfigs = new List<ScoreConfig>();
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "A", CharacterValue = 1 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "B", CharacterValue = 2 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "C", CharacterValue = 3 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "D", CharacterValue = 4 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "E", CharacterValue = 5 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "F", CharacterValue = 6 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "G", CharacterValue = 7 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "H", CharacterValue = 8 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "I", CharacterValue = 9 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "J", CharacterValue = 10 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "K", CharacterValue = 11 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "L", CharacterValue = 12 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "M", CharacterValue = 13 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "N", CharacterValue = 14 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "O", CharacterValue = 15 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "P", CharacterValue = 16 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "Q", CharacterValue = 17 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "R", CharacterValue = 18 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "S", CharacterValue = 19 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "T", CharacterValue = 20 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "U", CharacterValue = 21 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "V", CharacterValue = 22 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "W", CharacterValue = 23 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "X", CharacterValue = 24 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "Y", CharacterValue = 25 });
            Config.ScoreConfigs.Add(new ScoreConfig { Character = "Z", CharacterValue = 26 });

            XmlSerializer xsSubmit = new XmlSerializer(typeof(AlphaScoreConfig));
            using (StringWriter sww = new StringWriter())
            using (TextWriter writer = new StreamWriter(@"ScoreConfig.xml"))
            {
                xsSubmit.Serialize(writer, Config);
                writer.Close();
            }
        }
    }

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
