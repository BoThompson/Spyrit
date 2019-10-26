 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumUnit : Unit
{
    public GameObject armyObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(armyObj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
