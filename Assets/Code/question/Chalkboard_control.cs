using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Chalkboard_control : MonoBehaviour
{
    /*
    //畫不出線
    [SerializeField] GameObject pencil;

    public bool isPress;

    List<GameObject> pencils = new List<GameObject>(0);


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            isPress = true;
            pencils.Add(Instantiate(pencil, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.Euler(Vector3.zero), this.transform));
        }
        if (isPress)
        {
            pencils[pencils.Count - 1].transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))   //Esc
        {
            clearAllPencils();
        }
    }

    void clearAllPencils()
    {
        for(int i = 0; i < pencils.Count; i++)
        {
            Destroy(pencils[i]);
        }
        pencils.Clear();
    }
    */

    
    //擦不掉筆跡
    public Camera m_camera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    void Update()
    {
        Draw();
    }

    void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLineRenderer = null;
        }

        
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void Eraser()
    {
        //currentLineRenderer.positionCount = 0;
        currentLineRenderer.SetPosition(0, Vector2.zero);
        currentLineRenderer.SetPosition(1, Vector2.zero);
    }
    
}
