using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    //public GameObject portalPrefab;

    //private GameObject newPortal;

    private Portal LeftPortal;
    private Portal RightPortal;

    private Portal[] portals = new Portal[2];

    private Portal thisPortal;
    private Portal otherPortal;

    private int portalIndex;

    public int PortalIndex { get => portalIndex; set => portalIndex = value; }

    private void Awake()
    {
        LeftPortal = GameManager.instance.LeftPortal.GetComponent<Portal>();
        RightPortal = GameManager.instance.RightPortal.GetComponent<Portal>();

        portals[0] = LeftPortal;
        portals[1] = RightPortal;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normalVal = collision.contacts[0].normal;
        if (collision.transform.tag == "Portalable")
        {
            if (PortalIndex == 0)
            {
                thisPortal = LeftPortal;
                otherPortal = RightPortal;
            }
            else
            {
                thisPortal = RightPortal;
                otherPortal = LeftPortal;
                normalVal *= -1;
            }

            



            if (GameManager.instance.PortalsAreLinked == true)
            {
                GameManager.instance.UnlinkPortals();
            }

            thisPortal.transform.position = this.transform.position;
            thisPortal.transform.rotation = Quaternion.LookRotation(normalVal, Vector3.up);
            thisPortal.GetComponentInChildren<Portal>().Surface = collision.gameObject;
            thisPortal.IsActive = true;

            if (otherPortal.IsActive)
            {
                GameManager.instance.LinkPortals();
                thisPortal.IsLinked = true;
                otherPortal.IsLinked = true;
            }
            else
            {
                if (portalIndex == 0)
                {
                    GameManager.instance.LeftPortal_PlaceholderMesh.enabled = true;
                }
                else
                {
                    GameManager.instance.RightPortal_PlaceholderMesh.enabled = true;
                }
            }
            

            //MainCamera.instance.LookForPortals();

            this.gameObject.SetActive(false);
            
            
        }
        
    }
}
