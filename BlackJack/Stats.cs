
namespace BlackJack
{
    internal class Stats
    {
        public int Victory { get; private set; }
        public int Defeat { get; private set; }
        public int Draw { get; private set; }
        public int Match { get; private set; }

        public Stats()
        {
            Victory = 0;
            Defeat = 0;
            Draw = 0;
            Match = 0;
        }

        public void AddVictory()
        {
            Match++;
            Victory++;
        }
        public void AddDefeat()
        {
            Match++;
            Defeat++;
        }
        public void AddDraw()
        {
            Match++;
            Draw++;
        }

        public void ShowStats()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("GAME STATS");
            Console.WriteLine($"Victories: {Victory}");
            Console.WriteLine($"Defeats: {Defeat}");
            Console.WriteLine($"Draws: {Draw}");
            Console.WriteLine($"Matchs: {Match}");
            Console.WriteLine("=========================");
        }
    }
}
