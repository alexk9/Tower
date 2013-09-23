using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	private GameObject m_target ;
	//private GameObject m_tower;
	public float _speed=4;
	private GameObject m_tempBodyObj;
	// Use this for initialization
	void Start () {
		GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("TARGET");
		if(gos.Length == 0){
			print ("Not ANY TARGET tag");
			Destroy(gameObject);
		} else {
			for(int i=gos.Length-1;i>=0;i--){
				if(gos[i].name.StartsWith("Target")){
					m_target = gos[i];
					//break;
				} else { //print (">>>"+gos[i].name);
				}
				//else if(gos[i].name =="Target"){
				//	m_tempBodyObj = gos[i];
				//}
			}
			if(m_target == null){
				print ("m_target not FOUND!!!!");
			}
		}
		//m_tower = GameObject.Find("Tower");
	}
	
	// Update is called once per frame
	void Update () {
		
		if( m_target != null){
			
			gameObject.transform.LookAt(m_target.transform);
			//print ("GreenBar:"+m_target.transform.position+",Body:"+m_tempBodyObj.transform.position);
			gameObject.transform.Translate(Vector3.forward*Time.deltaTime*_speed);
		}else {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other){
		print ("triggerEnter:"+other);
		if( other.tag == "TARGET"){
			Destroy(gameObject);
		} else {
			print ("ERROR!!!!!!!!!!!!!");
		}
	}
	void OnTriggerExit(Collider other){
		print ("triggerExit:"+other);
		if( other.tag == "TARGET"){
			Destroy(gameObject);
		} else {
			print ("ERROR!!!!!!!!!!!!!");
		}
	}
}
