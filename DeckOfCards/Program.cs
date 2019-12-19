using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Card
    {
        public int Value;
        public string Suit;
        public string Face;

        public Card(int value, string suit, string face)
        {
            this.Value = value;
            this.Suit = suit;
            this.Face = face;
        }

        public void DisplayCard()
        {
            System.Console.WriteLine($"{this.Face} {this.Suit}");
        }
    }

    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            this.Reset();
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int shufflecount = 0; shufflecount < 1000; shufflecount++)
            {
                for (int i = this.Cards.Count - 1; i > 0; i--)
                {
                    int randomNumber = random.Next(i);
                    Card Temp = this.Cards[i];
                    this.Cards[i]=Cards[randomNumber];
                    this.Cards[randomNumber] = Temp;
                }
            }
            this.Cards.ForEach(card => card.DisplayCard());
        }

        public void Reset()
        {
            this.Cards = new List<Card>();
            string[] SUITS = {"Clubs","Spades","Hearts","Diamonds"};
            string[] FACES = {"Ace","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Jack","Queen","King"};
            for (int i=0; i <SUITS.Length; i++)
            {
                for (int j=0; j<FACES.Length; j++)
                {
                    this.Cards.Add(new Card(j+1, SUITS[i], FACES[j]));
                }
            }
            this.Shuffle();
        }

        public Card Draw
        {
            get {
                Card DrawnCard = this.Cards[0];
                this.Cards.Remove(DrawnCard);
                return DrawnCard;
            }
        }
    }

    public class Player
    {
        public string Name;
        private List<Card> Hand;

        public Player()
        {
            this.Hand = new List<Card>();
        }

        public void Draw(Deck EntireDeck) => this.Hand.Add(EntireDeck.Draw); 
        public void ShowCards() => this.Hand.ForEach(card => card.DisplayCard());
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck DealerDeck = new Deck();

        }
    }
}
