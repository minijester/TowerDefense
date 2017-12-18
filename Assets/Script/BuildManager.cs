using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turrentToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    
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
            ResetTurret();
            ResetNode();
        }
    }

    // properties only allow to get somehing
    public bool CanBuild { get { return turrentToBuild != null; } }
    // if turrentToBuild = null - false, if not true.

    public bool HasMoney { get { return PlayerStat.money >= turrentToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrentToBuild = turret;
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectNode(Node node)
    {

        selectedNode = node;
        turrentToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void ResetTurret()
    {
        turrentToBuild = null;
    }

    public void ResetNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turrentToBuild;
    }
}
