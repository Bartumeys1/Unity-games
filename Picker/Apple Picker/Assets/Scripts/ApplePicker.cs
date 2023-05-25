using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public GameObject gameOverObj;
    public static bool isGameOver = false;

    void Start()
    {
        isGameOver = false;
        gameOverObj = GameObject.Find("GameOver");
        gameOverObj.SetActive(false);

        basketList = new List<GameObject>();
        GameObject busket = new GameObject("Busket");
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
            tBasketGO.transform.SetParent(busket.transform);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketindex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketindex];
        basketList.RemoveAt(basketindex);
        Destroy(tBasketGO);

        if(basketList.Count == 0)
        {
            HighScore.SaveHightScore();
            gameOverObj.SetActive(true);
            isGameOver = true;
        }
    }
}
