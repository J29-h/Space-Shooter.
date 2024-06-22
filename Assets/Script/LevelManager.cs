using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] GameObject GameOverPopUp;
    [SerializeField] GameObject GameWinPopUp;
    public bool isGameOver = false;
    public bool isGameWon = false;
    public int max_lives = 3;
    public GameObject PlayerPrefab;
    public int current_lives;
    public TextMeshProUGUI LivesText;
    public bool isRespawning = false;

    private void Awake()
    {
        instance = this;
        current_lives = max_lives;
        UpdateLivesText();
        LeanTween.moveY(LivesText.gameObject.GetComponent<RectTransform>(), 370f, 1f);
    }

    public void ShowPopUp()
    {
        GameOverPopUp.SetActive(true);
        isGameOver = true;
    }
    //Assignmet 04 Start
    public void GameWonPopUp()
    {
        GameWinPopUp.SetActive(true);
        isGameWon = true;
    }
    //Assignmet 04 End
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void UpdateLivesText()
    {
        LivesText.text = "Lives : " + current_lives.ToString();
    }

    public void ReSpawnPlayer()
    {
        Invoke("ReInitPlayer", 2f);
        isRespawning = true;
    }

    void ReInitPlayer()
    {
        Instantiate(PlayerPrefab, new Vector2(0f, -4.18f), Quaternion.identity);
    }
}
