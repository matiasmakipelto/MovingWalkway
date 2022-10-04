using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SliderValueSaver : MonoBehaviour
{
    public static string path = "Assets/_OwnAssets/Scripts/sliderValue.txt";
    public TextAsset _textAsset;
    public static void saveValue(float value)
    {
        File.WriteAllText(path, value.ToString().Replace(',', '.'));
    }

    public static float loadValue()
    {
        return float.Parse(File.ReadAllText(path), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
    }
}
