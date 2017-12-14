using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; // point to move to target.
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(waypointIndex >= Waypoint.points.Length - 1) {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoint.points[waypointIndex];
    }

}
