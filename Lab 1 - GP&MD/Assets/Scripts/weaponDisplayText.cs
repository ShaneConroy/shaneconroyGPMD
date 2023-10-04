using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class weaponDisplayText : MonoBehaviour
{

    private bool shotgun = true;
    private bool autogun = false;
    public TextMeshProUGUI weaponHeld;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
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

        if (shotgun) // Shotgun code
        {
            weaponHeld.text = "Current Weapon: Shotgun";
        }
        if (autogun)
        {
            weaponHeld.text = "Current Weapon: Autogun";
        }
    }
}
