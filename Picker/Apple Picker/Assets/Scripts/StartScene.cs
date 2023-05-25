
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
	public Button startGameBtn;
	public Text hightScoreText;

	private int numberLoadScene = 1;


	private void Start()
	{
		int HightScoreInt = PlayerPrefs.GetInt(HighScore.HightScore_Prefs);
		Button btn = startGameBtn.GetComponent<Button>();
		btn.onClick.AddListener(OnClickStartGame);

		hightScoreText.text = "Hight score: " + HightScoreInt;
	}

	public void OnClickStartGame()
    {
		SceneManager.LoadScene(numberLoadScene);
	}

}
