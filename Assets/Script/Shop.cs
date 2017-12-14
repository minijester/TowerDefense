using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("standard");
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseFastTurret()
    {
        Debug.Log("fast");
        buildManager.setTurretToBuild(buildManager.fastTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile");
        buildManager.setTurretToBuild(buildManager.missileLauncherPrefab);
    }

    public void PurchaseLaserTurrent()
    {

    }


}
