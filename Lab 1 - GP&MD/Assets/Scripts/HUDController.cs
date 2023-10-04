using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HUDController : MonoBehaviour
{
    public static int deaths = 0;
    public TextMeshProUGUI countText;

    private bool shotgun = true;
    private bool autogun = false;
    public TextMeshProUGUI weaponHeld;

    void Start()
    {

    }

    void Update()
    {
        countText.text = "Enemies Killed: " + deaths.ToString();

        if (Input.GetMouseButton(0))
        {
            if (shotgun)
            {
                shotgun = false;
                autogun = true;
            }
            else if (!shotgun)
            {
                shotgun = true;
                autogun = false;
            }
        }

        if (shotgun)
        {
            weaponHeld.text = "Current Weapon: Shotgun";
        }
        if (autogun)
        {
            weaponHeld.text = "Current Weapon: Autogun";
        }
    }
}
