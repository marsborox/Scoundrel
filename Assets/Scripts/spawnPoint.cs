using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{

    [SerializeField]bool isUsed = false;
    Card card;
    DungeonDeck dungeonDeck;
    [SerializeField] Transform spawnTransform;

    [SerializeField] GameObject cardPrefab;
    private void Awake()
    {
        
        dungeonDeck = GetComponent<DungeonDeck>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnCard()
    {
        //if (!isUsed) 
        {
            //dungeonDeck.PulLCardIQ0Method(spawnTransform);
            isUsed = true;
            Instantiate(cardPrefab,spawnTransform);
        }
    }
}
