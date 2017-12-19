using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        // If we select the turrent that appear on map then don't build since we want to do that event.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
  
        if (turret != null)
        {
            buildManager.SelectNode(this);
        }

        // if didn't select turret then do nothing.
        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStat.money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        else
        {
            PlayerStat.money -= blueprint.cost;
            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            turretBlueprint = blueprint;

            GameObject effect = (GameObject)Instantiate(blueprint.effect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
            Debug.Log("Turrent build! Money left " + PlayerStat.money);
        }
    }

    public void UpgradeTurret()
    {
        if (PlayerStat.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade!");
            return;
        }
        else
        {
            PlayerStat.money -= turretBlueprint.upgradeCost;

            // Get rid of old turret and build new one
            Destroy(turret);

            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(turretBlueprint.upgradeEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
            Debug.Log("Turrent Upgrade! Money left " + PlayerStat.money);
            isUpgraded = true;
        }
    }

    public void SellTurret()
    {
        PlayerStat.money += turretBlueprint.sellCost;
        Destroy(turret);
        GameObject effect = (GameObject)Instantiate(turretBlueprint.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
