using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine.LowLevel;

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

    public int myPosition;

    bool toldinfo=false;

    Player player;
    DungeonDeck dungeonDeck;
    CardSpawner cardSpawner;

    
    
    private void Awake()
    {
        dungeonDeck = FindObjectOfType<DungeonDeck>();
        cardSpawner = FindObjectOfType<CardSpawner>();
        player=FindObjectOfType<Player>();
    }

    void Start()
    {
        //Debug.Log("PullingCardInfo");
        dungeonDeck.PulLCardMethod();
        SetProperties();
        SetCardSpriteColor();
        myPosition = cardSpawner.cardPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PotionUsedColorIndicator();
    }

    public void DoCardAction()
    {
        if (cardType == 0 || cardType == 1)
        {
            Debug.Log("Monster");
            WeaponUseCheck();
            Monster(); 
        }
        else if (cardType == 2)
        {
            Debug.Log("Potion");
            Potion(); 
        }
        else if (cardType == 3)
        {
            Debug.Log("Weapon");
            Weapon(); 
        }

        else Debug.Log("Error unknown cartd type");


        Debug.Log(cardType + " " + cardValue + " " + description);
        
        cardSpawner.usedCardCounter++;
        player.UpdateHealth();
        player.clearDungeon.gameObject.SetActive(false);
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


    //these methods - do card stuff based on what card is it
    void Monster()
    {
        player.health = player.health - cardValue;
        //is there weapon

        //do damage over wpn

        //do dmg
        Destroy(this.gameObject);
    }

    void Potion()
    {
        //was potion used this turn
        //if no, heal
        if (!(player.usedPotion))
        {
            player.usedPotion = true;
            player.health = player.health + cardValue;
            if (player.health > 20)
            {
                player.health = 20;
            }
        }
        Destroy(this.gameObject);
    }

    void PotionUsedColorIndicator()
    {
        if (player.usedPotion&&cardType==2)
        { cardImage.color = Color.black; }

        if (!player.usedPotion && cardType == 2 )
        { cardImage.color = Color.white; }
    }

    void Weapon()
    {
        player.TakeWeapon(gameObject);
    }

    void WeaponUseCheck()
    { 
        
    }
    void UseWeapon()
    { 
    
    }
}
