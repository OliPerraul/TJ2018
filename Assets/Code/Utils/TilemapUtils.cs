using UnityEngine;
using UnityEngine.Tilemaps;


using System.Collections.Generic;


public static class TilemapUtils
{
    //public static

    public static TypedTile[,] GetTiles(this Tilemap tilemap)
    {
        TypedTile[,] tiles = new TypedTile[tilemap.size.x, tilemap.size.y];

        for (int y = 0; y < tilemap.size.y; y++)
        {
            for (int x = 0; x < tilemap.size.x; x++)
            {
                //Risky stuff lol
                TypedTile tile = (TypedTile)tilemap.GetTile(new Vector3Int(x, y, 0));
                tiles[x, y] = tile;
            }

        }

        return tiles;
    }


    public static bool[,] GetWalkableMonster(Tilemap tilemap)
    {
        TypedTile[,] tiles = GetTiles(tilemap);
        bool[,] walkable = new bool[tilemap.size.x, tilemap.size.y];

        for (int i = 0; i < tilemap.size.y; i++)
        {
            for (int j = 0; j < tilemap.size.x; j++)
            {
                if (tiles[j, i] != null)
                {
                    if ((tiles[j, i].type == TypedTile.TILE_TYPE.BUILDING) ||
                        (tiles[j, i].type == TypedTile.TILE_TYPE.BUILDING_DESTROYED))
                    {
                        walkable[j, i] = true;
                    }
                    else
                        walkable[j, i] = false;
                }
                else
                    walkable[j, i] = false;
            }
        }

        return walkable;
    }



    public static List<Vector3> GetTargets(Tilemap tilemap)
    {
        TypedTile[,] tiles = GetTiles(tilemap);
        List<Vector3> list = new List<Vector3>();

        for (int i = 0; i < tilemap.size.y; i++)
        {
            for (int j = 0; j < tilemap.size.x; j++)
            {
                if (tiles[j, i] != null)
                {
                    if (tiles[j, i].type == TypedTile.TILE_TYPE.TARGET)
                    {
                        list.Add(tilemap.CellToWorld(new Vector3Int(j, i, 0)));
                    }
                }
            }
        }

        return list;
    }



}
