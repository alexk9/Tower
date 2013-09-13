using UnityEngine;
using System.Collections;

public class MapData : MonoBehaviour {

	public static int[,] MAP_INFO;
		
	
	// Use this for initialization
	void Start () {
		MAP_INFO = new int[,]{{1,2,3},{2,3,4}};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
