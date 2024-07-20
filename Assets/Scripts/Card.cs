using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Card : MonoBehaviour
{
    // 0 monster 1 monster 2 potion 3 weapon
    [SerializeField] int cardType;
    [SerializeField] int cardValue;
    [SerializeField] string description;//remove later

    [SerializeField] SpriteRenderer cardImage;
    
    [SerializeField] Sprite monster0;
    [SerializeField] Sprite monster1;
    [SerializeField] Sprite potion;
    [SerializeField] Sprite weapon;

    [SerializeField] TextMeshPro valueText;
    [SerializeField] TextMeshPro valueText2;
    [SerializeField] TextMeshPro typeText;

    bool toldinfo=false;
    DungeonDeck dungeonDeck;
    // Start is called before the first frame update
    private void Awake()
    {
        dungeonDeck = FindObjectOfType<DungeonDeck>();
    }

    void Start()
    {
        //Debug.Log("PullingCardInfo");
        dungeonDeck.PulLCardMethod();
        SetProperties();
        SetCardSpriteColor();
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
            //set availibilit true on spawn point
            
            Debug.Log(cardType + " "+ cardValue + " "+description);
            Destroy(this.gameObject);
            //lower counter in CardSpawner
        }
    }
    public void SetToldInfoFalse()
    {
        toldinfo=false;
    }
    public void PullCardFromDeck()
    {
        
    }
    void SetCardSpriteColor()
    {   
        cardImage.color = Color.white;
    }
    public void SetProperties()
    {
        cardType = dungeonDeck.tempType;
        cardValue = dungeonDeck.tempValue;

        valueText.text = cardValue.ToString();
        valueText2.text = cardValue.ToString();
        SetCardType(cardType);
    }
    void SetCardType(int typeValue)
    {
        switch (typeValue)
        {
            case  0:
                typeText.text= "Monster0";
                cardImage.sprite = monster0;
                break;
            case 1:
                typeText.text= "Monster1";
                cardImage.sprite = monster1;
                break;
            case 2:
                typeText.text= "Potion";
                cardImage.sprite = potion;
                break;
            case 3:
                typeText.text= "Weapon";
                cardImage.sprite = weapon;
                break;
            default: ;
                break;
        }
            
    }
}
