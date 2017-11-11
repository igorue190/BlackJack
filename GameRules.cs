using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
     class GameRules
    {
         ShowPhrase phrase = new ShowPhrase();         

        public  List<Card> HandOverTheCards(List<Card> Card, Card firstCard, Card secondCard)
        {
            Card.Add(firstCard);
            Card.Add(secondCard);
            return Card;
        }

        public void PlayerHasBJAnddealerHasAce(int playerValue, int dealerValue, int blackJackValue, ref int money, int currentBet)
        {
            var playersAnswer = phrase.ChoiceYesOrNo();
                if (playersAnswer == "y")
                {
                    Console.WriteLine("Accepted\n");                    
                }
                else if (playersAnswer == "n")
                {
                    Console.WriteLine("Rejected \n");
                   EqualsValue(playerValue, dealerValue, blackJackValue, ref money, currentBet);
                }                
        }

        public void PlayerHasBJAnddealerHasTen(int playerValue, int dealerValue, int blackJackValue, ref int money, int currentBet)
        {            
            EqualsValue(playerValue,  dealerValue, blackJackValue, ref  money,  currentBet);           
        }

        private void EqualsValue(int playerValue, int dealerValue, int blackJackValue, ref int money, int currentBet)
        {
            if (blackJackValue > dealerValue)
            { 
                phrase.PlayerWin(playerValue, dealerValue, ref money, currentBet);
            }
            else 
            { 
                phrase.NobodyWins(ref money); 
            }
        }

        public void DealerHasAce(int playerValue, int dealerValue, ref  int money, int currentBet)
        {
            string playersAnswer = phrase.ChoiceYesOrNo();
                if (playersAnswer == "y")
                {
                    Console.WriteLine("Accepted\n");                    
                }
                else if (playersAnswer == "n")
                {
                    Console.WriteLine("Rejected \n");

                    if (playerValue > dealerValue)
                    {
                         phrase.PlayerWin(playerValue, dealerValue,ref money, currentBet);
                    }
                    else if (playerValue < dealerValue)
                    {
                        phrase.DealerWin(dealerValue, playerValue,ref money, currentBet);
                    }
                    else if (playerValue == dealerValue)
                    {
                        Console.WriteLine("Nobody wins!");
                      
                    }
                }
        }

        public void Hit(List<Card> playersCard, Card newCardInHit, int dealerValue, int blackJackValue, ref int money, int currentBet)
        {            
            playersCard.Add(newCardInHit);
             Console.WriteLine("Hitted {0} of {1}",playersCard[playersCard.Count - 1].Face, playersCard[playersCard.Count - 1].Suit);

            var playerTotalCardsValue = playersCard.Sum(card => card.Value);
            Console.WriteLine("Total cards value now: {0}\n", playerTotalCardsValue);

            if (playerTotalCardsValue > blackJackValue)
            {
                phrase.DealerWin(dealerValue, playerTotalCardsValue,ref money, currentBet);                
            }
            else if (playerTotalCardsValue == blackJackValue)
            {             
                 phrase.PlayerWin(playerTotalCardsValue, dealerValue,ref money, currentBet);                      
            }
                                                                          
        }

        public void Stand(int playerValue, int dealerValue, int blackJackValue, ref int money, int currentBet, List<Card> dealersCard, int minPointForDealer, Card newCardInStand, List<Card> playersCard)
        {
            phrase.ShowDealerTwoCards(dealersCard[0].Face, dealersCard[0].Suit, dealersCard[1].Face, dealersCard[1].Suit);
   
            while (dealerValue < minPointForDealer)
            {
                dealerValue = phrase.DealersNewCard( dealersCard, newCardInStand, dealerValue);
            }
            dealerValue = dealersCard.Sum(card => card.Value);
            playerValue = playersCard.Sum(card => card.Value);
            Console.WriteLine("Total: {0}\n", dealerValue);

            if (dealerValue > blackJackValue)
            {
                 phrase.PlayerWin(playerValue, dealerValue,ref money, currentBet);
            }            
            else if (dealerValue > playerValue)
            {
                phrase.DealerWin(dealerValue, playerValue,ref money, currentBet);
            }
            else if (dealerValue < playerValue)
            {
                phrase.PlayerWin(playerValue, dealerValue,ref money, currentBet);                                     
            } 
        }          
    }
}
