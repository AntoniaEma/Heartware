using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool moveHorizontal = true;

    private Vector3 _startPosition;
    private int _direction = 1;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 directionVector = moveHorizontal ? Vector3.right : Vector3.up;
        transform.Translate(directionVector * speed * _direction * Time.deltaTime);

        if (Vector3.Distance(_startPosition, transform.position) >= moveDistance)
        {
            _direction *= -1;
        }
    }
}
