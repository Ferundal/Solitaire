using UnityEngine;

public interface ITableViev
{
    public int GetSequencesAmount();
    public int GetSequenceLength(int squenceIndex);
    public Card GetSequenceStartTopCard(int squenceIndex);
    public void SetSequenceTopCard(int squenceIndex, int cardIndex, Card card);
    public void SetBankSequence(int cardAmount);
    public void SetActiveCard(Card card);
    public GameObject CardToPrefab(Card card);
    public int FindSequenceIndexByTopObject(GameObject gameObject);
    public void Disable();
}
