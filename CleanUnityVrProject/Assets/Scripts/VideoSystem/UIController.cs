using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean menuHiderAction;
    
    public LaserRaycast raycastLaser;
    public ControllerGrabObject grabObject;
    public HideMenuScript menu;
    public PlayPauseScript playBtn;
    public FastForwardScript ff;
    public Collider leftVideoCube, rightVideoCube;

    private Collider col = null;


    // Update is called once per frame
    void Update()
    {
        col = raycastLaser.GetColliderHit();
        if (col != null) //Don't have to go through the whole loop if its null, saves time
        {
            Debug.Log(col.gameObject.name);
            //If grabAction from SteamVR and Raycast Collider hits left or right screen, set col obj as col
            if (grabAction.GetState(handType) && (col == leftVideoCube || col == rightVideoCube))
            {
                grabObject.SetCollidingObject(col);
            }
            //If triggerAction from SteamVR and Raycast Collider hits fastforwrad gameobject, fastforward
            else if (triggerAction.GetState(handType) && col == ff.gameObject)
            {
                ff.ff15s();
            }
            //If triggerAction from SteamVR and Raycast Collider hits PlayPause gameobject, Pause/Play
            else if (triggerAction.GetState(handType) && col == playBtn.gameObject)
            {
                playBtn.PlayPause();
            }
            //If menuHiderAction from SteamVR is pressed, hide menu and raycasts until another gameobj is hit
            else if (menuHiderAction.GetState(handType))
            {
                menu.HideMenu();
                raycastLaser.disableLaser();
            }
        }

    }
}
