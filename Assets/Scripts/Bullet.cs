using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 20f; // скорость снаряда
    public float explotionRadius = 0f; // радиус поражения

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        
        Destroy(gameObject);

        if (explotionRadius > 0f) 
        {
            
        }
        else
        {
            Destroy(target);
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject); // уничтожение врага (временно)
    }
}
