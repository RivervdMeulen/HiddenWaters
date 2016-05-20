using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureCounter : MonoBehaviour
{
    [SerializeField] private Text foundTreasureText;
    public int maxPickups;
    public int currentPickups;
	
	void Update ()
    {
        SetRescueCount();
	}

    void SetRescueCount()
    {
		foundTreasureText.text = "Treasure:" + currentPickups + "/" + maxPickups;
    }
}
