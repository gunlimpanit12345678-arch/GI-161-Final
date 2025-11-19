using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{
    Transform player;
    public EnemyScriptableObject enemyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position,enemyData.MoveSpeed*Time.deltaTime);
    }
}
