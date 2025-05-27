using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private Transform currentCheckpoint;

    #region Player Controller Info
    [SerializeField] private Player playerPrefab;
    private Player playerInstance;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            string loadedSceneName = currentSceneName == "Game" ? "Title" : "Game";
            SceneManager.LoadScene(loadedSceneName);
        }
    }
}