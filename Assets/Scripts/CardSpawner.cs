using System.Collections;
using System.Collections.Generic;
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

    int cardCounter;
    //if counter <2 spawn cards on all empty positions
    //on spawn change bool to false on availibility

    //hasnt done much
    //need some array for spawn points
    //TrackedReference if they are used or no

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cardCounter < 2)
        {
            SpawnCards();
        }
    }
    void SpawnCards()
    { 
        //foreach spawnpoint 
        //if posiiton availibility true perform spawn card on this posiiton
        //adjust counter on deck
    }
}
