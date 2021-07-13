
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]private float speed=700f;
    private GameManager _gameManager;
    private float score = 0;

    [SerializeField] private float speed2=5f;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = GameManager.Instance;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "plane" || other.collider.tag == "obstacle")
        {
            _gameManager.SetLevelEnd();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "finishline" || other.tag == "plane")
        {
            _gameManager.SetLevelEnd();
        }

        if (other.tag == "collectable")
        {
            score++;
            Destroy(other.gameObject);
        }
    }

    // public void GetScore()
    // {
    //     return score;
    // }
    public void MovePlayer()
    {
        _rigidbody.velocity = Vector3.forward * (speed * Time.deltaTime);
    }
    public void StopPlayer()
    {
        _rigidbody.velocity = new Vector3(0,-1,0);
    }
    public void JoystickPlayer()
    {
        Vector3 direction = Vector3.right * _floatingJoystick.Horizontal;
        _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal*10f, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }
}