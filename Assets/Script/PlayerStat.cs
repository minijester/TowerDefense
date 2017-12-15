using System.Collections;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int Money;
    public int startMoney = 500;

    public static int lives = 0;
    public int startLife = 20;
    private void Start()
    {
        Money = startMoney;
        lives = startLife;
    }

}
