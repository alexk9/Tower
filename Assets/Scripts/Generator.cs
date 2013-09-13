using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	private float m_acc_time;
	public GameObject m_spawnPoint;
	public GameObject m_target;
	public GameObject m_towerTemplate;
	private GameObject m_cur_tower_temp;
	public GameObject m_prefab_tower;
	private bool m_isTemplateExists = false;
	private bool	m_towerClicked = false;
	// Use this for initialization
	void Start () {
		m_acc_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( m_acc_time > 5 ){
			//Craete Target
			Instantiate(m_target,m_spawnPoint.transform.position,Quaternion.identity);
			print(transform.position);
			m_acc_time = 0;
		} else {
			m_acc_time+= Time.deltaTime;
		}
		
		if(m_towerClicked){
			
			//m_cur_tower_temp.transform.position = new Vector3(Input.mousePosition.x,m_cur_tower_temp.transform.position.y,Input.mousePosition.y);
			if(m_towerClicked == true && m_isTemplateExists == true){
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));			
				//m_cur_tower_temp.transform.position = new Vector3(0,1,0);
				m_cur_tower_temp.transform.position = new Vector3(mousePos.x, m_cur_tower_temp.transform.position.y, mousePos.z); 

				RaycastHit hitInfo; 
            	GameObject target = GetClickedObject(out hitInfo); 
				
				print ("Clicked Object:"+target);
			}
			
			
			
			if( Input.GetMouseButtonUp(0) ){
				if( m_towerClicked == true && m_isTemplateExists ==false){
					m_cur_tower_temp =  (GameObject)Instantiate(m_towerTemplate);
					m_isTemplateExists = true;
				} else {
					Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));			
					
					m_towerClicked = false;
					Destroy(m_cur_tower_temp);
					m_isTemplateExists = false;
					
					Vector3 mousePos2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));			
					GameObject new_tower = (GameObject)Instantiate(m_prefab_tower);	
					new_tower.transform.position = new Vector3(mousePos.x, m_cur_tower_temp.transform.position.y, mousePos.z); 
					print ("New Tower Position:"+new_tower.transform.position);
				}
			}
		}
	}
	
	void OnGUI(){
		//print ("ONGUI");
		
		GUI.Box(new Rect(Screen.width - 300,40,280,360), "");
		if( GUI.Button(new Rect(Screen.width - 280, 200, 50, 50), "Tower")){
			print ("button clicked.");
			m_towerClicked = true;
			
			//m_cur_tower_temp.transform.position = Vector3.zero;
		}
		
		if( m_towerClicked ){
			GUI.Label(new Rect(Screen.width - 280,70,200,50),"적절한 위치에\n타워를 설치합니다.");
		} else {
			GUI.Label(new Rect(Screen.width - 280,70,200,50),"");
		}
	}
	GameObject GetClickedObject(out RaycastHit hit) 
    { 
        GameObject target = null; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(ray, out hit)) 
            target = hit.collider.gameObject; 

        return target; 
    } 
}
