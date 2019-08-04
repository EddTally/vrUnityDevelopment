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
    public Collider leftVideoCube, rightVideoCube, playCol, ffCol, ffMenu, ff15s, ff30s, ff1m;

    //Variables for Delays
    int count = 0;


    // Update is called once per frame
    void Update()
    {
        //Basically counting updates for delays on actions, disgusting but every other method was too bothersome
        if (count > 90)
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

                /* ----------------------------- PlayPause ---------------------------------- */
                //If triggerAction from SteamVR and Raycast Collider hits PlayPause collider, Pause/Play
                if (triggerAction.GetState(handType) && col == playCol)
                {
                    playCol.GetComponent<PlayPauseScript>().PlayPause();

                    count = 160;
                }

                /* ------------------------------- Fast Forward --------------------------------- */
                //If triggerAction and Raycast Collider hits fastforward collider, fastforward
                if (triggerAction.GetState(handType) && col == ffCol)
                {
                    if(videoUI.gameObject.GetComponent<FFmenuScript>().GetHighlightedChoice() == ff15s.gameObject)
                    {
                        ffCol.GetComponent<FastForwardScript>().FF15s();
                    }else if (videoUI.gameObject.GetComponent<FFmenuScript>().GetHighlightedChoice() == ff30s.gameObject)
                    {
                        ffCol.GetComponent<FastForwardScript>().FF30s();
                    }
                    else if (videoUI.gameObject.GetComponent<FFmenuScript>().GetHighlightedChoice() == ff1m.gameObject)
                    {
                        ffCol.GetComponent<FastForwardScript>().FF1m();
                    }
                    else if (videoUI.gameObject.GetComponent<FFmenuScript>().GetHighlightedChoice() == null)
                    {
                        ffCol.GetComponent<FastForwardScript>().FF15s();
                    }


                    count = 160;
                }

                //If triggerAction and Raycast Collider hits FFmenu collider, show ff15s, ff30s & ff1m gameobjects
                if (triggerAction.GetState(handType) && col == ffMenu)
                {
                    videoUI.gameObject.GetComponent<FFmenuScript>().ShowMenu();

                    count = 160;
                }
                //If triggerAction hits any of the Fast Forward Menu gameobjects it calls HighlightChoice method.
                if (triggerAction.GetState(handType) && (col == ff15s || col == ff30s || col == ff1m))
                {
                    videoUI.gameObject.GetComponent<FFmenuScript>().HighlightChoice(col.gameObject);

                    count = 160;
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

                count = 160;
            }
        }

    }

}
