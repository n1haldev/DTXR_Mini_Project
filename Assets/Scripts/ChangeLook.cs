using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChangeLook : MonoBehaviour
{
    public GameObject target;
    public GameObject planetInfoPanel;

    void OnMouseDown()
    {
        LookAt.target = target;
        Camera.main.fieldOfView = Mathf.Clamp(60 * target.transform.localScale.x, 1, 100);
        ShowPlanetInfo();
    }

    void ShowPlanetInfo()
    {
        if (planetInfoPanel != null)
        {
            planetInfoPanel.SetActive(true);
            PlanetInfoPanel planetInfo = planetInfoPanel.GetComponent<PlanetInfoPanel>();
            if (planetInfo != null)
            {
                string planetName = target.name;
                string filePath = Path.Combine(Application.dataPath, "PlanetInfo", planetName + ".txt");
                if (File.Exists(filePath))
                {
                    string planetInfoText = File.ReadAllText(filePath);
                    planetInfo.DisplayPlanetInfo(planetInfoText);
                }
                else
                {
                    Debug.LogWarning("No information found for planet: " + planetName);
                }
            }
        }
    }
}
