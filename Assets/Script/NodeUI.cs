using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour {

    private Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Text sellCost;

    public Button upgradeButton;

    private void Start()
    {
        ui.SetActive(false);
    }
    public void SetTarget(Node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.turretBlueprint.sellCost;
        ui.SetActive(true);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.ResetNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.ResetNode();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
