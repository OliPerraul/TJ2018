using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughMonster : Character
{
		public const int IDLE = 0;
		public const int MOVE_DEST = 1;
		public const int MOVE_RANDOM = 2;
		public const int DAZED = 3;
	
		public CharacterNS.State[] states;

    public void Start()
    {
        Debug.Log("Start");
        InitStates();
        SetState(states[MOVE_DEST]);
    }


        // Update is called once per frame
        void Update () 
        {
            state.Update ();
        }


		public void InitStates()
		{
			states = new CharacterNS.State[10];

			states [MOVE_DEST] = new CharacterNS.StateMovingDestination(this);
			states [MOVE_RANDOM] = new CharacterNS.StateMovingRandom(this);
			states [IDLE] = new DoughMonsterNS.StateIdle(this);
			states [DAZED] = new DoughMonsterNS.StateDazed(this);
		}


}



