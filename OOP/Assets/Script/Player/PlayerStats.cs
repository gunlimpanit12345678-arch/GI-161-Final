using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObjects characterData;

    float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap = 100;
    public int experienceCapIncrease;

   

     void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityDuration -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelChecker();
    }

    void LevelChecker()
    {
        if (experience >= experienceCap)
            level++;
        experience -= experienceCap;
        experienceCap += experienceCapIncrease;
    }

    

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("Player is dead");
    }

    public void RestoreHealth(float amount)
    {
        if (currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;
            if (currentHealth > characterData.MaxHealth)
            {  currentHealth = characterData.MaxHealth;}
        }
    }
}
