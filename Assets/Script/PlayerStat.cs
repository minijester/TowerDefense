﻿using System.Collections;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int Money;
    public int startMoney = 500;

    private void Start()
    {
        Money = startMoney;
    }

}
