
using System.Text;

namespace BlackJack
{
    internal class Game
    {
        private static Actors Dealer = new();
        private static Actors Player = new();
        private static Stats Stats = new();

        public static void LoopRun()
        {
            while (true)
            {
                Console.Clear();
                SingleRun();
                Console.WriteLine("Start's a new one? [Y]es [N]o ");
                string answer = Console.ReadLine() ?? "n";

                if (answer.ToLower() == "n") { break; }
            }
            Stats.ShowStats();
        }


        private static void SingleRun()
        {
            bool run = true;
            // Player's While
            while (run)
            {
                Menu(dealer: true);
                Console.Write("Your choice: ");
                int esc = int.Parse(Console.ReadLine() ?? "0");
                switch (esc)
                {
                    case 1:
                        Player.AddCard();
                        break;
                    case 2:
                        run = false;
                        break;
                }
                Console.Clear();
                if (Player.Total() > 21)
                {
                    break;
                }
            }
            // Dealer's While
            while (true)
            {
                Menu(dealer: false);
                if (Dealer.Total() >= 18 && Dealer.Total() <= 21 || Dealer.Total() > 21)
                {
                    break;
                }
                Console.Clear();
                Dealer.AddCard();
            }
            // Checks the winner
            Console.Clear();
            Menu(dealer: false);
            Checker();
            Restart();

        }
        private static void Menu(bool dealer)
        {
            Lin("=");
            Console.WriteLine("        BlackJack Game");
            Lin("=");
            // Displaying the cards
            if (dealer)
            {
                Console.WriteLine($"Dealer: {CardDisplay(Dealer.Deck, dealer)}");
            }
            else 
            {
                Console.WriteLine($"Dealer: {CardDisplay(Dealer.Deck, false)}" +
                    $"| {Dealer.Total()}");
            }

            Console.WriteLine($"Player: {CardDisplay(Player.Deck, false)}" +
                $"| {Player.Total()}");
            Console.WriteLine("[ 1 ] HIT  |  [ 2 ] STAND");
            Lin("=");
        }

        private static void Checker()
        {

            static bool CheckWinner(int firstTotal, int secondTotal)
            {
                bool winCondition = (firstTotal < 22 && firstTotal > secondTotal || secondTotal > 21 && firstTotal < 22);
                Console.WriteLine($"Player: {firstTotal} Dealer: {secondTotal} WC: {winCondition}");
                return winCondition;
            }

            if (CheckWinner(Player.Total(), Dealer.Total()))
            {
                Console.WriteLine("Player WINS");
                Stats.AddVictory();
            }
            else if (CheckWinner(Dealer.Total(), Player.Total()))
            {
                Console.WriteLine("Dealer WINS");
                Stats.AddDefeat();
            }
            else
            {
                Console.WriteLine("Draw!!");
                Stats.AddDraw();
            }
        }
        
        private static string CardDisplay(List<Card> deck, bool dealer)
        {
            int count = 0;
            StringBuilder sb = new();

            foreach (Card card in deck)
            {
                if (dealer && count < 1)
                {
                    card.Hide();
                    count++;
                } 
                else
                {
                    card.Unhide();
                }

                sb.Append(card.ToString());
                sb.Append(' ');
            }
            return sb.ToString();
        }

        private static void Restart()
        {
            Player.Deck.Clear();
            Dealer.Deck.Clear();
            for (int i = 0; i <= 1; i++)
            {
                Player.AddCard();
                Dealer.AddCard();
            }
        }
        private static void Lin(string symbol)
        {
            string lin = symbol;
            for (int i = 1; i <= 29; i++)
            {
                lin += symbol;
            }
            Console.WriteLine(lin);
        }
    }
}
