using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DungeonDeck : MonoBehaviour
{
    [SerializeField] GameObject monster0;
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject potion;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject spawnPoints;

    List<int> monsterList0 = new List<int>();
    List<int> monsterList1 = new List<int>();
    List<int> potionList = new List<int>();
    List<int> weaponList = new List<int>();

    Dictionary<int, List<int>> cardNumberType= new Dictionary<int, List<int>>();
    // Start is called before the first frame update
    void Start()
    {
        CreateCardsOfType(15,monsterList0);
        CreateCardsOfType(15,monsterList1);
        CreateCardsOfType(10,potionList);
        CreateCardsOfType(10,weaponList);

        cardNumberType.Add(0, monsterList0);
        cardNumberType.Add(1, monsterList1);
        cardNumberType.Add(2, potionList);
        cardNumberType.Add(3, weaponList);
    }
    void Update()
    {

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

    void PickEmptySpawnPoint()
    { 
    
    }

    void PulLCardRetardedIQ0Method()
    {
        int typeKey = Random.Range(0, 4);
        if (typeKey == 0)
        {
            ParticularCard(monsterList0);
            Instantiate(monster0);
            //setValue
        }
        else if (typeKey == 1)
        {
            ParticularCard(monsterList1);
            Instantiate(monster1);
            //setValue
        }
        else if (typeKey == 2)
        {
            ParticularCard(potionList);
            Instantiate(potion);
            //setValue
        }
        else if (typeKey == 3)
        {
            ParticularCard(weaponList);
            Instantiate(weapon);
            //setValue
        }
    }
    void PullCard()
    {
        
        int typeKey =  Random.Range(0, 4);
        if (cardNumberType.TryGetValue(typeKey, out var returnedValue))
        {
            ParticularCard(returnedValue); 
        }
    }
    void ParticularCard(List <int> list)
    {
        int randomCard = Random.Range(0, list.Count);

    }

    void SpawnCard()
    {
        
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

}
