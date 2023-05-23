using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ProgressBar : MonoBehaviour
{
    public Image fillerBar;

    public void SetProgress(float progress)
    {
        fillerBar.fillAmount = progress;
    }
}
