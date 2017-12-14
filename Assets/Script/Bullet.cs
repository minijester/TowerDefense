
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public float explostionRadius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // magnitude is current distance of transform.
        // this mean we already hit something.
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); // set this to chast target.

	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(explostionRadius >= 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        // shoot of sphere and check colider that hit by that sphere
        // we will get all of colider that in sphere.
        Collider[] coliders = Physics.OverlapSphere(transform.position, explostionRadius);
        foreach(Collider colider in coliders)
        {
            if (colider.tag == "Enemy")
            {
                Damage(colider.transform);
            }
        } 
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explostionRadius);
    }

}
