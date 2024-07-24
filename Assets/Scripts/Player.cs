using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshPro healthCounterText;
    public int health =2;


    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject monsterSlot;
    bool weaponActive = false;
    bool monsterOnSlot = false;

    private void Start()
    {
        UpdateHealth();
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

}
