using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainCamera : MonoBehaviour
{
    public Portal[] portals;

    public static MainCamera instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        portals = FindObjectsOfType<Portal>();
        RenderPipelineManager.beginCameraRendering += RenderPortal;
    }

    //private void LateUpdate()
    //{
    //    for (int i = 0; i < portals.Length; i++)
    //    {
    //        portals[i].PrePortalRender();
    //    }
    //    for (int i = 0; i < portals.Length; i++)
    //    {
    //        portals[i].Render();
    //    }
    //    for (int i = 0; i < portals.Length; i++)
    //    {
    //        portals[i].PostPortalRender();
    //    }
    //}

    private void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= RenderPortal;
    }

    private void RenderPortal(ScriptableRenderContext context, Camera camera)
    {
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].PrePortalRender(context);
        }
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].Render(context);
        }
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].PostPortalRender(context);
        }
    }

}
