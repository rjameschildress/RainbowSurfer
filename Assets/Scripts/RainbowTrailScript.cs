using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTrailScript : MonoBehaviour
{
    private TrailRenderer _rainbowTrail;
    private float _colorSwitchTime = 0.5f;
    private float _widthSwitchTime = 0.05f;
    private Color[] _colors = {
        new Color(255, 0, 0),
        new Color(255, 127, 0),
        new Color(255, 255, 0),
        new Color(0, 255, 0),
        new Color(0, 0, 255),
        new Color(75, 0, 130),
        new Color(148, 0, 211)
    };
    private int _colorIterator;
    private float _trailStartWidth;
    private float _trailEndWidth;
    private bool _decreaseWidth;

    // Start is called before the first frame update
    void Start()
    {
        _rainbowTrail = GetComponent<TrailRenderer>();
        _colorIterator = 0;
        _trailStartWidth = 0.1f;
        _trailEndWidth = 0.01f;
        _decreaseWidth = true;
        InvokeRepeating("ChangeColor", 0.1f, _colorSwitchTime);
        InvokeRepeating("ChangeWidth", 0.1f, _widthSwitchTime);
    }

    private void ChangeColor()
    {
        _colorIterator = _colorIterator == 6 ? 0 : _colorIterator + 1;
        _rainbowTrail.startColor = _colors[_colorIterator];
        _rainbowTrail.endColor = _colors[_colorIterator];
    }

    private void ChangeWidth()
    {
        _trailStartWidth = _decreaseWidth ? _trailStartWidth - 0.01f : _trailStartWidth + 0.01f;
        _trailEndWidth = _decreaseWidth ? _trailEndWidth + 0.01f : _trailEndWidth - 0.01f;
        if (_trailStartWidth <= 0.01f)
        {
            _decreaseWidth = false;
        }
        else if (_trailStartWidth >= 0.1f)
        {
            _decreaseWidth = true;
        }

        _rainbowTrail.startWidth = _trailStartWidth;
        _rainbowTrail.endWidth = _trailEndWidth;
    }
}
