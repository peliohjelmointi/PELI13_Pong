using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Luodaan luokasta staattinen instanssi
    public static GameManager Instance;

    public GameObject ballPrefab;

    public TextMeshProUGUI scorePlayer1Object;
    public TextMeshProUGUI scorePlayer2Object;

    // public TMP_Text txtScorePlayer1; //works also

    [HideInInspector] //ei näytetä unityn editorissa
    public int scorePlayer1; //by default value set to 0

    [HideInInspector] 
    public int scorePlayer2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #region ohjeet
        // #region on näppärä kun haluaa piilottaa
        // tietyt koodipätkät, esim. dokumentaatiot        
        #endregion
    }

    private void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        scorePlayer1Object.text = scorePlayer1.ToString();
        scorePlayer2Object.text = scorePlayer2.ToString();
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        ball.name = "BALL"; //vain esimerkki
        
    }

    public void AddScore(int player)
    {     
        if (player == 1) scorePlayer1++;
        else scorePlayer2++;
        
        // jos jompikumpi score == 3, vaihdetaan leveliä
        // LEVELIN VAIHTO TÄHÄN
    }

}
