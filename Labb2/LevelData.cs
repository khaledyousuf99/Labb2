using System;
using System.Collections.Generic;
using System.IO;

namespace Labb2
{
    class LevelData
    {
        private List<LevelElement> allObjects = new List<LevelElement>();


        public List<LevelElement> Elements => allObjects;

        public int PlayerPositionX { get; set; }


        public int PlayerPositionY { get; set; }

        public void Load(string fileName)
        {
            var file = new StreamReader(fileName);


            int row = 0;

            while (!file.EndOfStream)
            {
                string currentLine = file.ReadLine();



                for (int col = 0; col < currentLine.Length; col++)
                {
                    char symbol = currentLine[col];

                    if (symbol == '#')
                    {
                        var w = new Wall();
                        w.PositionX = col;


                        w.PositionY = row;


                        allObjects.Add(w);
                    }
                    else if (symbol == 'r')
                    {

                        var r = new Rat();
                        r.PositionX = col;


                        r.PositionY = row;

                        allObjects.Add(r);
                    }
                    else if (symbol == 's')
                    {

                        var s = new Snake();

                        s.PositionX = col;


                        s.PositionY = row;


                        allObjects.Add(s);


                    }
                    else if (symbol == '@')
                    {
                        PlayerPositionX = col;


                        PlayerPositionY = row;


                    }


                }

                row++;
            }

            file.Close();
        }
    }
}
