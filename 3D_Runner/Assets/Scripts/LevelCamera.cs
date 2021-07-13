
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    private Vector3 distance;
    private void Start()
    {
        distance = playerTransform.position - transform.position;
    }
    public void LevelCamMove()
    {
        transform.position = playerTransform.position - distance;
    }
}
