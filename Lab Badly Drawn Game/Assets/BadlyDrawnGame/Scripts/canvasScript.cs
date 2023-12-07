using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    private Text studentsAlive_Text;
    void Update()
    {
        studentsAlive_Text.text = gamemanager.students.ToString();
    }
}
