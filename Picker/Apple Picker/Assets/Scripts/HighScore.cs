using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;
    public const string HightScore_Prefs = "HIGH_SCORE";


    void Awake()
    {
        if (PlayerPrefs.HasKey(HightScore_Prefs))
        { 
            score = PlayerPrefs.GetInt(HightScore_Prefs);
        }
        // Сохранить высшее достижение HighScore в хранилище
        PlayerPrefs.SetInt(HightScore_Prefs, score); // c
    }

    private void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
    }

    public static void SaveHightScore()
    {
        if (score > PlayerPrefs.GetInt(HightScore_Prefs))
        {
            PlayerPrefs.SetInt(HightScore_Prefs, score);
        }
    }
}
