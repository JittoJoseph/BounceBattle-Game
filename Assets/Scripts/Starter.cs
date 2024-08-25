using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    public PlayerController p2;

    public GameObject winPanel;
    //public Text WinText;
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
        winPanel.SetActive(false);
    }

    public void StartCountdown() {
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame() {
        gameController.StartGame();
    }

    public void Start1P() {
        p2.isPlayer = false;
        p2.speed = 6.5f;
        this.StartCountdown();
    }

    public void Start2P() {
        p2.isPlayer = true;
        this.StartCountdown();
    }

    public void WinLeft() {
        winText.text = "Player 1 Won!";
        winPanel.SetActive(true);
    }

    public void WinRight() {
        if(p2.isPlayer){
            winText.text = "Player 2 Won!";
        }
        else {
            winText.text = "Computer Won!";
        }
        
        winPanel.SetActive(true);
    }
}