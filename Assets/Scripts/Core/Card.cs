namespace Core
{
    public class Card
    {
        public Card() {}
        public Card(Card card)
        {
            numeral = card.numeral;
            suit = card.suit;
        }

        public Suit suit;
        public Numeral numeral;
        public enum Suit
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        }
        public enum Numeral
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
    }
}
