using UnityEngine;
using System.Collections;

public class Nav : MonoBehaviour {
	protected Transform m_bar;
	protected Quaternion m_init_bar_rot;
	protected Vector3 m_init_bar_pos;
	protected Vector3 m_init_ball_pos;
	public Transform loc;
	// Use this for initialization
	void Start () {
		m_bar = gameObject.transform.FindChild("Bar");
		m_init_bar_rot = m_bar.rotation;
		m_init_bar_pos = m_bar.position;
		m_init_ball_pos = gameObject.transform.position;
		
		
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.destination = loc.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		m_bar.rotation = m_init_bar_rot;
		m_bar.position = gameObject.transform.position - m_init_ball_pos+ m_init_bar_pos;
	
	}
}
