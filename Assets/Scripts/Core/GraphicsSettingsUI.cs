using TMPro;
using UnityEngine;

public class GraphicsSettingsUI : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.onValueChanged
            .AddListener(SetQuality);

        dropdown.value =
            QualitySettings.GetQualityLevel();

        dropdown.RefreshShownValue();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(
            qualityIndex
        );
    }
}
