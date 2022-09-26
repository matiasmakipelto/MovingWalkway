using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public GameObject pauseMenu;

    private void Start()
    {
        GetComponent<Slider>().value = SliderValueSaver.loadValue();

        pauseMenu.SetActive(false);
    }

    public void ChangeVelocityText(float value)
    {
        string velocity = value.ToString();
        if (velocity.Length > 4)
        {
            velocity = (Mathf.Round(value * 100f) * 0.01f).ToString();
        }

        text.text = velocity + " m/s";
    }
}
