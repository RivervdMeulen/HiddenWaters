using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour {

	public GameObject fishPrefab;
	public static int tankSize = 500;

	[SerializeField]
	private float tankSizeX;

	[SerializeField]
	private float tankSizeY;

	[SerializeField]
	private float tankSizeZ;

	static int numFish = 500;
	public static GameObject[] allFish = new GameObject[numFish];

	public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < numFish; i++)
		{
			Vector3 pos = new Vector3(Random.Range(-tankSizeX,tankSizeX),
									  Random.Range(-tankSizeY,tankSizeY),
				                      Random.Range(-tankSizeZ,tankSizeZ));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Random.Range(0,10000) < 50)
		{
			goalPos = new Vector3(Random.Range(-tankSizeX,tankSizeX),
				                  Random.Range(-tankSizeY,0f),
				                  Random.Range(-tankSizeZ,tankSizeZ));
		}
	}
}
