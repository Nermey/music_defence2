using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int health = 30;
    public int reward = 20;

    private Transform target;
    private int waypointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        PlayerStats.Money += reward;
        Destroy(gameObject);
    }

    void Update ()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint ()
    {
        if (waypointIndex >= Waypoints.points.Length - 1) 
        {

            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }    
}
