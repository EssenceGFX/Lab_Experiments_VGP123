using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public Transform PlayerSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => GameManager.Instance.InstantiatePlayer(PlayerSpawn.position);
}
