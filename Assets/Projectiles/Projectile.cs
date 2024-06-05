using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1.0f;
    public int damage = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Tower>() is Tower unit)
        {
            unit.health -= damage;

            if (unit.health <= 0)
            {
                Destroy(unit.gameObject);
            }
        }
    }
}
