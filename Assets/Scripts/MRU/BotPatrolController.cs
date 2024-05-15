using UnityEngine;
public class BotPatrolController : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] patrolPoints;
    private int currentPointIndex = 0;
    // muestro velocity para que se vea que la velocidad se mantiene constante cuando este se mueve de un punto a otro
    [SerializeField] private Vector3 velocity;
    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            Vector3 initialPosition = patrolPoints[0].transform.position + new Vector3(0.1f, 0, 0);
            transform.position = initialPosition;
            transform.LookAt(patrolPoints[currentPointIndex].transform);
            float timeToNextPoint = patrolPoints[currentPointIndex].GetTimeToNextPoint();
            Vector3 finalPosition = patrolPoints[(currentPointIndex + 1) % patrolPoints.Length].transform.position;
            velocity = CalculateVelocity(initialPosition, finalPosition, timeToNextPoint);
        }
    }

    void Update()
    {
        if (patrolPoints.Length != 0)
        {
            transform.position = CalculateFinalPosition(transform.position, velocity, Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[(currentPointIndex + 1) % patrolPoints.Length].transform.position) < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                float timeToNextPoint = patrolPoints[currentPointIndex].GetTimeToNextPoint();
                Vector3 finalPosition = patrolPoints[(currentPointIndex + 1) % patrolPoints.Length].transform.position;
                velocity = CalculateVelocity(transform.position, finalPosition, timeToNextPoint);
            }
        }
    }
    // Metodos para el MRU
    Vector3 CalculateVelocity(Vector3 initialPosition, Vector3 finalPosition, float time)
    {
        Vector3 velocity = (finalPosition - initialPosition) / time;
        return velocity;
    }
    Vector3 CalculateFinalPosition(Vector3 initialPosition, Vector3 velocity, float time)
    {
        Vector3 finalPosition = initialPosition + velocity * time;
        return finalPosition;
    }
}
