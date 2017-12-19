using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100f;
    public int value = 50;

    private void Start()
    {
        speed = startSpeed; 
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        PlayerStat.money += value;
        Destroy(gameObject);
    }


}
