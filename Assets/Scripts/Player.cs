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

    public bool usedPotion = false;
    public bool resetDungeon = false;

    bool weaponActive = false;
    bool monsterOnSlot = false;
    CardSpawner cardSpawner;

    public Button clearDungeonButton;
    private void Awake()
    {
       cardSpawner = FindObjectOfType<CardSpawner>();
        
    }
    private void Start()
    {
        UpdateHealth();
        Button btn = clearDungeonButton.GetComponent<Button>();
        btn.onClick.AddListener(ClearDungeon);
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

}
