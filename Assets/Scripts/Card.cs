using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // 0 monster 1 monster 2 potion 3 weapon
    [SerializeField] byte type;
    [SerializeField] byte value;
    [SerializeField] string description;//remove later

    
    bool toldinfo=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TellInfo()
    {
        if(!toldinfo)
        {
            //Debug.Log("Telling Info");
            //toldinfo = true;
            Debug.Log(type+" "+value+" "+description);
        }
    }
    public void SetToldInfoFalse()
    {
        toldinfo=false;
    }

    public void SetProperties(byte type,byte value)
    {
        type = type;
        value = value;

    }
}
