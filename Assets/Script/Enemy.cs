using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 50f;
    private Transform target;
    private int waypointIndex = 0;
    public int health = 100;
    public int value = 50;
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

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStat.Money += value;
        Destroy(gameObject);
    }
}
