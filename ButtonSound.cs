using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, ISelectHandler{

    public AudioSource[] audio;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        audio[0].Play();
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
        audio[1].Play();
    }

}
