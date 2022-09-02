using System.Collections.Generic;
using UnityEngine;

public class BankSequence
{
    private List<GameObject> cards;
    private int activeCardsAmount;
    private float offset = -1.0f;
    private GameObject bankPosition;
    private ISpawnManager spawnManager;
    public int Count
    {
        get
        {
            return cards.Count;
        }
    }
    public BankSequence(GameObject bankPosition, ISpawnManager spawnManager) {
        cards = new List<GameObject>();
        this.bankPosition = bankPosition;
        this.spawnManager = spawnManager;
    }

    public void AddCard(GameObject card)
    {
        cards.Add(card);
        if (cards.Count > 1) {
            Vector3 newPosition;
            if (offset < 0)
            {
                float offset = card.GetComponent<RectTransform>().rect.width / 5;
            }
            for (int existingCardsIndex = 1; existingCardsIndex < cards.Count; ++existingCardsIndex)
            {
                newPosition = cards[existingCardsIndex].transform.position;
                newPosition.y -= offset;
                cards[existingCardsIndex].transform.position = newPosition;
            }
        }
    }
    public void SetActive(int cardsAmount)
    {
        if (cardsAmount < 0)
        {
            cardsAmount = 0;
        }
        else if (cardsAmount > cards.Count)
        {
            cardsAmount = cards.Count;
        }
        if (cardsAmount > activeCardsAmount)
        {
            for (; activeCardsAmount < cardsAmount; ++activeCardsAmount)
            {
                cards[activeCardsAmount - 1].SetActive(true);
            }
        }
        else
        {
            for (; activeCardsAmount > cardsAmount; --activeCardsAmount)
            {
                cards[activeCardsAmount - 1].SetActive(false);
            }
        }

    }
}
