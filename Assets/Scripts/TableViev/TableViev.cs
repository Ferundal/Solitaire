using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace TableViev
{
    public class TableViev : ITableViev
    {
        private List<CardSequence> _cardSequences;
        private BankSequence _bankSequence;

        public TableViev (ISpawnManager spawnManager)
        {
            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
            _cardSequences = CardSequence.FindCardSequences(cards);
            foreach (CardSequence card in _cardSequences)
            {
                Debug.Log(card);
            }
            GameObject bankPosition = GameObject.FindGameObjectWithTag("Bank");
            _bankSequence = new BankSequence(bankPosition, spawnManager);
        }

        public int GetSequencesAmount()
        {
            return _cardSequences.Count;
        }

        public int GetSequenceLength(int squenceIndex)
        {
            return _cardSequences[squenceIndex].Count;
        }

        public Card GetSequenceStartTopCard(int squenceIndex)
        {
            string spriteName = _cardSequences[squenceIndex].GetCard(_cardSequences[squenceIndex].Count - 1).GetComponent<Image>().sprite.name;
            return CardFromString(spriteName);
        }

        public void SetSequenceTopCard(int squenceIndex, int cardIndex, Card card)
        {
            CardSequence cardSequence = _cardSequences[squenceIndex];
            cardSequence.SetActive(cardIndex);
        }

        public void SetBankSequence(int cardAmount)
        {

        }

        public void SetActiveCard(Card card)
        {
        
        }

        public GameObject CardToPrefab(Card card)
        {
            return null;
        }

        private Card CardFromString(string cardName)
        {
            bool isCardNameConvertible = false;
            Card resultCard = new Card();
            string[] cardSuitsNames = Enum.GetNames(typeof(Card.Suit));
            Array cardSuitsValues = Enum.GetValues(typeof(Card.Suit));
            for (int counter = 0; counter < cardSuitsNames.Length; ++counter)
            {
                if (cardName.IndexOf(cardSuitsNames[counter]) > -1)
                {
                    resultCard.suit = (Card.Suit)cardSuitsValues.GetValue(counter);
                    isCardNameConvertible = true;
                    break;
                }
            }
            if (!isCardNameConvertible)
            {
                return null;
            }
            isCardNameConvertible = false;
            string[] cardNumeralsNames = Enum.GetNames(typeof(Card.Numeral));
            Array cardNumeralsValues = Enum.GetValues(typeof(Card.Numeral));
            for (int counter = 0; counter < cardNumeralsNames.Length; ++counter)
            {
                if (cardName.IndexOf(cardNumeralsNames[counter]) > -1)
                {
                    resultCard.numeral = (Card.Numeral)cardNumeralsValues.GetValue(counter);
                    isCardNameConvertible = true;
                    break;
                }
            }
            if (!isCardNameConvertible)
            {
                return null;
            }
            return resultCard;
        }

        public int FindSequenceIndexByTopObject(GameObject gameObject)
        {
            for(int counter = 0; counter < _cardSequences.Count; ++counter)
            {
                if (_cardSequences[counter].IsTopGameObject(gameObject))
                {
                    return counter;
                }
            }
            return (-1);
        }

        public void Disable()
        {

        }
    }
}
