using UnityEngine;

public class ExpienceGem : MonoBehaviour ,ICollectible
{
    public int experienceGranted;
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }

   
}
