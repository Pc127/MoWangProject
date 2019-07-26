using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowBuffLogo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Buff buff;

    public GameObject show;

    public Image image;

    public Text text;


    public void InitBuff(Buff buff)
    {
        this.buff = buff;
        foreach (var item in Resources.LoadAll<Sprite>("Buff/buff")) {
            if(item.name == buff.name)
            {
                this.image.sprite = item;
            }
        };
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.show.SetActive(true);
        this.text.text = BuffArray.GetInstance().myBuffs[buff.name].Attribute();
        Debug.Log("鼠标进来了");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.show.SetActive(false);
        Debug.Log("鼠标出去了");
    }

}
