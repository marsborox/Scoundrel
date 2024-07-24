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
        //OnMouseDown();
    }

    //when click on card do "stuff"
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            card.DoCardAction();
            
            //Destroy(this);
            
        }
    }
}
