using Labb2;

namespace GameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var currentLevel = new LevelData();


            currentLevel.Load("Level1.txt");

           
            var hero = new Player
            {
                Name = "Khaled",
                PositionX = currentLevel.PlayerPositionX,


                PositionY = currentLevel.PlayerPositionY
            };

            Console.CursorVisible = false;

            bool isRunning = true;
            int rounds = 0;
            string log = string.Empty;

            while (isRunning)
            {
                Console.Clear();

                
                Console.ForegroundColor = ConsoleColor.Gray;


                Console.SetCursorPosition(0, 0);


                Console.WriteLine($"Spelare: {hero.Name} | HP: {hero.HP}/100 | Tur: {rounds}");
                Console.ResetColor();

                
                Console.SetCursorPosition(0, 1);


                Console.WriteLine(log);

               
                foreach (var obj in currentLevel.Elements)
                {
                    double dist = Math.Sqrt(
                        Math.Pow(obj.PositionX - hero.PositionX, 2) +


                        Math.Pow(obj.PositionY - hero.PositionY, 2));

                    if (obj is Wall && dist <= 5)
                        obj.Discovered = true;

                    if ((obj is Enemy && dist <= 5) || (obj is Wall && obj.Discovered))
                        obj.Draw();
                }

               
                hero.Draw();

                
                var input = Console.ReadKey(true).Key;


                if (input == ConsoleKey.Escape)
                    break;

                rounds++;

               
                hero.Move(input, currentLevel, ref log);

                
                foreach (var entity in currentLevel.Elements.ToList())


                {
                    if (entity is Enemy foe)
                        foe.Update(currentLevel, hero, ref log);
                }

                
                if (hero.HP <= 0)
                {
                    Console.SetCursorPosition(0, 1);


                    Console.WriteLine(log);


                    isRunning = false;
                }
            }
        }
    }
}
