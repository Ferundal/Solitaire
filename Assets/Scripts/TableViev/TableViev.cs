using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableViev : ITableViev
{
    private List<CardSequence> cardSequences;
    private BankSequence bankSequence;

    public TableViev (ISpawnManager spawnManager)
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        cardSequences = CardSequence.FindCardSequences(cards);
        foreach (CardSequence card in cardSequences)
        {
            Debug.Log(card);
        }
        GameObject bankPosition = GameObject.FindGameObjectWithTag("Bank");
        bankSequence = new BankSequence(bankPosition, spawnManager);
    }

    public int GetSequencesAmount()
    {
        return cardSequences.Count;
    }

    public int GetSequenceLength(int squenceIndex)
    {
        return cardSequences[squenceIndex].Count;
    }

    public Card GetSequenceStartTopCard(int squenceIndex)
    {
        string spriteName = cardSequences[squenceIndex].GetCard(cardSequences[squenceIndex].Count - 1).GetComponent<Image>().sprite.name;
        return CardFromString(spriteName);
    }

    public void SetSequenceTopCard(int squenceIndex, int cardIndex, Card card)
    {
        CardSequence cardSequence = cardSequences[squenceIndex];
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
        for(int counter = 0; counter < cardSequences.Count; ++counter)
        {
            if (cardSequences[counter].isTopGameObject(gameObject))
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
