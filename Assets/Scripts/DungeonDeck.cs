using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
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
    Card card;

    public int tempType;
    public int tempValue;

    private void Awake()
    {
        card = GetComponent<Card>();
    }
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



    public void PulLCardMethod()
    {
        //Debug.Log("SettingProperties");
        tempType = Random.Range(0, 4);
        if (tempType == 0 && monsterList0.Count > 0)
        {
            PullCardInputList(monsterList0);

        }
        else if (tempType == 1 && monsterList1.Count > 0)
        {
            PullCardInputList(monsterList1);
        }
        else if (tempType == 2 && potionList.Count > 0)
        {
            PullCardInputList(potionList);
        }
        else if (tempType == 3 && weaponList.Count > 0)
        {
            PullCardInputList(weaponList);
        }
        else if(monsterList0.Count==0&& monsterList1.Count==0&& potionList.Count==0&& weaponList.Count == 0)
        {

            Debug.Log("GG");
        }
        else PulLCardMethod();
        //Debug.Log(tempType + " " + tempValue);
    }
    void PullCardInputList(List<int> cardColorList)
    {
        //setValue
        int cardValueIndex = Random.Range(0, cardColorList.Count);
        tempValue = cardColorList.ElementAt(cardValueIndex);
        cardColorList.Remove(cardColorList[cardValueIndex]);
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
    
}



