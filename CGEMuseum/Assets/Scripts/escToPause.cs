using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class escToPause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused;
    public GameObject pauseMenu;


    public void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseMenu.SetActive(false);
       
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                resume();
            }
            else
                pause();




        }




    }
    public void pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void toMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void quit()
    {
        Application.Quit();
    }
}
