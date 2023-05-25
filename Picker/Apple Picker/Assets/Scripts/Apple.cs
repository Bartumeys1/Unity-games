
using UnityEngine;

public class Apple : MonoBehaviour
{

    public static float bootomY = -20f;

    private void Update()
    {
        if (transform.position.y < bootomY)
        {
            Destroy(gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }
    }
}
