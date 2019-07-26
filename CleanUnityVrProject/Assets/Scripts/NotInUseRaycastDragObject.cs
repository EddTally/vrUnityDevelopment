using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDragTest : MonoBehaviour {
    //www.youtube.com/watch?v=d7Z7Re5qeWc
    private RaycastHit rayHit;
    private GameObject collideObj;
    private float distance;
    private Vector3 posObj;
    private bool lockObj;
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var hit = Physics.Raycast(ray.origin, ray.direction, out rayHit);
            if (hit && !lockObj)
            {
                collideObj = rayHit.collider.gameObject;
                distance = rayHit.distance;
                Debug.Log(collideObj.name);
            }
            lockObj = true;
            posObj = ray.origin + distance * ray.direction;
            collideObj.transform.position = new Vector3(posObj.x, posObj.y, posObj.z);
        }
        else{
            lockObj = false;
        }
	}
}
