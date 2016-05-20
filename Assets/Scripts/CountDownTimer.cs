using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOver;

	[SerializeField]
	private float totalTime;

	[SerializeField]
	private RectTransform Needle;

	private float minusCount;
	private float currentCount = -72f;

	void Start () {
		totalTime *= 30f;
		minusCount = 144f / totalTime;
		minusCount *= -1f;
	}

	void FixedUpdate ()
    {
		
        if (currentCount >= 72)
        {
            //Hier stopt de game.
            Time.timeScale = 0;
			gameOver.SetActive (true);
            //_countDownText.text = "Time left: 00:00:00";
        }
        else
        {
            Countdown();
        }
	}

    private void Countdown()
    {
        //timerCount -= Time.deltaTime;

        //var minutes = timerCount / 60;
        //var seconds = timerCount % 60;
        //var fraction = (timerCount * 100) % 100;

        //_countDownText.text = string.Format("Time left: {0:00}:{1:00}:{2:00}", Mathf.Floor(minutes), seconds, fraction); 

		Needle.rotation = Quaternion.Euler (0, 0, currentCount);
		currentCount -= minusCount;
    }
}
