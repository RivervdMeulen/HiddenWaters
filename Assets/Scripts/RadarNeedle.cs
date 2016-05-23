using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadarNeedle : MonoBehaviour {

	[SerializeField]
	private RectTransform Needle;

	[SerializeField]
	private float rotateSpeed;

	private float rotation = -90f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		Needle.rotation = Quaternion.Euler (0, 0, rotation);
		rotation += rotateSpeed;
	}
}
