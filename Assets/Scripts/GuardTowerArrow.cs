using UnityEngine;
using System.Collections;

public class GuardTowerArrow : MonoBehaviour {
	
	private bool m_initialized = false;
	private GameObject m_target ;
	//private GameObject m_tower;
	public float _speed=4;
	private GameObject m_tempBodyObj;
	
	public void setTarget( GameObject target){
		m_target = target;
		m_initialized = true;
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( m_initialized == true){
			if( m_target != null){
				
				gameObject.transform.LookAt(m_target.transform);
				//print ("GreenBar:"+m_target.transform.position+",Body:"+m_tempBodyObj.transform.position);
				gameObject.transform.Translate(Vector3.forward*Time.deltaTime*_speed);
			}else {
				Destroy(gameObject);
			}
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
