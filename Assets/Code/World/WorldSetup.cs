using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetup : MonoBehaviour {

    [SerializeField]
    private WorldResources worldResources;

    [SerializeField]
    private World world;


    private void Awake()
    {
        worldResources.Init();
        world.Init();
    }

}
