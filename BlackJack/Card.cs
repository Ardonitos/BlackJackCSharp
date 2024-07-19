
namespace BlackJack
{
    internal class Card
    {
        public string? Name { get; private set; }
        public char Suits { get; private set; }
        public int Value { get; private set; }
        public bool Hidden { get; private set; }
        public Card()
        {
            GetValues();
            Hidden = false;
        }
        private void GetValues()
        {
            Dictionary<string, int> cards = new()
            {
                {"A", 1},
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
                {"10", 10},
                {"K", 10},
                {"Q", 10},
                {"J", 10}
            };

            Random rdn = new();
            List<string> cardKeys = new(cards.Keys);
            int randIndex = rdn.Next(cardKeys.Count);
            string cardKey = cardKeys[randIndex];
            List<char> suits = ['♥', '♠', '♦', '♣'];
            int suitsIndex = rdn.Next(suits.Count);

            Name = cardKey;
            Suits = suits[suitsIndex];
            Value = cards[cardKey];
        }
        public void Hide()
        {
            Hidden = true;
            return;
        }
        public void Unhide()
        {
            Hidden = false;
            return;
        }
        public override string ToString()
        {
            if (!Hidden)
            {
                return $"{Name}{Suits}";
            }
            return "*";
        }
    }
}
