using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class BrushSetActive : MonoBehaviour
{
    public GameObject brush_white;
    public GameObject brush_red;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void white()
    {
        brush_white.SetActive(true);
        brush_red.SetActive(false);
    }
    public void red()
    {
        brush_white.SetActive(false);
        brush_red.SetActive(true);
    }
}
