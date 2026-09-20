using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

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
        Debug.Log("HERE");
    }
}
