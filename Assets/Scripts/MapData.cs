using UnityEngine;
using System.Collections;

public class MapData : MonoBehaviour {

	public static int[,] MAP_INFO = new int[,]{
			{1,	-1,  1,	 1,	 1,	1, 1, 1,-1,	1},
			{1,	-1,  1,	 1,	 1,	1, 1, 1,-1,	1},
			{1,	-1,  1,	-1,	-1,-1,-1, 1,-1,	1},
			{1,	-1,  1,	-1,	 1,	1,-1, 1,-1,	1},
			{1,	-1, -1,	-1,	 1, 1,-1, 1,-1,	1},
			{1,	 1,  1,	 1,  1, 1,-1, 1,-1,	1},
			{1,	-1, -1,	-1,	-1,-1,-1, 1,-1,	1},
			{1,	-1,	 1,  1,	 1, 1, 1, 1,-1,	1},
			{1,	-1,	-1,	-1,	-1,-1,-1,-1,-1,	1},
			{1,	 1,  1,	 1,  1, 1, 1, 1, 1, 1}
		};
	
	public static string toStringMAP_INFO(){
		System.Text.StringBuilder str = new System.Text.StringBuilder();
		
		for(int x= 0;x<10;x++){
			for(int y = 0;y<10;y++){
				str.Append(MAP_INFO[x,y]+",");
			}
			str.Append("\n");
		}
		return str.ToString();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
