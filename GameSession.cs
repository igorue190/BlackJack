using System.Collections.Generic;
using System.Linq;
using BlackJack.Enums;

namespace BlackJack
{
    class GameSession 
    {
        public int money;
        Deck deck;
        GameRules gameRules;
        ShowPhrase phrase;
        List<Card> playersCard;
        List<Card> dealersCard;

        const int blackJackValue = 21;
        const int minNumbersCardsInDeck = 5;
        const int minBet = 1;
        const int maxPoint = 10;
        const int minPointForDealer = 17;
        public static bool isWin = false;

        public GameSession()
        {
            money = 200;
            deck = new Deck();
            gameRules = new GameRules();
            phrase = new ShowPhrase();            
        }

        public void Game()
        {            

            if (deck.DeckCount < minNumbersCardsInDeck)
            {
                deck.Initialization();
            }

            var currentBet = InitialData();           
            var playerTotalValue = playersCard.Sum(card => card.Value);
            var dealerTotalValue = dealersCard.Sum(card => card.Value);

            if (playerTotalValue == blackJackValue)
            {
                if (dealersCard[0].Face == Face.Ace)
                {
                    gameRules.PlayerHasBJAnddealerHasAce(playerTotalValue, dealerTotalValue, blackJackValue, ref money, currentBet);
                }
                else if (dealersCard[0].Face == Face.Ten)
                {
                    gameRules.PlayerHasBJAnddealerHasTen(playerTotalValue, dealerTotalValue, blackJackValue, ref money, currentBet);
                }
                else if (dealersCard[0].Face != Face.Ace && dealersCard[0].Face != Face.Ten)
                {
                   phrase.PlayerWin(playerTotalValue, dealerTotalValue, ref money, currentBet);
                }
            }
           else if ((dealerTotalValue != blackJackValue) && (dealersCard[0].Face == Face.Ace))
            {
                gameRules.DealerHasAce(playerTotalValue, dealerTotalValue, ref money, currentBet);
            }
            while (isWin == false)   
            {
                string playersAnswer = phrase.ChoiceHitOrStand();
                if (playersAnswer == "h")
                {                  
                        gameRules.Hit(playersCard, deck.CheckCard(), dealerTotalValue, blackJackValue, ref money, currentBet);
                        continue;                   
                }
                else if (playersAnswer == "s")
                {
                    gameRules.Stand(playerTotalValue, dealerTotalValue, blackJackValue, ref money, currentBet, dealersCard, minPointForDealer, deck.CheckCard(), playersCard);
                    break;
                }
            }               
        }
        private int InitialData()
        {
            phrase.GameBalance(deck.DeckCount, money);
            int currentBet = phrase.PlaceBet(minBet, money);

            playersCard = new List<Card>();
            playersCard = gameRules.HandOverTheCards(playersCard, deck.CheckCard(), deck.CheckCard());
            phrase.PlayerCardsInfo(playersCard[0].Face, playersCard[0].Suit, playersCard[1].Face, playersCard[1].Suit, playersCard[0].Value + playersCard[1].Value);

            dealersCard = new List<Card>();
            dealersCard = gameRules.HandOverTheCards(dealersCard, deck.CheckCard(), deck.CheckCard());
            phrase.DealerCardsInfo(dealersCard[0].Face, dealersCard[0].Suit, dealersCard[0].Value);
            return currentBet;
        }
    }
}