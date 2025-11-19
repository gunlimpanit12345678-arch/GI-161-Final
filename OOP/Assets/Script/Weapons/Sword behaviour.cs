using UnityEngine;

public class Swordbehaviour : Projectileweaponbehaviour
{
    
    void Start()
    {
        base.Start();
        
    }

    
    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime;
    }
}
