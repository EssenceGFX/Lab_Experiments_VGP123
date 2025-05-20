using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;

    void Start()
    {
        if (itemPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
