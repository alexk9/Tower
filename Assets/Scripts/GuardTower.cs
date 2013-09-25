using UnityEngine;
using System.Collections;

public class GuardTower : MonoBehaviour {

	public Transform m_arrowTemplate;
	public float FIRE_TERM = 2f;
	public int NO =0;
	private float m_accTerm;
	
	// Use this for initialization
	void Start () {
		//print ("SERTAR");
		m_accTerm = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//print ("HI");
		 if (Input.GetButtonDown("Fire1")) {
	        GameObject spPoint = GameObject.Find("spawnPoint");                // spawnPoint 정보 읽기 -- ①
	        //Instantiate(m_bullet, spPoint.transform.position, spPoint.transform.rotation);
	        //myBullet.rigidbody.AddForce(spPoint.transform.forward * power);
			//print ("FIRE!!!"+NO);
	    }
		
		
		if( m_accTerm < FIRE_TERM ){
			m_accTerm += Time.deltaTime;
		} else {
			RaycastHit hit;
			Vector3 fwd = Vector3.forward;
			GameObject[] a_goTargets =  GameObject.FindGameObjectsWithTag("TARGET");
			
			for(int idx=0;idx<a_goTargets.Length;idx++){
				//print(a_goTargets[idx]);
				if( a_goTargets[idx].name.StartsWith("Target") == true){
					//Guard Tower do not look at.
					//transform.LookAt(a_goTargets[idx].transform);
					Debug.DrawRay(transform.position,Vector3.forward,Color.red,5.0f);
					//print("OBJECTS FOUNDS:["+a_goTargets[idx]+"]");
					//Transform spPoint = gameObject.transform.FindChild("spawnPoint");                
		        	Transform myArrow= (Transform)Instantiate(m_arrowTemplate, gameObject.transform.position, Quaternion.identity);
					GuardTowerArrow gta = (GuardTowerArrow)myArrow.gameObject.GetComponent("GuardTowerArrow");
					gta.setTarget(a_goTargets[idx]);
		        	//myBullet.rigidbody.AddForce(spPoint.transform.forward * power);
					//print ("FIRE!!!"+NO);
					
					break;
				}
			}
			m_accTerm = 0;
		}
		Debug.DrawRay(transform.position,Vector3.forward,Color.red,5.0f);
		
		//if (Physics.Raycast(transform.position, fwd, hit, 20) == false) return;        // 탐색 실패
	}
}
