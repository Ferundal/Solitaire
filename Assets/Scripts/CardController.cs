using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerDownHandler
{
    private GameManager gameManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.CardPressed(this.gameObject);
    }

    private void Awake()
    {
        gameManager = (GameManager)GameManager.FindObjectOfType(typeof(GameManager));
    }
}
