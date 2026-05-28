using System;
using System.Collections.Generic;
using System.Text;

namespace CardClasses
{
    public class Deck
    {
        private static Random gen = new Random();

        private List<Card> cards = new List<Card>();

        public Deck()
        {
            for (int value = 1; value <= 13; value++)
            {
                for (int suit = 1; suit <= 4; suit++)
                {
                    cards.Add(new Card(value, suit));
                }
            }
        }

        public int NumCards
        {
            get { return cards.Count; }
        }

        public bool IsEmpty
        {
            get { return cards.Count == 0; }
        }

        public Card this[int i]
        {
            get { return cards[i]; }
        }

        public Card Deal()
        {
            if (!IsEmpty)
            {
                Card c = cards[0];
                cards.RemoveAt(0);
                return c;
            }

            return null;
        }

        public void Shuffle()
        {
            for (int i = 0; i < NumCards; i++)
            {
                int rnd = gen.Next(i, NumCards);

                Card temp = cards[i];
                cards[i] = cards[rnd];
                cards[rnd] = temp;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (Card c in cards)
            {
                output.AppendLine(c.ToString());
            }

            return output.ToString();
        }
    }

    public class Card
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            string[] values =
            {
                "Invalid",
                "Ace", "2", "3", "4", "5", "6",
                "7", "8", "9", "10",
                "Jack", "Queen", "King"
            };

            string[] suits =
            {
                "Invalid",
                "Clubs", "Diamonds", "Hearts", "Spades"
            };

            return values[Value] + " of " + suits[Suit];
        }
    }
    internal class Hand
    {
        protected List<Card> cards;

        public int NumCards
        {
            get { return cards.Count; }
        }

        public Hand()
        {
            cards = new List<Card>();
        }

        public Hand(Deck d, int numCards)
        {
            cards = new List<Card>();

            for (int i = 0; i < numCards; i++)
            {
                cards.Add(d.Deal());
            }
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public Card Discard(int index)
        {
            Card card = cards[index];
            cards.RemoveAt(index);
            return card;
        }

        public Card GetCard(int index)
        {
            return cards[index];
        }

        public Card this[int index]
        {
            get { return cards[index]; }
        }

        public bool HasCard(Card c)
        {
            return cards.Contains(c);
        }

        public bool HasCard(int value)
        {
            foreach (Card c in cards)
            {
                if (c.Value == value)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasCard(int value, int suit)
        {
            foreach (Card c in cards)
            {
                if (c.Value == value && c.Suit == suit)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(Card c)
        {
            return cards.IndexOf(c);
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value && cards[i].Suit == suit)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (Card c in cards)
            {
                output.AppendLine(c.ToString());
            }

            return output.ToString();
        }
    }
}