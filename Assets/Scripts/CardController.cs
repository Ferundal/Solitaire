using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler
{
    private GameManager _gameManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        _gameManager.CardPressed(this.gameObject);
    }

    private void Awake()
    {
        _gameManager = (GameManager)GameManager.FindObjectOfType(typeof(GameManager));
    }
}
