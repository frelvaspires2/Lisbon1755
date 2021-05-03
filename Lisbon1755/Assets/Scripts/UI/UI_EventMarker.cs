using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EventMarker : MonoBehaviour
{
    [SerializeField]
    private Markers[] markers;

    void Update()
    {
        UpdateMarkers();
    }

    private void UpdateMarkers()
    {
        float minX = 0;
        float maxX = 0;

        float minY = 0;
        float maxY = 0;

        Vector2 pos = default;

        foreach(Markers item in markers)
        {
            minX = item.GetSetImg.GetPixelAdjustedRect().width / 2;
            maxX = Screen.width - minX;

            minY = item.GetSetImg.GetPixelAdjustedRect().height / 2;
            maxY = Screen.height - minY;

            pos = Camera.main.WorldToScreenPoint(item.GetSetTarget.position + item.GetSetOffset);

            if (Vector3.Dot((item.GetSetTarget.position - transform.position), transform.forward) < 0)
            {
                //Target is behind the player
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            item.GetSetImg.transform.position = pos;
            item.GetSetMeter.text = ((int)Vector3.Distance(item.GetSetTarget.position, transform.position)).ToString() + "m";
        }
    }
}
