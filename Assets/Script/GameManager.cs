using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded;
    public GameObject gameOverUI;

    private void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update () {
        if (gameEnded)
        {
            return;
        }
		if(PlayerStat.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        
    }
}
