using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position; // point to move to target.
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoint.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStat.lives -= 1;
        Destroy(gameObject);
    }
}
