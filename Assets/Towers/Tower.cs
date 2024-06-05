using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject prefab;
    public int health = 10;
    public int level = 1;
    public float range = 10.0f;
    public float rechargeTime = 100.0f;

    private double lastShotTime = 0.0;

    void Start()
    {

    }

    void Update()
    {
        var timeNow = Time.timeAsDouble;

        if (timeNow - lastShotTime > rechargeTime)
        {
            var units = FindObjectsOfType<Unit>();
            var (target, distance) = FindClosestUnit(units);

            if (distance <= range)
            {
                var position = transform.position;
                Instantiate(prefab, new(position.x, position.y), Quaternion.identity);
                lastShotTime = timeNow;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Unit>() is Unit unit)
        {
            Destroy(unit.gameObject);
        }
    }

    private (Unit, float) FindClosestUnit(Unit[] units)
    {
        Unit closestUnit = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Unit unit in units)
        {
            float distanceToUnit = Vector3.Distance(currentPosition, unit.transform.position);
            if (distanceToUnit < closestDistance)
            {
                closestDistance = distanceToUnit;
                closestUnit = unit;
            }
        }

        return (closestUnit, closestDistance);
    }
}
