using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 0, -10);

    void Update()
    {
        transform.position = player.position + offset;
    }
}
