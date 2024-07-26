using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshPro healthCounterText;
    public int health =2;

    public Button clearDungeon;

    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject monsterSlot;
    [SerializeField] TextMeshPro recentMonsterValue;


    public bool usedPotion = false;
    public bool resetDungeon = false;

    public bool weaponActive = false;
    public bool monsterOnSlot = false;
    public bool usingWeapon = false;



    public int weaponDmg;
    public int recentMonsterDmg;
    public int tempRecentMonsterDmg;


    CardSpawner cardSpawner;
    Card card;

    public Button clearDungeonButton;
    public Button useWeapon;
    public Button dontUseWeapon;

    
    private void Awake()
    {
       cardSpawner = FindObjectOfType<CardSpawner>();
       card=FindObjectOfType<Card>(); 
    }
    private void Start()
    {
        UpdateHealth();
        Button clrDung = clearDungeonButton.GetComponent<Button>();
        clrDung.onClick.AddListener(ClearDungeon);

        Button useWpn = useWeapon.GetComponent<Button>();
        useWpn.onClick.AddListener(AttackWithWeapon);

        Button noUseWpn = dontUseWeapon.GetComponent<Button>();
        noUseWpn.onClick.AddListener(AttackWithoutWeapon);

        DisableWeaponButtons();
    }



    //put weapon into weapon slot
    public void TakeWeapon(GameObject newWeapon)
    {
        for (var i = weaponSlot.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(weaponSlot.transform.GetChild(i).gameObject);
        }
        weaponActive = true;
        newWeapon.transform.parent = weaponSlot.transform;
        newWeapon.transform.position = weaponSlot.transform.position;
    }
    //put monster when weapon is used on it
    public void AttackedMonster(GameObject newMonster)
    {
        for (var i = weaponSlot.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(weaponSlot.transform.GetChild(i).gameObject);
        }
        monsterOnSlot = true;
        newMonster.transform.parent = monsterSlot.transform;
        newMonster.transform.position = monsterSlot.transform.position;
    }
    public void UpdateHealth()
    {
        healthCounterText.text = health.ToString();
    }
    
    public void ResetOfUsed()
    {
        usedPotion = false;
        resetDungeon = false;
        clearDungeon.gameObject.SetActive(true);
    }


    public void ClearDungeon()
    {
        cardSpawner.ClearDungeon();
        clearDungeon.gameObject.SetActive(false);
    }

    public void EnableWeaponButtons()
    {
        
        useWeapon.gameObject.SetActive(true); 
        dontUseWeapon.gameObject.SetActive(true);
    }

    public void DisableWeaponButtons()
    {
        cardSpawner.ClearDungeon();
        useWeapon.gameObject.SetActive(false);
        dontUseWeapon.gameObject.SetActive(false);
    }


    public void AttackWithWeapon()
    {
        recentMonsterDmg = tempRecentMonsterDmg;
        recentMonsterValue.text = recentMonsterDmg.ToString();
        card.MonsterHitWithWeapon();
        DisableWeaponButtons();
    }

    public void AttackWithoutWeapon()
    {
        card.MonsterHitNoWeapon();
        DisableWeaponButtons();
    }
}
