using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    public Button first;
    public TextMeshProUGUI points;
    private int time = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime == time)
        {
            points.text = (int.Parse(points.text) + 1).ToString();
            time += 1;
        }
    }
    

}
