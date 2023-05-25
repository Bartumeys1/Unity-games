using UnityEngine;
using UnityEngine.UI;

public class Busket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter_lable");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    private void FixedUpdate()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collideWiyh = coll.gameObject;
        if (collideWiyh.tag == "Apple")
        {
            Destroy(collideWiyh);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
       
    }
}
