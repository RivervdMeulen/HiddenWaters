using UnityEngine;
using System.Collections;

public class ExitPoint : ObjectCollision
{
    [SerializeField] 
	private GameObject victoryImage;

    public override void ObjectHit()
    {
        base.ObjectHit();

		GameObject _rescueText = GameObject.Find("foundTreasures");
        TreasureCounter _rescueScript = _rescueText.GetComponent<TreasureCounter>();

        if (_rescueScript.currentPickups < _rescueScript.maxPickups)
        {
            print("Not enough treasures found!");
        }

        else
        {
            print("You Win!!");
            victoryImage.SetActive(true);
            Time.timeScale = 0;
        }
    }
}