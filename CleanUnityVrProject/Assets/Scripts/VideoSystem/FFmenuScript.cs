using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFmenuScript : MonoBehaviour
{

    public GameObject ff15s, ff30s, ff1m, highlightedGameObject = null;
    public Material ff15sMat, ff15sHighlightedMat, ff30sMat, ff30sHighlightedMat, ff1mMat, ff1mHighlightedMat;

    private void Start()
    {
        ff15s.GetComponent<Renderer>().material = ff15sHighlightedMat;
    }

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

    public void HighlightChoice(GameObject g)
    {
        if(g == ff15s)
        {
            ff15s.GetComponent<Renderer>().material = ff15sHighlightedMat;
            ff30s.GetComponent<Renderer>().material = ff30sMat;
            ff1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedGameObject = ff15s;
        }else if(g == ff30s)
        {
            ff15s.GetComponent<Renderer>().material = ff15sMat;
            ff30s.GetComponent<Renderer>().material = ff30sHighlightedMat;
            ff1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedGameObject = ff30s;
        }
        else if (g == ff1m)
        {
            ff15s.GetComponent<Renderer>().material = ff15sMat;
            ff30s.GetComponent<Renderer>().material = ff30sMat;
            ff1m.GetComponent<Renderer>().material = ff1mHighlightedMat;
            highlightedGameObject = ff1m;
        }
    }

    public GameObject GetHighlightedChoice()
    {
        return highlightedGameObject;
    }
}
