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

    public LaserRaycast laserRaycast;
    public GameObject videoUI;
    public Collider leftVideoCube, rightVideoCube, playCol, ffCol, ffMenu;

    //Variables for Delays
    int count = 0;



    // Update is called once per frame
    void Update()
    {
        //Basically counting updates for delays on actions, disgusting but every other method was too bothersome
        if (count > 100)
        {
            count--;
        }
        else
        {



            Collider col = null;
            col = this.GetComponent<LaserRaycast>().GetColliderHit();
            if (col != null) //Don't have to go through the whole loop if its null, saves time
            {
                //If grabAction from SteamVR and Raycast Collider hits left or right screen, move object.
                if (grabAction.GetState(handType) && (col == leftVideoCube || col == rightVideoCube))
                {
                    laserRaycast.moveObject(col);
                }

                //If triggerAction from SteamVR and Raycast Collider hits fastforward collider, fastforward
                if (triggerAction.GetState(handType) && col == ffCol)
                {
                    ffCol.GetComponent<FastForwardScript>().ff15s();


                    count = 200;
                }

                //If triggerAction from SteamVR and Raycast Collider hits PlayPause collider, Pause/Play
                if (triggerAction.GetState(handType) && col == playCol)
                {
                    playCol.GetComponent<PlayPauseScript>().PlayPause();


                    count = 200;
                }

                //If triggerAction from SteamVR and Raycast Collider hits FFmenu collider, show ff15s, ff30s & ff1m gameobjects
                if(triggerAction.GetState(handType) && col == ffMenu)
                {
                    videoUI.gameObject.GetComponent<FFmenuScript>().ShowMenu();

                    count = 200;
                }

                //Refreshing raycast collider so when raycast is no longer over an object it is null, this is important
                // as it stops functions from being activated when they aren't being pointed to.
                this.GetComponent<LaserRaycast>().SetColliderHit(null);
            }

            //If menuHiderAction from SteamVR is pressed, hide menu and raycasts until another gameobj is hit
            //Outside the Col != null statement because this doesn't need to interact with a collider to work.
            if (menuHiderAction.GetState(handType))
            {
                videoUI.gameObject.GetComponent<HideMenuScript>().HideMenu();


                count = 200;
            }
        }

    }

}
