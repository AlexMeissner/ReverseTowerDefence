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

    void MoveToEnemyHealth()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Tower>() != null)
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;
            enabled = false;
        }
    }
}
