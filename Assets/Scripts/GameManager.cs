using TableModel;
using TableViev;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ITableViev _tableViev;
    private ITableModel _tableModel;
    [Header("Cards combination generation parametrs")]
    [SerializeField] private const int _minCombinationLength = 2;
    [SerializeField] private const int _maxCombinationLength = 7;
    [SerializeField] private const float _chanceToGrowUp = 65.0f;

    private void Awake()
    {
        _tableViev = new TableViev.TableViev(SpawnManager.Instance);
        
        _tableModel = new TableModel.TableModel(_minCombinationLength, _maxCombinationLength, _chanceToGrowUp);
        for (var counter = 0; counter < _tableViev.GetSequencesAmount(); ++counter)
        {
            _tableModel.AddCardSequence(_tableViev.GetSequenceLength(counter), _tableViev.GetSequenceStartTopCard(counter));
        }
        _tableModel.Build();
        _tableViev.SetBankSequence(_tableModel.GetBankLength());
        _tableViev.SetActiveCard(_tableModel.GetBankActiveCard());
    }

    public void CardPressed(GameObject pressedCard)
    {
        int pressedCardSequenceIndex = _tableViev.FindSequenceIndexByTopObject(pressedCard);
        if (pressedCardSequenceIndex >= 0)
        {
            if (_tableModel.NextSquenceCard(pressedCardSequenceIndex))
            {
                _tableViev.SetSequenceTopCard(
                    pressedCardSequenceIndex,
                    _tableModel.GetSequenceLength(pressedCardSequenceIndex),
                    _tableModel.GetSequenceTopCard(pressedCardSequenceIndex));
            }
        } else
        {
            if (_tableModel.NextBankCard())
            {
                _tableViev.SetBankSequence(_tableModel.GetBankLength());
                _tableViev.SetActiveCard(_tableModel.GetBankActiveCard());
            }
        }
        if (_tableModel.IsGameOver())
        {
            _tableViev.Disable();
        }
    }

    public void ResetGame()
    {
        _tableModel.ResetModel();
        int sequenceIndex = _tableModel.GetSequencesAmount();
        for(; sequenceIndex > 0; --sequenceIndex)
        {
            _tableViev.SetSequenceTopCard(
                sequenceIndex,
                _tableModel.GetSequenceLength(sequenceIndex),
                _tableModel.GetSequenceTopCard(sequenceIndex));
            _tableViev.SetBankSequence(_tableModel.GetBankLength());
            _tableViev.SetActiveCard(_tableModel.GetBankActiveCard());
        }
    }

    private class SpawnManager : ISpawnManager
    {
        private SpawnManager() { }
        private static SpawnManager _b_Instance = null;
        public static SpawnManager Instance
        {
            get
            {
                if (_b_Instance == null)
                {
                    _b_Instance = new SpawnManager();
                }
                return _b_Instance;
            }
        }
        public GameObject CreateObject(GameObject gameObject, Transform transform)
        {
            return Instantiate(gameObject, transform.position, transform.rotation);
        }
    }
}