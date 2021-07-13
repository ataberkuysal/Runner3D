
using UnityEngine;

public class ObstacleCapsule : MonoBehaviour
{
    private Vector3 pos;
    
    void Start()
    {
        pos = transform.position;
        transform.position = pos;
    }

    public void MoveCapsule()
    {
        pos.x += Mathf.PingPong(Time.time, 5)-3f;
    }
}
