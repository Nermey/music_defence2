using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 20f; // скорость снаряда

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
       // transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(target.gameObject); // уничтожение врага (временно)
        Destroy(gameObject);

    }
}
