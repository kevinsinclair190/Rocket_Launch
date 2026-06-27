using UnityEngine;
public class MovingObstacle : MonoBehaviour
{
    [SerializeField] Vector3 movementAmount = new Vector3(0, 5f, 0);
    [SerializeField] float period = 2f;

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * 2 * Mathf.PI);
        float moveAmount = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementAmount * moveAmount;
        transform.position = startPosition + offset;
    }
}