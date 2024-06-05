using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health = 5;
    public float movementSpeed = 1.0f;

    private GameObject enemyBase;
    private GameObject targetLine;

    void Start()
    {
        enemyBase = GameObject.Find("AiBase");
        targetLine = GameObject.Find("TargetLine");
    }

    void Update()
    {
        if (transform.position.x > targetLine.transform.position.x)
        {
            MoveLeft();
        }
    }

    void MoveLeft()
    {
        var delta = movementSpeed * Time.deltaTime;
        var position = transform.position - new Vector3(delta, 0.0f, 0.0f);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Tower>() is Tower tower)
        {
            tower.health -= health;

            if (tower.health <= 0)
            {
                Destroy(tower.gameObject);
            }
        }
        else if (other.GetComponent<Projectile>() is Projectile projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}
