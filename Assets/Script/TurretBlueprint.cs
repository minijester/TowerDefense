using System.Collections;
using UnityEngine;

// use to create class that show in inspector.
[System.Serializable]

public class TurretBlueprint {

    [Header("Create turret")]
    public GameObject prefab;
    public int cost;
    public GameObject effect;

    [Header("Upgrade Turret")]
    public GameObject upgradePrefab;
    public int upgradeCost;
    public GameObject upgradeEffect;

    [Header("Sell")]
    public int sellCost;
    public GameObject sellEffect;
}
