using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {
	
	protected Transform m_bar;
	protected Quaternion m_init_bar_rot;
	protected Vector3 m_init_bar_pos;
	protected Vector3 m_init_ball_pos;
	protected GameObject m_dest;
	protected bool is_nav_set= false;
	
	private float m_energy = 100;
	public float MAX_ENERGY = 100;
	public float DEMAGE = 10;
	//private float MAX_SIZE;
	public GameObject m_group;
	//public GameObject m_body;
	public float m_speed = 5f;
	public Vector3 m_initScale;
	// Use this for initialization
	void Start () {
		//MAX_SIZE = m_group.transform.FindChild("GreenBar").transform.localScale.x ;
		m_initScale =m_group.transform.FindChild("Bar/GreenBar").transform.localScale ;
		//print("MAX_VECTOR:"+m_group.transform.FindChild("Bar/GreenBar").transform.localScale);
		
		m_energy = MAX_ENERGY;
		m_bar = gameObject.transform.FindChild("Bar");
		m_init_bar_rot = m_bar.rotation;
		m_init_bar_pos = m_bar.position;
		m_init_ball_pos = gameObject.transform.position;
		
		m_dest = GameObject.Find("destination"); 
		//print ("dest:"+m_dest);
		
		
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.transform.Rotate(new Vector3(0,180,0));
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if( true ||m_group.transform.position.z < 9.8){
			if(is_nav_set == false ){
				is_nav_set= true;
				NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
				navMeshAgent.velocity = new Vector3(0,0,-3f);
				//navMeshAgent.autoBraking= false;
				navMeshAgent.updatePosition = true;
				navMeshAgent.updateRotation = true;
				navMeshAgent.destination = m_dest.transform.position;			
				//print ("NAV SET");
			}
		}
		else {
			//move forward
			//m_group.transform.Translate(new Vector3(0,0,0.1f)*Time.deltaTime*m_speed);
		}
		
		//When Minion go to End point, Destroy it.
		if(is_nav_set == true && m_group.transform.position.z > 9.6 && m_group.transform.position.x > 3){
			Destroy(gameObject);
		}
		
		//print ("Position of Minion:"+m_group.transform.position);
		//transform.localScale += new Vector3(0.1F, 0, 0);
		
		m_bar.rotation = m_init_bar_rot;
		m_bar.position = gameObject.transform.position - m_init_ball_pos+ m_init_bar_pos;
	
	}
	
	void OnTriggerEnter(Collider other){
		print (other);
		Transform tf_grbar = m_group.transform.FindChild("Bar/GreenBar");
		

		
		if(tf_grbar.localScale.x > 0 ){
			m_energy = m_energy -DEMAGE;
			print ("ENERGY:"+m_energy);
			Vector3 bf_position = tf_grbar.position;
			//tf_bar.localScale += new Vector3(-0.01f,0,0);	
			Vector3 cur_scale = tf_grbar.localScale  ;	
			cur_scale.x = m_initScale.x * m_energy / MAX_ENERGY;
			tf_grbar.localScale = cur_scale;
			print ("TF_GRBAR:"+ cur_scale);
			tf_grbar.Translate( new Vector3(- DEMAGE/MAX_ENERGY/4,0,0));	
			
			
		} 
		if(m_energy <= 0){
			Destroy(m_group);
		}
	}
}
