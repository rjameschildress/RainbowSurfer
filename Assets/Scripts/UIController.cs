using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider TravelSlider;
    public Image Fill;
    private Color32[] _colors = {
        new Color32(255, 0, 0, 255),
        new Color32(255, 127, 0, 255),
        new Color32(255, 255, 0, 255),
        new Color32(0, 255, 0, 255),
        new Color32(0, 0, 255, 255),
        new Color32(75, 0, 130, 255),
        new Color32(148, 0, 211, 255)
    };

    public void UpdateTravelProgress(float progress)
    {
        if (progress != 1.0f)
        {
            int select = (int)(progress * 7);
            Fill.color = _colors[select];
            TravelSlider.value = progress;
        }
    }
}
