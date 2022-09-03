using Core;

namespace TableModel
{
    public interface ITableModel
    {
        public void AddCardSequence(int cardAmount, Card topCard);
        public void Build();
        public int GetSequencesAmount();
        public int GetSequenceLength(int squenceIndex);
        public Card GetSequenceTopCard(int squenceIndex);
        public bool NextSquenceCard(int squenceIndex);
        public int GetBankLength();
        public Card GetBankActiveCard();
        public bool NextBankCard();
        public bool IsGameOver();
        public void ResetModel();
    }
}
