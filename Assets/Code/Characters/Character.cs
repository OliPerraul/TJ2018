using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    [SerializeField]
	public float moveSpeed = .5f;

    protected CharacterNS.State state;

    public void SetState(CharacterNS.State state)
    {
        if(this.state != null)
            this.state.Clear();

        this.state = state;
        this.state.Init();
     }



}
