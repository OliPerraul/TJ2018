using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


public class TypedTile : Tile 
{
	public enum TILE_TYPE 
	{
		BUILDING,
		BUILDING_DESTROYED,

		TRAP0,
		TRAP1,
		TRAP2,
		TRAP3,

		TARGET,

		SOLID
	}

	public TILE_TYPE type;

    public Vector3Int normPos = new Vector3Int(0,0,0);


	[MenuItem("Assets/Create/Tiles/TypedTile")]
	#if UNITY_EDITOR
	public static void CreateTypedTile()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save TypedTile", "MyTypedTile", "asset", "Save TypedTile", "Assets");

		if (path == "") {
			return;
		}

		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<TypedTile> (), path);
	}

	#endif

}
