using UnityEngine;

public class SwordController : WeaponController
{
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSword = Instantiate(prefab);
        spawnedSword.transform.position = transform.position ;
        spawnedSword.GetComponent<Swordbehaviour>().DirectionChecker(pm.lastMovedVector);
    }
    
}
