using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {


    public static GameObject Create(Vector3 position)
    {
       GameObject obj = Instantiate(WorldResources.instance.buildingA);
        obj.transform.position = position;
       return obj;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
