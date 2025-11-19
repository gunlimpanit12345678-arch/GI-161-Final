using UnityEngine;

public class EnemeStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
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
}
