using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunk;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunk;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if (!currentChunk) {return; }

        if(pm.moveDir.x > 0 &&  pm.moveDir.y == 0 ) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            { 
             noTerrainPosition = currentChunk.transform.Find("Right").position;
             SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //up right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up Right").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //down right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down Right").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //up left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up Left").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //down left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down Left").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0,terrainChunk.Count);
        latestChunk = Instantiate(terrainChunk[rand], noTerrainPosition,Quaternion.identity);
        spawnedChunk.Add(latestChunk);

    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime ;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;

        }
        else { return; }
        foreach (GameObject chunk in spawnedChunk)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            { chunk.SetActive(false); }
            else { chunk.SetActive(true); }
        }
    }
}
