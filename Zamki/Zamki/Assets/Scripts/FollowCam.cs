using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    [Header("Set Dynamically")]
    public float camZ;
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    private float cameraOffsetMinY = 10f;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 destination;
        // Если нет интересующего объекта, вернуть Р:[ 0, 0, 0 ]
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            // Получить позицию интересующего объекта
            destination = POI.transform.position;
            // Если интересующий объект - снаряд, убедиться, что он остановился
            if (POI.tag == "Projectile")
            {
                // Если он стоит на месте(то есть не двигается)
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    // Вернуть исходные настройки поля зрения камеры
                    POI = null;
                    //в следующем кадре
                    return;
                }
            }
        }
            destination = Vector3.Lerp(transform.position, destination, easing);
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + cameraOffsetMinY;
    }
}
