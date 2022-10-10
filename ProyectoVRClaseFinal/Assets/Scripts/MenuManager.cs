using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] bool onRestartButton;
    [SerializeField] bool onStartButton;
    [SerializeField] bool onSettingsButton;
    [SerializeField] bool isMenuActive=true;

    [SerializeField] Button restartButton;
    [SerializeField] Button startButton;
    [SerializeField] Button settingsButton;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject pointer;

    Enemy[] ghosts;

    // Start is called before the first frame update
    void Start()
    {
        
    }
     void Update()
    {
        if (Input.GetButtonDown("Fire5"))
        {
            if (onRestartButton)
            {
                restartButton.onClick.Invoke();
                Debug.Log("restart");
            }
            else if (onStartButton)
            {
                startButton.onClick.Invoke();
                Debug.Log("start");
            }
            else if (onSettingsButton)
            {
                settingsButton.onClick.Invoke();
                Debug.Log("settings");
            }
            Debug.Log("nada");
        }
        if (!isMenuActive)
        {
            if (Input.GetButtonDown("Fire4"))
            {
                menuCanvas.SetActive(true);
                pointer.SetActive(true);
                Pause();
            }
        }
    }

    public void RestartButton()
    {
        onRestartButton = true;
        onStartButton = false;
        onSettingsButton = false;
    }
    public void StartButton()
    {
        onRestartButton = false;
        onStartButton = true;
        onSettingsButton = false;
        ghosts = FindObjectsOfType<Enemy>();
    }

    void ActiveEnemy()
    {
        Enemy enemy = ghosts.FirstOrDefault(e => !e.isActive);
        enemy.isActive = true;
        if (ghosts.Where(e => !e.isActive).Any())
        {
            Invoke("ActiveEnemy", 3);
        }
    }
    public void SettingsButton()
    {
        onRestartButton = false;
        onStartButton = false;
        onSettingsButton = true;
    }
    public void None()
    {
        onRestartButton = false;
        onStartButton = false;
        onSettingsButton = false;
    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene("Testeo");
    }
    public void OnStartClick()
    {
        menuCanvas.SetActive(false);
        pointer.SetActive(false);
        isMenuActive = false;
        Invoke("ActiveEnemy", 1);
        Debug.Log("Start");
    }
    public void OnSettingsClick()
    {
        
    }
    private void Pause()
    {
        isMenuActive = true;
        Debug.Log("pause");
    }
    // Update is called once per frame
    public bool IsPaused()
    {
        return isMenuActive;
    }
}
