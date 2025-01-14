using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    private double multi = 1;
    double preMulti;
    private int gen = 0;
    private float genSpeed = 5;
    private double final;
    public Button first;
    public Button second;
    public Button third;
    public Button fourth;
    public TextMeshProUGUI points;
    public double secretPoints;
    public double pointsChange;
    public TextMeshProUGUI Cps;
    
    
    // Start is called before the first frame update
    void Start()
    {
        secretPoints = 1;
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
            preMulti = multi;
        }
        if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 1;
        }
        if (fourth.GetComponent<Fourth>().bought == true && secretPoints >= 1)
        {
            double add;
            int divider = 100;
            add = secretPoints / divider;
            multi = preMulti + add;
            
        
        }
        final = multi * gen;
        Cps.text = (final/genSpeed).ToString("F1") + " p/s";
        Convert(secretPoints);
        if (secretPoints >= 1000)
        {
            points.text = pointsChange.ToString("F2") + "K";
        }
        else
        {
            points.text = secretPoints.ToString();
        }
        print(secretPoints);
    }

    void StartGen()
    {
        if (first.GetComponent<First>().bought == true && second.GetComponent<Second>().bought == false)
        {
            final = gen;
        }
            secretPoints += final;



    }

    void Convert(double seconds)
    {
        if (seconds >=1000 )
        {
            pointsChange = seconds / 1000;
        }
    }

    public void Repeat()
    {
        if (first.GetComponent<First>().bought == true && third.GetComponent<Third>().bought == false)
        {
            InvokeRepeating("StartGen", 0, genSpeed);
        }
        else if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 4;
            CancelInvoke("StartGen");
            InvokeRepeating("StartGen",0,genSpeed);
            
        }

    }
    

}
