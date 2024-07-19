
namespace BlackJack
{
    internal class Game
    {
        private static Actors Dealer = new();
        private static Actors Player = new();

        public static void Run()
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
            if (Player.Total() < 22 && Player.Total() > Dealer.Total() || Dealer.Total() > 21)
            {
                Console.WriteLine("Player WINS");
            }
            else if (Dealer.Total() < 22 && Dealer.Total() > Player.Total() || Player.Total() > 21)
            {
                Console.WriteLine("Dealer WINS");
            }
            else
            {
                Console.WriteLine("Draw!!");
            }
        }
        
        private static string CardDisplay(List<Card> deck, bool dealer)
        {
            int count = 0;
            string stringDeck = "";

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


                stringDeck += card.ToString();
                stringDeck += " ";
            }
            return stringDeck;
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
