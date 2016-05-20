using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

	public float speed = 0.001f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighbourDistance = 3.0f;

	[SerializeField]
	private float tankSizeX;

	[SerializeField]
	private float tankSizeY;

	[SerializeField]
	private float tankSizeZ;

	[SerializeField]
	private float speedSetting;

	bool turning = false;

	// Use this for initialization
	void Start () 
	{
		speed = Random.Range(0.5f,1) * speedSetting;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x <= -tankSizeX || 
			transform.position.y <= -tankSizeY || 
			transform.position.z <= -tankSizeZ ||
			transform.position.x >= tankSizeX ||
			transform.position.y >= 0f ||
			transform.position.z >= tankSizeZ)
		{
			turning = true;
			//Vector3.Distance(transform.position, Vector3.zero) >= tankSize
		}
		else
			turning = false;

		if(turning)
		{
			//Vector3 direction = Vector3.zero - transform.position;
			Vector3 direction = new Vector3(Random.Range(-tankSizeX,tankSizeX),
											Random.Range(-tankSizeY,0f),
											Random.Range(-tankSizeZ,tankSizeZ));
			transform.rotation = Quaternion.Slerp(transform.rotation,
					                                  Quaternion.LookRotation(direction), 
					                                  rotationSpeed * Time.deltaTime);
			speed = Random.Range(0.5f,1) * speedSetting;
		}
		else
		{
			if(Random.Range(0,5) < 1)
				ApplyRules();
			
		}
		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = globalFlock.allFish;
		
		Vector3 vcentre = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f * speedSetting;
		
		Vector3 goalPos = globalFlock.goalPos;

		float dist;

		int groupSize = 0;
		foreach (GameObject go in gos) 
		{
			if(go != this.gameObject)
			{
				dist = Vector3.Distance(go.transform.position,this.transform.position);
				if(dist <= neighbourDistance)
				{
					vcentre += go.transform.position;	
					groupSize++;	
					
					if(dist < 1.0f)		
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}
					
					flock anotherFlock = go.GetComponent<flock>();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		} 
		
		if(groupSize > 0)
		{
			vcentre = vcentre/groupSize + (goalPos - this.transform.position);
			speed = gSpeed/groupSize;
			
			Vector3 direction = (vcentre + vavoid) - transform.position;
			if(direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp(transform.rotation,
					                                  Quaternion.LookRotation(direction), 
					                                  rotationSpeed * Time.deltaTime);
		
		}
	}
}
