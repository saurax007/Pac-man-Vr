using System.Collections;
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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
            if (Input.GetButtonDown("Fire2"))
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
        Debug.Log("Start");
    }
    public void OnSettingsClick()
    {
        
    }
    public void Pause()
    {
        isMenuActive = true;
        Debug.Log("pause");
    }
    // Update is called once per frame

}
