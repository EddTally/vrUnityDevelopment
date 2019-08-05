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
    public Collider leftVideoCube, rightVideoCube, playCol, ffCol, ffMenu, ff15s, ff30s, ff1m, 
        rewindCol, rewind15s, rewind30s, rewind1m;

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
                    if(videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedFFChoice() == ff15s.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().FF15s();
                    }else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedFFChoice() == ff30s.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().FF30s();
                    }
                    else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedFFChoice() == ff1m.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().FF1m();
                    }
                    else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedFFChoice() == null)
                    {
                        ffCol.GetComponent<FFandRewindScript>().FF15s();
                    }


                    count = 160;
                }
                /* ------------------------------------- Rewind ------------------------------------ */
                //If triggerAction and Raycast Collider hits fastforward collider, fastforward
                if (triggerAction.GetState(handType) && col == rewindCol)
                {
                    if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedRewindChoice() == ff15s.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().Rewind15s();
                    }
                    else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedRewindChoice() == ff30s.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().Rewind30s();
                    }
                    else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedRewindChoice() == ff1m.gameObject)
                    {
                        ffCol.GetComponent<FFandRewindScript>().Rewind1m();
                    }
                    else if (videoUI.gameObject.GetComponent<FFandRewindMenuScript>().GetHighlightedRewindChoice() == null)
                    {
                        ffCol.GetComponent<FFandRewindScript>().Rewind15s();
                    }


                    count = 160;
                }

                //If triggerAction and Raycast Collider hits FFmenu collider, show ff15s, ff30s & ff1m gameobjects
                if (triggerAction.GetState(handType) && col == ffMenu)
                {
                    videoUI.gameObject.GetComponent<FFandRewindMenuScript>().ShowMenu();

                    count = 160;
                }
                //The two if statements below don't have to be kept apart but it makes for easier reading.
                //If triggerAction hits any of the Fast Forward Menu gameobjects it calls HighlightChoice method.
                if (triggerAction.GetState(handType) && (col == ff15s || col == ff30s || col == ff1m))
                {
                    videoUI.gameObject.GetComponent<FFandRewindMenuScript>().HighlightFFChoice(col.gameObject);

                    count = 160;
                }
                //If triggerAction hits any of the Rewind Menu gameobjects it calls HighlightChoice method.
                if (triggerAction.GetState(handType) && (col == rewind15s || col == rewind30s || col == rewind1m))
                {
                    videoUI.gameObject.GetComponent<FFandRewindMenuScript>().HighlightRewindChoice(col.gameObject);

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
