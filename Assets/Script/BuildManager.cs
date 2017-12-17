using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turrentToBuild;

    /*[Header("TurretPrefab")]

    public GameObject standardTurretPrefab;
    public GameObject fastTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject laserBeam;*/


    [Header("Effect")]
    public GameObject buildEffect;
    
    private void Awake()
    {
        if(instance != null){
            Debug.LogError("More than one BuildManager in Scene");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            resetTurret();
        }
    }

    // properties only allow to get somehing
    public bool CanBuild { get { return turrentToBuild != null; } }
    // if turrentToBuild = null - false, if not true.

    public bool HasMoney { get { return PlayerStat.Money >= turrentToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStat.Money < turrentToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        else
        {
            PlayerStat.Money -= turrentToBuild.cost;
            GameObject turret = (GameObject) Instantiate(turrentToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;

            GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
            Debug.Log("Turrent build! Money left " + PlayerStat.Money);
        }
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrentToBuild = turret;
    }

    public void resetTurret()
    {
        turrentToBuild = null;
    }
}
