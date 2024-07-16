
namespace BlackJack
{
    internal class Game
    {
        private static Actors Dealer = new();
        private static Actors Player = new();

        public static void Run()
        {
            Menu(dealer: true);
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
