using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text bestScoreText;

	void Start () {
        bestScoreText.text = "Best Score: " + 
            Prefs.GetInt(PrefTypeInt.BestScore, 0).ToString();
	}

    public void Play()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound);
        SceneManager.LoadScene(1);
    }

}
