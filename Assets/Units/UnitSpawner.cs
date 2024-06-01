using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public List<GameObject> units;

    void Start()
    {
        if (!TryGetComponent<BoxCollider2D>(out var collider))
        {
            throw new System.Exception("Camera component not found.");
        }

        var halfWidth = collider.bounds.size.x / 2.0f;
        var halfHeight = collider.bounds.size.y / 2.0f;

        foreach (var unit in units)
        {
            for (int i = 0; i < 10; i++)
            {
                var x = transform.position.x + Random.Range(-halfWidth, halfWidth);
                var y = transform.position.y + Random.Range(-halfHeight, halfHeight);

                Instantiate(unit, new Vector2(x, y), Quaternion.identity);
            }
        }
    }

    void Update()
    {

    }
}
