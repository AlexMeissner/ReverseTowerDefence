using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health = 10;
    public int level = 1;

    void Start()
    {

    }

    void Update()
    {
        var units = FindObjectsOfType<Unit>();

        foreach (var unit in units)
        {
            unit.transform.Rotate(0.0f, 0.0f, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.gameObject.GetComponent<Unit>();
        unit.movementSpeed *= -1.0f;

        health -= unit.health;

        if (health <= 0)
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.color = Color.red;
        }
    }
}
