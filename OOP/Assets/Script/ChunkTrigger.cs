using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetmap;

    
    void Start()
    {
        mc = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {mc.currentChunk = targetmap; }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) ;
        { if (mc.currentChunk == targetmap) 
            { mc.currentChunk = null; }
        }
    }
}
