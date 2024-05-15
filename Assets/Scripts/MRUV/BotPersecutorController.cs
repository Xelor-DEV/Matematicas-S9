using UnityEngine;
public class BotPersecutorController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float decelerationDistance = 10f;
    [SerializeField] private float stopDistance = 1f;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    private Vector3 Position(Vector3 initialVelocity, float time, Vector3 acceleration)
    {
        Vector3 x = initialVelocity * time + 0.5f * acceleration * time * time;
        return x;
    }
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > stopDistance)
        {
            velocity = velocity + direction * acceleration * Time.deltaTime;

            if (distanceToTarget < decelerationDistance)
            {
                float deceleration = acceleration * (distanceToTarget / decelerationDistance);
                velocity = velocity - direction * deceleration * Time.deltaTime;
            }
            Vector3 newPosition = Position(velocity, Time.deltaTime, acceleration * direction);
            transform.position = transform.position + newPosition;
        }
        else
        {
            velocity = Vector3.zero;
        }
    }
}
