using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DragObjectAttempt1 : MonoBehaviour
{
    /* www.patreon.com/posts/unity-3d-drag-22917454 */

    public LaserRaycast laserRaycast;
    private Vector3 mOffset;

    public void DragObject(GameObject obj)
    {
        // Store offset = gameobject world pos - mouse world pos
        mOffset = obj.transform.position - laserRaycast.GetHitpoint();

        // Debug.Log(obj.transform.position + " " + laserRaycast.GetHitpoint());

        //obj.transform.position = laserRaycast.GetHitpoint() + mOffset;
        obj.transform.position = laserRaycast.GetHitpoint() + mOffset;

        Debug.Log(mOffset);

    }
}
