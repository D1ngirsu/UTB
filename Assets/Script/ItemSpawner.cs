using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject cherryPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0) Instantiate(bananaPrefab, point.position, Quaternion.identity);
            else if (rnd == 1) Instantiate(cherryPrefab, point.position, Quaternion.identity);
            // rnd == 2 thì để trống
        }
    }
}
