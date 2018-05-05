using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResources : MonoBehaviour
{
    public static WorldResources instance;

    public GameObject buildingA;
    public GameObject buildingB;
    public GameObject buildingC;

    public GameObject solidA;
    public GameObject solidB;

    public GameObject trapA;
    public GameObject trapB;

    public GameObject target;
    
    public void Init()
    {
        instance = this;
    }


}
