using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int ID;
    public Button button;
    private Vector3 cardInitPosi;
    private Tween tween;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ID <= 0) return;
        button.interactable =  GameController.Instance.CanUseCard(ID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!button.interactable)
        {
            return;
        }
        tween = transform.DOLocalMove(cardInitPosi + new Vector3(0, 30, 0), 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!button.interactable)
        {
            return;
        }
        tween.Pause();
        transform.localPosition = cardInitPosi;
    }

    public void SetInitPosi()
    {
        cardInitPosi = transform.localPosition;
    }
}
