using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDeck : MonoBehaviour
{
    
    [SerializeField] GameObject spawnPoints;

    List<int> monsterList0 = new List<int>();
    List<int> monsterList1 = new List<int>();
    List<int> potionList = new List<int>();
    List<int> weaponList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        CreateCardsOfType(15,monsterList0);
        CreateCardsOfType(15,monsterList1);
        CreateCardsOfType(10,potionList);
        CreateCardsOfType(10,weaponList);
    }
    void CreateCardsOfType(int lenght,List <int> list)
    {
        for (int i = 0; i < lenght; i++)
        {
            {
                int insertedValue = i + 1;
                list.Add(insertedValue);
            }
        }
    }

    public void PrintAllLists()
    {
        CreateOutputStringForTesting(monsterList0, nameof(monsterList0));
        CreateOutputStringForTesting(monsterList1, nameof(monsterList1));
        CreateOutputStringForTesting(potionList, nameof(potionList));
        CreateOutputStringForTesting(weaponList , nameof(weaponList));
    }
    void CreateOutputStringForTesting(List<int> list,string nameOfList)
    {
        //string nameOfList;
        string position;
        Debug.Log(string.Format("here is output for list " + nameOfList + ": " + string.Join(" ,",list)));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
