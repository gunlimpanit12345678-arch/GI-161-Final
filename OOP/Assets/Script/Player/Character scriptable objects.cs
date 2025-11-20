using UnityEngine;
[CreateAssetMenu(fileName ="CharacterScriptableObject",menuName = "ScriptableObject/Character")]
public class CharacterScriptableObjects : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon {  get=>StartingWeapon; private set => StartingWeapon = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => MaxHealth; private set => MaxHealth = value; }

    [SerializeField]
    float recovery;
    public float Recovery { get => Recovery; private set => Recovery = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => MoveSpeed; private set => MoveSpeed = value; }

    [SerializeField]
    float might;
    public float Might { get => Might; private set => Might = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }
}
