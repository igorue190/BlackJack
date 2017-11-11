using System;
using System.Collections.Generic;
using BlackJack.Enums;

namespace BlackJack
{
    class Deck
    {
        List<Card> cards;
        const int numberOfSuit = 4;
        const int numberOfFace = 14;
        const int minValue = 1;
        const int maxValue = 10;
        Random random;
       

        public Deck()
        {
            Initialization();            
        }

        public int DeckCount { get { return cards.Count; } }

        public void Initialization()
        {                
            cards = new List<Card>();
            random = new Random();

            for (var i = 0; i < numberOfSuit; i++)
            {
                for (var j = 0; j < numberOfFace; j++)
                {
                    cards.Add(new Card { Suit = (Suit)i, Face = (Face)j, Value = ((Face)j != Face.Ace) ? Math.Min(j + minValue, maxValue) : maxValue+minValue });
                }
            }
            var cardsCount = cards.Count;
            while (cardsCount > 0)
            {
                cardsCount--;
                var k = random.Next(cardsCount + minValue);
                Card card = cards[k];
                cards[k] = cards[cardsCount];
                cards[cardsCount] = card;
            }
        }

        public Card CheckCard()
        {
            if (cards.Count <= 0)
            {
                Initialization();
            }
            Card returnedCart = cards[cards.Count - minValue];
            cards.RemoveAt(cards.Count - minValue);
            return returnedCart;
        }
    }
}
