using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject monsterSlot;
    bool weaponActive = false;
    bool monsterActive = false;

    

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

    public void WeaponUsed(GameObject newMonster)
    {
        for (var i = weaponSlot.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(weaponSlot.transform.GetChild(i).gameObject);
        }
        weaponActive = true;
        newMonster.transform.parent = monsterSlot.transform;
        newMonster.transform.position = monsterSlot.transform.position;
    }

}
