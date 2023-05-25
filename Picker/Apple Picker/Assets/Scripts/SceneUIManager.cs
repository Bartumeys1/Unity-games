using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUIManager : MonoBehaviour
{
    public Button restartBtn;
    public Button exitBtn;

    public int numberReloadScene = 1;
    public int numberLoadScene = 0;

    private void Start()
    {
        restartBtn.onClick.AddListener(() => {
            SceneManager.LoadScene(numberReloadScene);
        });

        exitBtn.onClick.AddListener(() => {
            SceneManager.LoadScene(numberLoadScene);
        });
    }

}
