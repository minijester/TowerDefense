using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turrent;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        // If we select the turrent that appear on map then don't build since we want to do that event.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // if didn't select turret then do nothing.
        if (buildManager.GetTurretTobuild() == null)
        {
            return;
        }
        if (turrent != null)
        {
            Debug.Log("Already have turrent");
            return;
        }
        else // build turrent
        {
            GameObject turrentTobuild = BuildManager.instance.GetTurretTobuild();
            turrent = (GameObject) Instantiate(turrentTobuild, transform.position + positionOffset, transform.rotation);
        }
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretTobuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
