using System.Collections.Generic;
using Core;
using UnityEngine;

namespace TableModel
{
    public class TableModel : ITableModel
    {
        private int _minCombinationLength;
        private int _maxCombinationLength;
        private float _chanceToGrowUp;
        private List<CardNode> _currentSequencesTopCards;
        private CardNode _bankSequenceTop;
        public TableModel(int minCombinationLength, int maxCombinationLength, float chanceToGrowUp)
        {
            _minCombinationLength = minCombinationLength;
            _maxCombinationLength = maxCombinationLength;
            _chanceToGrowUp = chanceToGrowUp;
            _currentSequencesTopCards = new List<CardNode>();
        }

        public void AddCardSequence(int cardAmount, Card topCard)
        {
            CardNode newCardModel = new CardNode(topCard);
            newCardModel.AddParents(cardAmount);
            _currentSequencesTopCards.Add(newCardModel);
        }

        public void Build()
        {
            List<CardNode> topCardsCombinations = GenerateTopCardsCombinations();
            int parentsAmount = 0;
            foreach (CardNode cardNode in _currentSequencesTopCards)
            {
                parentsAmount += cardNode.GetParentsAmount();
            }
            while (topCardsCombinations.Count > 1)
            {
                int currentCombinationIndex = Random.Range(0, topCardsCombinations.Count);
                //bankSequenceTop.Add
            }
        
        }

        private List<CardNode> GenerateTopCardsCombinations()
        {
            List<CardNode> resultCombinations = new List<CardNode>();
            return resultCombinations;
        }
        public Card GetBankActiveCard()
        {
            throw new System.NotImplementedException();
        }

        public int GetBankLength()
        {
            throw new System.NotImplementedException();
        }

        public Card GetBankTopCard()
        {
            throw new System.NotImplementedException();
        }

        public int GetSequenceLength(int squenceIndex)
        {
            throw new System.NotImplementedException();
        }

        public int GetSequencesAmount()
        {
            throw new System.NotImplementedException();
        }

        public Card GetSequenceTopCard(int squenceIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool NextBankCard()
        {
            throw new System.NotImplementedException();
        }

        public bool NextSquenceCard(int squenceIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool IsGameOver()
        {
            foreach(CardNode cardNode in _currentSequencesTopCards)
            {
                if (cardNode != null)
                {
                    return false;
                }
            }
            return true;
        }

        public void ResetModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
