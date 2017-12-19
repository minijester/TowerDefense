using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;
    
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        // activeself = true if it already active, false if not active.
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0; // freeze deltatime
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        // go to menu.
        Toggle();
        SceneManager.LoadScene(0);
    }
}
