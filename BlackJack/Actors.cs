
namespace BlackJack
{
    internal class Actors
    {
        public List<Card> Deck { get; private set; }

        public Actors() 
        {
            Deck = [];
            AddCard();
            AddCard();
        }


        public void AddCard()
        {
            Card card = new();
            Deck.Add(card);
        }

        public int Total()
        {
            int sum = 0;
            foreach (Card card in Deck)
            {
                sum += card.Value;
            }
            return sum;
        }
    }
}
