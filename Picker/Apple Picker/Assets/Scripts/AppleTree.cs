
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для створення яблука
    public GameObject applePrefab;
    // Швидкість руху яблоні
    public float speed = 1f;
    // границі куди доходить дерево
    public float leftAndRightEdge = 20f;
    //Вирогідність змани направлення руху дерева
    public float chanceToChangeDirections = 0.1f;
    // Швидкість створення яблука
    public float secondsBetweenAppleDrops = 1f;


    private void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (ApplePicker.isGameOver) return;

        Vector3 pos = transform.position;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);

        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
            speed *= -1;
    }

    private void DropApple()
    {
        if (ApplePicker.isGameOver) return;

        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
