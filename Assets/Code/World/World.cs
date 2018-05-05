using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class World : MonoBehaviour 
{
    public static World instance;

    [SerializeField]
	private int width = 1000;

	[SerializeField]
	private int height = 2000;

	public Tilemap tilemapLayout;

	public Tilemap tilemapInterests;

	[HideInInspector]
	public PF.Grid pathFindGrid;

	// Use this for initialization
	public void Init() 
	{
        //use this world
        World.instance = this;

        InitPathFindGrid ();

        //TODO put elsewhere
        Generate();

        PopulateWithTileObjects();

	}
	
	public void InitPathFindGrid()
	{
		bool[,] solids = TilemapUtils.GetWalkableMonster (tilemapLayout);
   		pathFindGrid = new PF.Grid(solids);

	}


    public void Generate()
    {
        //TODO random

    }

    public void PopulateWithTileObjects()
    {
        for (int y = 0; y < tilemapLayout.size.y; y++)
        {
            for (int x = 0; x < tilemapLayout.size.x; x++)
            {
                TypedTile tile = (TypedTile)tilemapLayout.GetTile(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    switch (tile.type)
                    {
                        case TypedTile.TILE_TYPE.BUILDING:

                            Vector3 pos = GetWorldPos(new Vector3Int(x, y, 0));
                            Building.Create(pos);

                            break;
                    }
                }
                
            }

        }

    }


    public Vector3Int GetGridPos(Transform transf)
    {
        return GetGridPos(transf.position);
    }

    public Vector3Int GetGridPos(Vector3 pos)
    {
        return tilemapLayout.WorldToCell(pos);
    }


    public Vector3 GetWorldPos(Vector3Int gridpos)
	{
		return tilemapLayout.CellToWorld(gridpos);
	}
}
