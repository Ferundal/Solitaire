
using UnityEngine;
using System;

public class CardModel : Card
{
    public CardModel() { }
    public CardModel(Card card) : base(card) {

    }
    public CardModel CreateHigher()
    {
        CardModel cardModel = new CardModel(this);
        if (numeral == Card.Numeral.Ace)
        {
            cardModel.numeral = Card.Numeral.Two;
        } else
        {
            ++cardModel.numeral;
        }
        return cardModel;
    }

    public CardModel CreateLower()
    {
        CardModel cardModel = new CardModel(this);
        if (numeral == Card.Numeral.Two)
        {
            cardModel.numeral = Card.Numeral.Ace;
        }
        else
        {
            --cardModel.numeral;
        }
        return cardModel;
    }

    public void SetRandomSuit()
    {
        Array suitValues = Enum.GetValues(typeof(Card.Suit));
        int suitCapacity = suitValues.Length;
        suit = (Card.Suit)suitValues.GetValue(UnityEngine.Random.Range(0, suitCapacity));
    }
}
