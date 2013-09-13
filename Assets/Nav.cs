using UnityEngine;
using System.Collections;

public class Nav : MonoBehaviour {
	public Transform loc;
	// Use this for initialization
	void Start () {
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.destination = loc.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		print (gameObject.transform.rotation.y);
		Quaternion rot = Quaternion.Euler(0,-gameObject.transform.rotation.y*2,0);
		//rot.eulerAngles = - rot.eulerAngles;
		gameObject.transform.FindChild("Bar").transform.rotation= rot;
		
	}
}
