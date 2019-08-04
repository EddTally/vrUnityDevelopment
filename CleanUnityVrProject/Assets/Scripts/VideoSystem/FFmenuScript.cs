using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFmenuScript : MonoBehaviour
{

    public GameObject ff15s, ff30s, ff1m;

    public void ShowMenu()
    {
        if(ff15s.activeSelf == false)
        {
            ff15s.SetActive(true);
            ff30s.SetActive(true);
            ff1m.SetActive(true);

        }
        else
        {
            ff15s.SetActive(false);
            ff30s.SetActive(false);
            ff1m.SetActive(false);
        }
    }
}
