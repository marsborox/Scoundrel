using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    // 0 monster 1 monster 2 potion 3 weapon
    [SerializeField] int cardType;
    [SerializeField] int cardValue;
    [SerializeField] string description;//remove later

    
    bool toldinfo=false;
    DungeonDeck dungeonDeck;
    // Start is called before the first frame update
    private void Awake()
    {
        dungeonDeck = FindObjectOfType<DungeonDeck>();
    }

    void Start()
    {
        Debug.Log("PullingCardInfo");
        dungeonDeck.PulLCardMethod();
        SetProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TellInfo()
    {
        if(!toldinfo)
        {
            //Debug.Log("Telling Info");
            //toldinfo = true;
            Debug.Log(cardType + " "+ cardValue + " "+description);
        }
    }
    public void SetToldInfoFalse()
    {
        toldinfo=false;
    }
    public void PullCardFromDeck()
    {
        
    }
    public void SetProperties()
    {
        cardType = dungeonDeck.tempType;
        cardValue = dungeonDeck.tempValue;
    }
}
