using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Enums;

namespace BlackJack
{
    public class ShowPhrase
    {
       
        public void DealerWin(int dealerValue, int playerValue, ref int money, int currentBet)
        {
           
            Console.WriteLine("Dealer has " +dealerValue+ " and player has "  + playerValue +" , dealer wins!");
           GameSession.isWin = true;
             money -= currentBet;           
        }

        public void PlayerWin(int playerValue, int dealerValue,ref int money, int currentBet)
        {
            Console.WriteLine("Dealer has " + dealerValue + " and player has " + playerValue + " , player wins!");
            GameSession.isWin = true;
            money += currentBet;           
        }

        public void PlayerCardsInfo(Face faceCard1, Suit suitCard1, Face faceCard2, Suit suitCard2, int value)
        {
            Console.WriteLine("Player");
            Console.WriteLine("Card 1 {0} of {1}", faceCard1, suitCard1);
            Console.WriteLine("Card 2 {0} of {1}", faceCard2, suitCard2);
            Console.WriteLine("Total: {0}\n", value);
        }

        public void DealerCardsInfo(Face faceCard, Suit suitCard, int value)
        {
            Console.WriteLine("Dealer");
            Console.WriteLine("Card 1 {0} of {1}", faceCard, suitCard);
            Console.WriteLine("Card 2 -  Hidden Card");
            Console.WriteLine("Total: {0}\n", value);
        }

        public void ShowDealerTwoCards(Face faceCard1, Suit suitCard1, Face faceCard2, Suit suitCard2)
        {
            Console.WriteLine("Dealer");
            Console.WriteLine("Card 1 {0} of {1}", faceCard1, suitCard1);
            Console.WriteLine("Card 2 {0} of {1}", faceCard2, suitCard2);
        }

        public void GameBalance(int deckCount, int money)
        {
            Console.WriteLine("Balance of cards: {0}", deckCount);
            Console.WriteLine("Money: {0}", money);
            Console.WriteLine("Please bid (1 - {0})\n", money);
        }

        public int DealersNewCard(List<Card> dealersCard, Card newCardInStand, int dealerValue)
        {
            dealersCard.Add(newCardInStand);
            dealerValue = dealersCard.Sum(card => card.Value);
            Console.WriteLine("Card {0}: {1} of {2}", dealersCard.Count, dealersCard[dealersCard.Count -1].Face, dealersCard[dealersCard.Count-1].Suit);
            return dealerValue;
        }

        public string ChoiceHitOrStand()
        {
            Console.WriteLine("Please choose a valid option: Hit - 'h' or Stand - 's' \n");
            string playersAnswer = Console.ReadLine();
            string hit = "h";
            string stand = "s";
            while (playersAnswer != hit && playersAnswer != stand)
            {
                Console.WriteLine("Please choose a valid option: Hit - 'h' or Stand - 's' \n");
                playersAnswer = Console.ReadLine();
            }
            return playersAnswer;
        }

        public string ChoiceYesOrNo()
        {
            Console.WriteLine("Insurance?(y or n)\n");
            string playersAnswer = Console.ReadLine();
            string yes = "y";
            string no = "n";
            while (playersAnswer != yes && playersAnswer != no)
            {
                Console.WriteLine("Insurance?(y or n)\n");
                playersAnswer = Console.ReadLine();
            }
            return playersAnswer;
        }

        public int PlaceBet(int minBet, int money)
        {
            string input = Console.ReadLine();
            int currentBet;
            while (!Int32.TryParse(input, out currentBet) || currentBet < minBet || currentBet > money)
            {
                Console.WriteLine("Incorrect format, please bid (1 - {0})\n", money);
                input = Console.ReadLine();
            }
            return currentBet;
        }

        public void NobodyWins(ref int money)
        {
            Console.WriteLine("Nobody wins!");
            
        }        
    }

} 
           

