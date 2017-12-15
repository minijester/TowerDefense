using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameEnded = false;
	
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
    }
}
