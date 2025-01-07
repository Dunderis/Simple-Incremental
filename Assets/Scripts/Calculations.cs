using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    private float multi;
    private int gen = 0;
    private float final;
    public Button first;
    public Button second;
    public Button third;
    public TextMeshProUGUI points;
    public TextMeshProUGUI thridUpgrade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first.GetComponent<First>().bought == true)
        {
            gen = 1;
        }
        if(second.GetComponent<Second>().bought == true)
        {
            multi = 2;
        }
        if(third.GetComponent<Third>().bought == true && (int.Parse(points.text) >= 1))
        {
            multi += (int.Parse(points.text)/100);
            thridUpgrade.text = "x" +(1+(int.Parse(points.text)/100)).ToString("F2");
        }
        final = multi * gen;
    }

    void StartGen()
    {
        if (first.GetComponent<First>().bought == true && second.GetComponent<Second>().bought == false)
        {
            final = gen;
        }
       
            points.text =  (int.Parse(points.text)+final).ToString();
            print(final);
        
    }

    public void Repeat()
    {
        if (first.GetComponent<First>().bought == true)
        {
            InvokeRepeating("StartGen", 0, 1);
        }
    }
    

}
