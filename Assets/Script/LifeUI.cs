﻿using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour {

    public Text lifeText;
	// Update is called once per frame
	void Update () {
        lifeText.text = "Lives : " + PlayerStat.lives.ToString();
	}
}
