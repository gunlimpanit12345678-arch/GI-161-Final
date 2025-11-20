using UnityEngine;

public class Projectileweaponbehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

     void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }

   
    public void DirectionChecker(Vector3 dir) 
    { 
     direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0)//left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0)//down
        { 
          scale.y=scale.y * -1;
        }
        else if (dirx == 0 && diry > 0)//up
        {
            scale.x = scale.x * -1;
        }
        else if (dirx > 0 && diry > 0)//up right
        {
            rotation.z = 0f;
        }
        else if (dirx > 0 && diry < 0)//down right
        {
            rotation.z =-90f;
        }
        else if (dirx < 0 && diry > 0)//up left
        {
            scale.x = scale.x*-1;
            scale.y = scale.y*-1;
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry < 0)//down left
        {
            scale.x=scale.x*-1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
     if(col.CompareTag("Enemy"))
        { EnemeStats enemy = col.GetComponent<EnemeStats>();
         enemy.TakeDamage(currentDamage);
         ReducePierce();
        }
     else if (col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {  breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        { Destroy(gameObject); }

    }
}
