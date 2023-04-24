using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] UIPanels;


    public void Start()
    {
        
    }


    public void OpenPanel(GameObject openingPanel)
    {
        CloseAllPanels();

        foreach (GameObject panel in UIPanels)
        {
            if (panel == openingPanel)
            {
                panel.SetActive(true);
            }
        }
    }

    public void CloseAllPanels()
    {
        foreach (GameObject panel in UIPanels)
        {
            panel.SetActive(false);
        }
    }
}
