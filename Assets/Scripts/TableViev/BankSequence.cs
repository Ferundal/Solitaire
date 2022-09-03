using System.Collections.Generic;
using UnityEngine;

namespace TableViev
{
    public class BankSequence
    {
        private List<GameObject> _cards;
        private int _activeCardsAmount;
        private float _offset = -1.0f;
        private GameObject _bankPosition;
        private ISpawnManager _spawnManager;
        public int Count
        {
            get
            {
                return _cards.Count;
            }
        }
        public BankSequence(GameObject bankPosition, ISpawnManager spawnManager) {
            _cards = new List<GameObject>();
            this._bankPosition = bankPosition;
            this._spawnManager = spawnManager;
        }

        public void AddCard(GameObject card)
        {
            _cards.Add(card);
            if (_cards.Count > 1) {
                Vector3 newPosition;
                if (_offset < 0)
                {
                    float offset = card.GetComponent<RectTransform>().rect.width / 5;
                }
                for (int existingCardsIndex = 1; existingCardsIndex < _cards.Count; ++existingCardsIndex)
                {
                    newPosition = _cards[existingCardsIndex].transform.position;
                    newPosition.y -= _offset;
                    _cards[existingCardsIndex].transform.position = newPosition;
                }
            }
        }
        public void SetActive(int cardsAmount)
        {
            if (cardsAmount < 0)
            {
                cardsAmount = 0;
            }
            else if (cardsAmount > _cards.Count)
            {
                cardsAmount = _cards.Count;
            }
            if (cardsAmount > _activeCardsAmount)
            {
                for (; _activeCardsAmount < cardsAmount; ++_activeCardsAmount)
                {
                    _cards[_activeCardsAmount - 1].SetActive(true);
                }
            }
            else
            {
                for (; _activeCardsAmount > cardsAmount; --_activeCardsAmount)
                {
                    _cards[_activeCardsAmount - 1].SetActive(false);
                }
            }

        }
    }
}
