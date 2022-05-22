using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoxCollider LeftPortal;
    public BoxCollider RightPortal;

    public MeshRenderer LeftPortal_Mesh;
    public MeshRenderer RightPortal_Mesh;

    public MeshRenderer LeftPortal_PlaceholderMesh;
    public MeshRenderer RightPortal_PlaceholderMesh;

    private bool leftPortal_isActive = false;
    private bool rightPortal_isActive = false;

    private bool portalsAreLinked = false;

    public static GameManager instance=null;

    public bool PortalsAreLinked { get => portalsAreLinked; set => portalsAreLinked = value; }
    public bool LeftPortal_isActive { get => leftPortal_isActive; set => leftPortal_isActive = value; }
    public bool RightPortal_isActive { get => rightPortal_isActive; set => rightPortal_isActive = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinkPortals()
    {
        Debug.Log("linking portals");
        LeftPortal.enabled = true;
        RightPortal.enabled = true;

        LeftPortal_Mesh.enabled = true;
        RightPortal_Mesh.enabled = true;

        LeftPortal_PlaceholderMesh.enabled = false;
        RightPortal_PlaceholderMesh.enabled = false;

        portalsAreLinked = true;
    }

    public void UnlinkPortals()
    {
        LeftPortal.enabled = false;
        RightPortal.enabled = false;

        LeftPortal_Mesh.enabled = false;
        RightPortal_Mesh.enabled = false;

        LeftPortal_PlaceholderMesh.enabled = true;
        RightPortal_PlaceholderMesh.enabled = true;

        portalsAreLinked = false;
    }

    public void ActivatePortal(int portalIndex)
    {

    }
}
