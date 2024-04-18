using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
// Reference to the button
    public Button startButton;
    public Button exitButton;
    public Button settingsButton;
    public Button backButton;
    public GameObject canvasOne;
    public GameObject canvasTwo;
    public GameObject menu;
    public InputActionProperty ShowButton;
    public Transform head;
    public  float spawnDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the start button
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        settingsButton.onClick.AddListener(Settings);
        backButton.onClick.AddListener(BackToMenu);

        // Ensure Canvas One is enabled and Canvas Two is disabled at the start
        canvasOne.SetActive(true);
        canvasTwo.SetActive(false);

    }

    void Update()
    {
        // Check if the ShowButton action was pressed this frame
        if (ShowButton.action.WasPressedThisFrame())
        {
            // Toggle the menu on and off
            menu.SetActive(!menu.activeSelf);
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
        
        // Rotate the menu to face the player
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;


    }

    // Function to be called when the start button is clicked
    void StartGame()
    {
        Debug.Log("Game started!");
        // Load Scene 01
        SceneManager.LoadScene("Art Gallery");
        PlayerPrefs.Save();
    }

    // Function to be called when the exit button is clicked
    void ExitGame()
    {
        Debug.Log("Game exited!");
        // Exit the game
        Application.Quit();
    }

    void Settings()
    {
        Debug.Log("Settings opened!");
        // Turn off Canvas One
        canvasOne.SetActive(false);
        // Turn on Canvas Two
        canvasTwo.SetActive(true);
    }

    void BackToMenu()
    {
        Debug.Log("Back to menu!");
        // Turn off Canvas Two
        canvasTwo.SetActive(false);
        // Turn on Canvas One
        canvasOne.SetActive(true);
    }

}
