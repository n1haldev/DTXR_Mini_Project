using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoPanel : MonoBehaviour
{
    public Text planetInfoText;

    public void DisplayPlanetInfo(string info)
    {
        planetInfoText.text = info;
    }
}
