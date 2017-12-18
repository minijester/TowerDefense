using System.Collections;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int money;
    public int startMoney = 500;

    public static int lives = 0;
    public int startLife = 20;

    public static int round;

    private void Start()
    {
        money = startMoney;
        lives = startLife;
        round = 0;
    }

}
