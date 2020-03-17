using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressSliderLogic : MonoBehaviour
{
    public GameObject player;
    public Slider slider;

    private void Update()
    {
        slider.value = player.transform.position.z;
    }
}
