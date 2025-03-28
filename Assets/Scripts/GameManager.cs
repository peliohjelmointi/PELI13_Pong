using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Luodaan luokasta staattinen instanssi
    public static GameManager Instance;

    public GameObject ballPrefab;

    //jos tulee 2 tai useampi pallo
    GameObject ball; //aluksi null

    public TextMeshProUGUI scorePlayer1Object;
    public TextMeshProUGUI scorePlayer2Object;

    // public TMP_Text txtScorePlayer1; //works also

    [HideInInspector] //ei näytetä unityn editorissa
    public int scorePlayer1; //by default value set to 0

    [HideInInspector] 
    public int scorePlayer2;

    private void TrySpawnBall(Scene scene, LoadSceneMode mode)
    {        
        if(ball==null) //jos pallo on null, niin vain silloin spawnataan
            SpawnBall(); 
    }

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
            // mitä tapahtuu kun scene on ladattu:
            SceneManager.sceneLoaded += TrySpawnBall;      
            //called after a new scene has been loaded
            //it's not called for the first scene loaded at game startup,
            //unless loaded manually via SceneManager.LoadScene()
        }
        #region ohjeet
        // #region on näppärä kun haluaa piilottaa
        // tietyt koodipätkät, esim. dokumentaatiot        
        #endregion
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= TrySpawnBall;
    }

    private void Start()
    {
        //if(ball==null)
        SpawnBall();
    }

    private void Update()
    {
        scorePlayer1Object.text = scorePlayer1.ToString();
        scorePlayer2Object.text = scorePlayer2.ToString();
    }

    void SpawnBall()
    {        
        ball = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        ball.name = "BALL"; //vain esimerkki
        
    }

    public void AddScore(int player)
    {        
        if (player == 1) scorePlayer1++;
        else scorePlayer2++;             

        // jos jompikumpi score == 3, vaihdetaan leveliä
        if(scorePlayer1==1 || scorePlayer2 ==1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }

}
