using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;

namespace SnakeGame
{
    class ScoreXmlHandler
    {
        private XmlReader xmlReader { get; set; }

        private XmlWriter xmlWriter { get; set; }

        private List<ScoreData> Scores;

        public ScoreXmlHandler()
        {
            try
            {
                UpdateScores();
            }
            catch (Exception)
            {

                xmlWriter = XmlWriter.Create("SnakeScores.xml");

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("players");
                xmlWriter.WriteStartElement("player");
                xmlWriter.WriteAttributeString("name", "BOSS");
                xmlWriter.WriteAttributeString("score", "999");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Close();
            }
        }

        public void WriteScores(string name , int score)
        {
            this.ArrangeScores(name, score);

            xmlWriter = XmlWriter.Create("SnakeScores.xml");
            xmlWriter.WriteStartDocument();

            int tempInt = 0;

            if (this.Scores.Count < 3)
            {
                tempInt = this.Scores.Count;
            }
            else
            {
                tempInt = 3;
            }

            for (int i = 0; i < tempInt; i++)
			{
                xmlWriter.WriteStartElement("players");
                xmlWriter.WriteStartElement("player");
                xmlWriter.WriteAttributeString("name", this.Scores[i].Name);
                xmlWriter.WriteAttributeString("score", this.Scores[i].Score.ToString());
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void UpdateScores()
        {
            this.Scores = new List<ScoreData>();

            xmlReader = XmlReader.Create("SnakeScores.xml");

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "player"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        Scores.Add(new ScoreData(int.Parse(xmlReader.GetAttribute("score")), xmlReader.GetAttribute("name")));
                    }
                }
            }
            xmlReader.Close();
        }

        public List<ScoreData>  GetScores()
        {
            UpdateScores();
            return Scores;
        }

        private void ArrangeScores(string newName, int newScore)
        {
            UpdateScores();
            this.Scores.Add(new ScoreData(newScore, newName));

            ScoreData temp;

            for (int i = 0; i < this.Scores.Count; i++)
            {
                for (int j = 0; j < this.Scores.Count-1; j++)
                {
                    if (this.Scores[j].Score < this.Scores[j+1].Score)
                    {
                        temp = new ScoreData(this.Scores[j].Score, this.Scores[j].Name);
                        Scores[j] = new ScoreData(this.Scores[j + 1].Score, this.Scores[j + 1].Name);
                        this.Scores[j +1] = new ScoreData(temp.Score, temp.Name);
                    }
                }
            }
        }
    }
}
