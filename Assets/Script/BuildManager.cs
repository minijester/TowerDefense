using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private GameObject turrentToBuild;

    public GameObject standardTurretPrefab;
    public GameObject fastTurretPrefab;
    public GameObject missileLauncherPrefab;

    
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

    public GameObject GetTurretTobuild()
    {
        return turrentToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }

    public void resetTurret()
    {
        turrentToBuild = null;
    }
}
