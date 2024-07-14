using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour//, IPointerClickHandler
{
    Card card;
    private void Awake()
    {
        card = GetComponent<Card>();
    }
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            card.TellInfo();
            Destroy(card);
        }
    }

    void MousePointer()
    { 
        
    }

}
