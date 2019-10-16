using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Game : MonoBehaviour {

    public static Game instance;

    [SerializeField]
    private GameObject loseCanvas;
    [SerializeField]
    private GameObject gvrRecticle;
    [SerializeField]
    private GameObject recticle;
    [SerializeField]
    private GameObject loadingPanel;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text scoreText;

    public int bonusPoints = 10;

    [SerializeField]
    private float startSpeed = 2;
    [SerializeField]
    private float speedIncreaseDelta = 0.01F;
    [SerializeField]
    private float speedIncreaseInterval = 0.75F;

    [HideInInspector]
    public float currentSpeed;

    public bool isPlaying = true;

    private int currentScore;
    private int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            scoreText.text = "Score: " + value.ToString();
        }
    }

    private void OnEnable()
    {
        Player.onHitEnemy += Lose;
        Player.onCollectedBonus += IncreaseScore;
    }

    private void OnDisable()
    {
        Player.onHitEnemy -= Lose;
        Player.onCollectedBonus -= IncreaseScore;
    }

    private void Awake()
    {
        ObjectSpawner.planesSpawned = 0;
        instance = this;
    }

    private IEnumerator Start()
    {
        loadingPanel.gameObject.SetActive(true);
        currentSpeed = 0;
        yield return new WaitForSeconds(1);
        loadingPanel.GetComponentInChildren<Text>().gameObject.SetActive(false);
        loadingPanel.GetComponent<Image>().DOFade(0, 0.75F);
        yield return new WaitForSeconds(1);

        currentSpeed = startSpeed;
        while(isPlaying)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            currentSpeed += speedIncreaseDelta;
        }
    }

    private void IncreaseScore(int amount)
    {
        CurrentScore += amount;
    }

    private void Lose()
    {
        isPlaying = false;
        FindObjectOfType<PlatformMoving>().enabled = false;
        FindObjectOfType<Player>().enabled = false;
        FindObjectOfType<PlayerController>().ReturnToinitialPosition();

        // Setting HighScore
        var oldHighScore = Prefs.GetInt(PrefTypeInt.BestScore, 0);
        currentScoreText.text = "Your Score: " + CurrentScore.ToString();
        highScoreText.text = "Best Score: " + oldHighScore.ToString();

        if (currentScore > oldHighScore)
        {
            currentScoreText.text = "New Best Score: " + CurrentScore.ToString();
            highScoreText.text = "Old Best Score: " + oldHighScore.ToString();
            Prefs.SetInt(PrefTypeInt.BestScore, 0, currentScore);
        }

        scoreText.gameObject.SetActive(false);

        gvrRecticle.SetActive(false);
        recticle.SetActive(true);
        loseCanvas.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound);
        SceneManager.LoadScene(1);
    }
}
