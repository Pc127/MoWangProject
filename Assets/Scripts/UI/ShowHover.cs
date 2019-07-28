using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject show;

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.show.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.show.SetActive(false);
    }
}
