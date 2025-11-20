using UnityEngine;

public class HealPotion : MonoBehaviour, ICollectible
{
    public int healthRestore;
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthRestore);
        Destroy(gameObject);
    }
}
