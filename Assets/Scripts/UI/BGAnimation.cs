using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimation : MonoBehaviour
{
    public float rotationRate = 1;
    public RectTransform imgTransform;

    void Update()
    {
        imgTransform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationRate));
    }
}
