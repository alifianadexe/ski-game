using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class TextClick : MonoBehaviour, IPointerDownHandler
{

    TextMeshProUGUI titleText;
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    
    private void Start()
    {
        titleText = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        titleText.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
    }

}
