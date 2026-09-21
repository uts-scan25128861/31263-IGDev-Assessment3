using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private Enemy[] enemies;
    [SerializeField]
    private PachManh player;
    [SerializeField]
    private Transform pellets;

    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0 && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        StartCoroutine(PlayEntryThenLoop());
    }

    IEnumerator PlayEntryThenLoop()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.Play("Entry");

        yield return new WaitForSecondsRealtime(5f);
        
        LoopMusic();

    }

    private void LoopMusic()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.Play("Background");
        
    }
}
