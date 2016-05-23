using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
	// Internal vars
	private GameObject _centerObject;
	private Vector2    _radarCenter;
	private Texture2D  _radarCenterTexture;

	[SerializeField]
	private GameObject radarMiddle;

	[SerializeField]
	private int radarSize = 400;

	[SerializeField]
	private string radarCenterTag;

	[SerializeField]
	private string radarBlip1Tag;

	[SerializeField]
	private string radarBlip2Tag;

	[SerializeField]
	private Texture2D  _radarBlip1Texture;

	[SerializeField]
	private Texture2D  _radarBlip2Texture;

	[SerializeField]
	private Texture2D radarBG;

	private float radarZoom = 1;

	// Initialize the radar
	void Start ()
	{
		// Get the location of the radar
		setRadarLocation();

		// Get our center object
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(radarCenterTag);
		_centerObject = gos[0];
	}

	// Update is called once per frame
	void OnGUI ()
	{
		GameObject[] gos;

		// Draw th radar background
		Rect radarRect = new Rect(_radarCenter.x - radarSize / 2, _radarCenter.y - radarSize / 2, radarSize, radarSize);
		GUI.DrawTexture(radarRect, radarBG);
		

		// Draw blips

			// Find all game objects
			gos = GameObject.FindGameObjectsWithTag(radarBlip1Tag); 

			// Iterate through them and call drawBlip function
			foreach (GameObject go in gos)
			{
				drawBlip(go, _radarBlip1Texture);
			}
			
			/*
			gos = GameObject.FindGameObjectsWithTag(radarBlip2Tag); 

			foreach (GameObject go in gos)
			{
				drawBlip(go, _radarBlip2Texture);
			}
			*/


	}

	// Draw a blip for an object
	void drawBlip(GameObject go, Texture2D blipTexture)
	{
		if (_centerObject)
		{
			Vector3 centerPos = _centerObject.transform.position;
			Vector3 extPos = go.transform.position;

			// Get the distance to the object from the centerObject
			float dist = Vector3.Distance(centerPos, extPos);

			// Get the object's offset from the centerObject
			float bX = centerPos.x - extPos.x;
			float bY = centerPos.z - extPos.z;

			// Scale the objects position to fit within the radar
			bX = bX * radarZoom;
			bY = bY * radarZoom;

			// For a round radar, make sure we are within the circle
			if(dist <= (radarSize - 2) * 0.5 / radarZoom)
			{
				Rect clipRect = new Rect(_radarCenter.x - bX - 1.5f, _radarCenter.y + bY - 1.5f, 40, 40);
				GUI.DrawTexture(clipRect, blipTexture);
			}
		}
	}

	// Create a round bullseye texture
	void CreateRoundTexture(Texture2D tex, Color a, Color b)
	{
		Color c = new Color(0, 0, 0);
		int size = (int)((radarSize / 2) / 4);

		// Clear the texture
		for (int x = 0; x < radarSize; x++)
		{
			for (int y = 0; y < radarSize; y++)
			{
				tex.SetPixel(x, y, c);
			}
		}

		for (int r = 4; r > 0; r--)
		{
			if (r % 2 == 0)
			{
				c = a;
			}
			else
			{
				c = b;
			}
			DrawFilledCircle(tex, (int)(radarSize / 2), (int)(radarSize / 2), (r * size), c);
		}

		tex.Apply();
	}

	// Draw a filled colored circle onto a texture
	void DrawFilledCircle(Texture2D tex, int cx, int cy, int r, Color c)
	{
		for (int x = -r; x < r ; x++)
		{
			int height = (int)Mathf.Sqrt(r * r - x * x);

			for (int y = -height; y < height; y++)
				tex.SetPixel(x + cx, y + cy, c);
		}
	}

	// Figure out where to put the radar
	void setRadarLocation()
	{
		_radarCenter = new Vector2 (radarSize / 2, Screen.height - radarSize / 2);
	}
}