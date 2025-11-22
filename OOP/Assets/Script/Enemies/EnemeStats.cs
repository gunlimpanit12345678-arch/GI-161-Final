using UnityEngine;

public class EnemeStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    public float deSpawnDistance = 20f;
    Transform player;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    void Start()
    {
     player = FindObjectOfType<PlayerStats>().transform;   
    }

     void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= deSpawnDistance)
        {

        }
    }

    public void TakeDamage(float dmg) 
    {
     currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill() 
    {
     Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnerPoints[Random.Range(0,es.relativeSpawnerPoints.Count)].position;
    }
}
