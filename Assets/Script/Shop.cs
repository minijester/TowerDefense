using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint fastTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeam;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("standard");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectFastTurret()
    {
        Debug.Log("fast");
        buildManager.SelectTurretToBuild(fastTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeam()
    {
        Debug.Log("Laser");
        buildManager.SelectTurretToBuild(laserBeam);
    }



}
