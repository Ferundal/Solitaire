using System.Collections.Generic;
using UnityEngine;

public class CardSequence
{
    private List<GameObject> cards;
    private int activeCardsAmount;

    public int Count
    {
        get
        {
            return cards.Count;
        }
    }

    private CardSequence(GameObject card)
    {
        activeCardsAmount = 1;
        cards = new List<GameObject>(1);
        cards.Add(card);
    }

    public GameObject GetCard(int cardIndex)
    {
        return cards[cardIndex];
    }

    public void SetActive(int cardsAmount)
    {
        if (cardsAmount < 0)
        {
            cardsAmount = 0;
        } else if (cardsAmount > cards.Count)
        {
            cardsAmount = cards.Count;
        }
        if (cardsAmount > activeCardsAmount)
        {
            for (; activeCardsAmount < cardsAmount; ++activeCardsAmount)
            {
                cards[activeCardsAmount - 1].SetActive(true);
            }
        } else
        {
            for (; activeCardsAmount > cardsAmount; --activeCardsAmount)
            {
                cards[activeCardsAmount - 1].SetActive(false);
            }
        }
        
    }

    private bool IsConnected(GameObject targetCard)
    {
        RectTransform targetCardRectTransform = targetCard.GetComponent<RectTransform>();
        RectTransform cardInSequenceRectTransform;
        Vector2 realDistance;
        float distanceLimit;
        foreach (GameObject cardInSequence in this.cards)
        {
            cardInSequenceRectTransform = cardInSequence.GetComponent<RectTransform>();
            realDistance = targetCardRectTransform.position - cardInSequenceRectTransform.position;
            distanceLimit = (targetCardRectTransform.rect.width + cardInSequenceRectTransform.rect.width) / 2;
            if (Mathf.Abs(realDistance.x) < distanceLimit)
            {
                distanceLimit = (targetCardRectTransform.rect.height + cardInSequenceRectTransform.rect.height) / 2;
                if (Mathf.Abs(realDistance.y) < distanceLimit)
                {
                    return true;
                }
            }
        }
        return false;
    }


    private void AddLast(GameObject card)
    {
        cards[activeCardsAmount - 1].isStatic = true;
        ++activeCardsAmount;
        this.cards.Add(card);
    }

    public static List<CardSequence> FindCardSequences(GameObject [] cardGameObjects)
    {
        List<CardSequence> resultCardSequences = new List<CardSequence>();
        foreach(GameObject cardGameObject in cardGameObjects)
        {
            bool isConnected = false;
            foreach(CardSequence cardSequence in resultCardSequences)
            {
                if (cardSequence.IsConnected(cardGameObject))
                {
                    cardSequence.AddLast(cardGameObject);
                    isConnected = true;
                    break;
                }
            }
            if (!isConnected)
            {
                resultCardSequences.Add(new CardSequence(cardGameObject));
            }
            
        }
        return (resultCardSequences);
    }

    public override string ToString() {
        string result = "";
        foreach(GameObject card in cards)
        {
            result += card.name + " ";
        }
        return result;
    }

    public bool isTopGameObject(GameObject gameObject)
    {
        if (cards[activeCardsAmount - 1] == gameObject)
        {
            return true;
        }
        return false;
    }

}
