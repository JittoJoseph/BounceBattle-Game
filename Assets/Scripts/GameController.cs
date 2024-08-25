using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    private AudioSource goalSound;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    public Starter starter;
    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private BallController ballController;
    private Vector3 startingPosition;

    CinemachineImpulseSource impulse;

    // Start is called before the first frame update
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
        this.goalSound = this.GetComponent<AudioSource>();
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f); // Default to 1.0 if not set
        goalSound.volume = savedVolume + 0.2f;
        impulse = transform.GetComponent<CinemachineImpulseSource>();

    }


    
    void Update()
    {
        if (!this.started)
            return;

        if(Input.GetKey(KeyCode.Escape))
        {
            this.started = false;
            this.ballController.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
    }
    

    public void StartGame()
    {
        this.started = true;
        this.ballController.Go();
    }

    public void ScoreGoalLeft()
    {
        //Debug.Log("ScoreGoalLeft");
        Invoke("Shake", 0f);
        this.scoreRight += 1;
        goalSound.Play();
        UpdateUI();
        ResetBall();
        if(this.scoreRight > 4)
            this.starter.WinRight();
    }
    public void ScoreGoalRight()
    {
        //Debug.Log("ScoreGoalRight");
        Invoke("Shake", 0f);
        this.scoreLeft += 1;
        goalSound.Play();
        UpdateUI();
        ResetBall();
        if(this.scoreLeft > 4)
            this.starter.WinLeft();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }

    public void Shake()
    {
        impulse.GenerateImpulse();
    }

}
