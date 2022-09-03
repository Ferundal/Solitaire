using System.Collections.Generic;
using UnityEngine;

namespace TableViev
{
    public class CardSequence
    {
        private List<GameObject> _cards;
        private int _activeCardsAmount;

        public int Count
        {
            get
            {
                return _cards.Count;
            }
        }

        private CardSequence(GameObject card)
        {
            _activeCardsAmount = 1;
            _cards = new List<GameObject>(1);
            _cards.Add(card);
        }

        public GameObject GetCard(int cardIndex)
        {
            return _cards[cardIndex];
        }

        public void SetActive(int cardsAmount)
        {
            if (cardsAmount < 0)
            {
                cardsAmount = 0;
            } else if (cardsAmount > _cards.Count)
            {
                cardsAmount = _cards.Count;
            }
            if (cardsAmount > _activeCardsAmount)
            {
                for (; _activeCardsAmount < cardsAmount; ++_activeCardsAmount)
                {
                    _cards[_activeCardsAmount - 1].SetActive(true);
                }
            } else
            {
                for (; _activeCardsAmount > cardsAmount; --_activeCardsAmount)
                {
                    _cards[_activeCardsAmount - 1].SetActive(false);
                }
            }
        
        }

        private bool IsConnected(GameObject targetCard)
        {
            RectTransform targetCardRectTransform = targetCard.GetComponent<RectTransform>();
            RectTransform cardInSequenceRectTransform;
            Vector2 realDistance;
            float distanceLimit;
            foreach (GameObject cardInSequence in this._cards)
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
            _cards[_activeCardsAmount - 1].isStatic = true;
            ++_activeCardsAmount;
            this._cards.Add(card);
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
            foreach(GameObject card in _cards)
            {
                result += card.name + " ";
            }
            return result;
        }

        public bool IsTopGameObject(GameObject gameObject)
        {
            if (_cards[_activeCardsAmount - 1] == gameObject)
            {
                return true;
            }
            return false;
        }

    }
}
