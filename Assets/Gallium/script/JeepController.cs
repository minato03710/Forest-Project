using UnityEngine;

public class JeepController : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private int currentWaypoint = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        Transform target = waypoints[currentWaypoint];

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude < 1f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = waypoints.Length - 1;
                return;
            }

            target = waypoints[currentWaypoint];
            direction = target.position - transform.position;
            direction.y = 0f;
        }

        // move
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // Jeep Facing the direction of travel
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
