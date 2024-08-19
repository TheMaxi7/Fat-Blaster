using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatIndicator : MonoBehaviour
{
    public GameObject fatbar;
    private Vector2 parentSize;
    private Vector2 indicatorSize;
    private float maxPos;
    void Start()
    {
        parentSize = fatbar.GetComponentInParent<RectTransform>().sizeDelta;
        indicatorSize = GetComponent<RectTransform>().sizeDelta;
        maxPos = parentSize.x - indicatorSize.x;
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
    }

    void Update()
    {
        var fatLevel = PlayerManager.instance.playerFat / 300;
        var indicatorPos = (fatLevel * maxPos) - maxPos / 2;
        Debug.Log(indicatorPos);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(indicatorPos, GetComponent<RectTransform>().anchoredPosition.y);
    }
}
