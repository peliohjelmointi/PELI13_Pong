using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Luodaan luokasta staattinen instanssi
    public static GameManager Instance;

    public TextMeshProUGUI scorePlayer1Object;
    public TextMeshProUGUI scorePlayer2Object;

    // public TMP_Text txtScorePlayer1; //works also

    [HideInInspector]
    public int scorePlayer1; //by default value set to 0

    [HideInInspector] public int scorePlayer2;

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
    }


    private void Update()
    {
        scorePlayer1Object.text = scorePlayer1.ToString();
        scorePlayer2Object.text = scorePlayer2.ToString();
    }

}
