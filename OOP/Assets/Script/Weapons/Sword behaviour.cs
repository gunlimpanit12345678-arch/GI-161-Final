using UnityEngine;

public class Swordbehaviour : Projectileweaponbehaviour
{
    SwordController sc;
    void Start()
    {
        base.Start();
        sc = FindObjectOfType<SwordController>();
    }

    
    void Update()
    {
        transform.position += direction * sc.speed * Time.deltaTime;
    }
}
