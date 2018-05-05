using System;
using System.Collections.Generic;

using PF;
using UnityEngine;

using UnityEngine.Tilemaps;


namespace CharacterNS
{
    abstract public class State
    {
        protected Character character;

        public State(Character character)
        {
            this.character = character;
        }


        public virtual void Init()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Clear()
        {

        }

    }



    public abstract class StateMoving : State
    {
        protected List<PF.Point> path;
        protected int curr_point_idx = 0;

        protected abstract List<PF.Point> ChoosePath();

   
        public StateMoving(Character character) : base(character)
        {
        }

        public override void Init()
        {
            this.path = ChoosePath();
        }

        public override void Update()
        {
            Move();
        }

        public override void Clear()
        {
            curr_point_idx = 0;
            path.Clear();
        }


        //Move along the path
        private bool Move()
        {
            Vector3Int gridpos = new Vector3Int(path[curr_point_idx].x, path[curr_point_idx].y, 0);
            Vector3 pos = World.instance.GetWorldPos(gridpos);

            //Check if must do next point
            if (character.transform.position == pos)
            {
                curr_point_idx++;
            }

            if (curr_point_idx < path.Count)
            {

                character.transform.position = Vector3.Lerp(character.transform.position, pos, character.moveSpeed);
                return true;
            }

            return false;
      

        }
    }

    public class StateMovingDestination : StateMoving
    {
        public StateMovingDestination(
        Character character) : base(character) { }
   
        protected override List<PF.Point> ChoosePath()
        {
            Vector3Int pos = World.instance.GetGridPos(character.transform);
            PF.Point startPoint = new PF.Point(pos.x, pos.y);
            return PF.Pathfinding.FindPath(World.instance.pathFindGrid, startPoint, ChooseDestination(), PF.Pathfinding.DistanceType.Manhattan, true);
        }


        private PF.Point ChooseDestination()
        {
            List<Vector3> targets = TilemapUtils.GetTargets(World.instance.tilemapInterests);

            float closestDist = float.MaxValue;
            Vector3 closest = character.transform.position;

            foreach (Vector3 target in targets)
            {

                float dist = (target - character.transform.position).magnitude;

                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = target;
                }
            }

            Vector3Int pos = World.instance.GetGridPos(closest);
            return new PF.Point((int) pos.x, (int) pos.y);
        }


    }


    public class StateMovingRandom : StateMoving
    {

        public StateMovingRandom(Character doughMonster) : base(doughMonster)
        {
        }

        protected override List<PF.Point> ChoosePath()
        {
            return null;
        }

    }




}
