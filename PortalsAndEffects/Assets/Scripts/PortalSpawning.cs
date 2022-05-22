using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawning : MonoBehaviour
{
    public GameObject portalSpawner;

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootPortalSpawner(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShootPortalSpawner(1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ShootPhysicsBall();
        }
    }

    private void ShootPortalSpawner(int portalIndex)
    {
        GameObject gameObject = Instantiate(portalSpawner, this.transform.position + this.transform.forward, Quaternion.identity, null);
        gameObject.GetComponent<SpawnPortal>().PortalIndex = portalIndex;
        gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward*20, ForceMode.Impulse);
    }

    private void ShootPhysicsBall()
    {
        GameObject gameObject = Instantiate(ball, this.transform.position + this.transform.forward, Quaternion.identity, null);
        gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20, ForceMode.Impulse);
    }
}
