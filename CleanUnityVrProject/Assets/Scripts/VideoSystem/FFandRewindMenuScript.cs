using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFandRewindMenuScript : MonoBehaviour
{

    public GameObject ff15s, ff30s, ff1m, rewind15s, rewind30s, rewind1m;
    private GameObject highlightedFFGameObject = null, highlightedRewindGameObject = null;

    //ff kept infront of the material names because thats what they were named in the Textures and Materials folder, 
    // and because you cannot start variable names with numbers :)
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
            rewind15s.SetActive(true);
            rewind30s.SetActive(true);
            rewind1m.SetActive(true);

        }
        else
        {
            ff15s.SetActive(false);
            ff30s.SetActive(false);
            ff1m.SetActive(false);
            rewind15s.SetActive(false);
            rewind30s.SetActive(false);
            rewind1m.SetActive(false);
        }
    }

    public void HighlightFFChoice(GameObject g)
    {
        if(g == ff15s)
        {
            ff15s.GetComponent<Renderer>().material = ff15sHighlightedMat;
            ff30s.GetComponent<Renderer>().material = ff30sMat;
            ff1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedFFGameObject = ff15s;
        }else if(g == ff30s)
        {
            ff15s.GetComponent<Renderer>().material = ff15sMat;
            ff30s.GetComponent<Renderer>().material = ff30sHighlightedMat;
            ff1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedFFGameObject = ff30s;
        }
        else if (g == ff1m)
        {
            ff15s.GetComponent<Renderer>().material = ff15sMat;
            ff30s.GetComponent<Renderer>().material = ff30sMat;
            ff1m.GetComponent<Renderer>().material = ff1mHighlightedMat;
            highlightedFFGameObject = ff1m;
        }
    }
    public void HighlightRewindChoice(GameObject g)
    {
        if (g == rewind15s)
        {
            rewind15s.GetComponent<Renderer>().material = ff15sHighlightedMat;
            rewind30s.GetComponent<Renderer>().material = ff30sMat;
            rewind1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedRewindGameObject = ff15s;
        }
        else if (g == rewind30s)
        {
            rewind15s.GetComponent<Renderer>().material = ff15sMat;
            rewind30s.GetComponent<Renderer>().material = ff30sHighlightedMat;
            rewind1m.GetComponent<Renderer>().material = ff1mMat;
            highlightedRewindGameObject = ff30s;
        }
        else if (g == rewind1m)
        {
            rewind15s.GetComponent<Renderer>().material = ff15sMat;
            rewind30s.GetComponent<Renderer>().material = ff30sMat;
            rewind1m.GetComponent<Renderer>().material = ff1mHighlightedMat;
            highlightedRewindGameObject = ff1m;
        }
    }

    public GameObject GetHighlightedFFChoice()
    {
        return highlightedFFGameObject;
    }
    public GameObject GetHighlightedRewindChoice()
    {
        return highlightedRewindGameObject;
    }
}
