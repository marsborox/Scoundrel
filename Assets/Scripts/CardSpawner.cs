using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] Transform position0;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] Transform position3;

    bool position0Availibility = true;
    bool position1Availibility = true;
    bool position2Availibility = true;
    bool position3Availibility = true;

    [SerializeField] GameObject spawnPoint0;
    [SerializeField] GameObject spawnPoint1;
    [SerializeField] GameObject spawnPoint2;
    [SerializeField] GameObject spawnPoint3;

    [SerializeField] GameObject cardPrefab;

    public int cardPosition;

    public int usedCardCounter;
    public int cardOnTableCounter;
    
    //if counter <2 spawn cards on all empty positions
    //on spawn change bool to false on availibility

    //hasnt done much
    //need some array for spawn points
    //TrackedReference if they are used or no
    void Awake()
    { 
        
    }
   
    void Start()
    {
        SpawnCardsOnSpawnPoints();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CountCardsOnTable();
        if (usedCardCounter == 3)
        {
            SpawnCardsOnSpawnPoints();
        }
    }
    public void SpawnCardsOnSpawnPoints()
    {
        //Debug.Log("start of spawn");
        SpawnCardOnSpawnPoint(spawnPoint0);
        SpawnCardOnSpawnPoint(spawnPoint1);
        SpawnCardOnSpawnPoint(spawnPoint2);
        SpawnCardOnSpawnPoint(spawnPoint3);
        //Debug.Log("End of spawn");
        Debug.Log(cardOnTableCounter);
        usedCardCounter=0;
    }

    void SpawnCardOnSpawnPoint(GameObject thisGameobject)
    {
        if (thisGameobject.transform.childCount == 1)
        {
            //Debug.Log("start of spawning");
            Instantiate(cardPrefab, thisGameobject.transform);
            
            //Debug.Log("End of spawning");
        }
    }
    
    /*
    void CheckObjectsOnSpawn(GameObject thisGameobject)
    {
        cardOnTableCounter = +thisGameobject.transform.childCount;
    }
    
    void CountCardsOnTable()
    {   
        cardOnTableCounter = 0;
        CheckObjectsOnSpawn(spawnPoint0);
        CheckObjectsOnSpawn(spawnPoint1);
        CheckObjectsOnSpawn(spawnPoint2);
        CheckObjectsOnSpawn(spawnPoint3);
        cardOnTableCounter = cardOnTableCounter -4;
    }
    */

    /* ***************TESTING METHODS*******************
    public void CheckIfObjectHasChildren()
    {
        if (spawnPoint0.transform.childCount == 0) { Debug.Log("spawn point 0 has no children"); }
        else if (spawnPoint0.transform.childCount > 0) { Debug.Log("spawn point 0 has children"); }
        else { Debug.Log("weDontKnow"); }
    }

    public void CheckIfAllHaveChildren()
    {
        CheckIfAnyHaveChildren(spawnPoint0);
        CheckIfAnyHaveChildren(spawnPoint1);
        CheckIfAnyHaveChildren(spawnPoint2);
        CheckIfAnyHaveChildren(spawnPoint3);
    }

    void CheckIfAnyHaveChildren(GameObject gameobject)
    {
        if (gameobject.transform.childCount == 0) { Debug.Log(gameobject.name + " has no children"); }
        else if (gameobject.transform.childCount > 0) { Debug.Log(gameobject.name + " has children"); }
        else { Debug.Log("weDontKnow"); }
    }
    */
    public void SpawnCards()
    {
        if(position0Availibility)
            {
                cardPosition = 0;
                Instantiate(cardPrefab, position0);
                position0Availibility=false;
            }

        if(position1Availibility)
            {
                cardPosition = 1;
                Instantiate(cardPrefab, position1);
                position1Availibility=false;
            }

        if (position2Availibility)
            { 
                cardPosition = 2;
                Instantiate(cardPrefab, position2);
                position2Availibility=false;
            }

        if (position3Availibility) 
            {
                cardPosition = 3;
                Instantiate(cardPrefab, position3); 
                position3Availibility=false;
            }

    }
}
