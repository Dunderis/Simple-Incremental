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
    public Button fifth;
    public TextMeshProUGUI points;
    public double secretPoints;
    public double pointsChange;
    public TextMeshProUGUI Cps;
    private double ps;
    public GameObject secondu;
    public GameObject thirdu;
    public GameObject fourthu;
    public GameObject fifthu;
    public GameObject Cpsu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        secretPoints = 1;
        secretPoints = double.Parse(PlayerPrefs.GetString("SecretPoints", "1"));
        first.GetComponent<First>().bought = bool.Parse(PlayerPrefs.GetString("Eins", "false"));
        second.GetComponent<Second>().bought = bool.Parse(PlayerPrefs.GetString("Zwei", "false"));
        third.GetComponent<Third>().bought = bool.Parse(PlayerPrefs.GetString("Drei", "false"));
        fourth.GetComponent<Fourth>().bought = bool.Parse(PlayerPrefs.GetString("Vier", "false"));
        fifth.GetComponent<Fifth>().bought = bool.Parse(PlayerPrefs.GetString("Funf", "false"));
        fourth.GetComponent<Fourth>().buying = int.Parse(PlayerPrefs.GetString("Buying", "0"));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first.GetComponent<First>().bought == true)
        {
            gen = 1;
            secondu.SetActive(true);
            Cpsu.SetActive(true);
        }
        if(second.GetComponent<Second>().bought == true)
        {
            multi = 2;
            preMulti = multi;
            thirdu.SetActive(true);
        }
        if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 4;
            fourthu.SetActive(true);
            fifthu.SetActive(true);
        }
        if(fifth.GetComponent<Fifth>().bought == true)
        {
            
            preMulti = 4;
        }
        if (fourth.GetComponent<Fourth>().bought == true && secretPoints >= 1)
        {
            double add;
            int minus = fourth.GetComponent<Fourth>().buying *5;
            int divider = 100;
            add = secretPoints / (divider-minus);
            multi = preMulti + add;
            
        
        }
        
        final = multi * gen;
        ps = final/genSpeed;
        Cps.text = (final/genSpeed).ToString("F1") + " p/s";
        Convert(secretPoints);
        if (secretPoints >= 1000)
        {
            points.text = pointsChange.ToString("F2") + "K";
        }
        else
        {
            points.text = secretPoints.ToString("F1");
        }
        print(secretPoints);
    }

    void StartGen()
    {
        if (first.GetComponent<First>().bought == true && second.GetComponent<Second>().bought == false)
        {
            final = gen;
        }
            secretPoints += ps;



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
            InvokeRepeating("StartGen", 0, 1);
        }
        else if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 4;
            CancelInvoke("StartGen");
            InvokeRepeating("StartGen",0,1);
            
        }

    }
    private void OnApplicationQuit() 
    {
        Save();
    }
    public void Save()
    {
        string points = secretPoints.ToString("F1");
        string eins = first.GetComponent<First>().bought.ToString();
        string zwei = second.GetComponent<Second>().bought.ToString();
        string drei = third.GetComponent<Third>().bought.ToString();
        string vier = fourth.GetComponent<Fourth>().bought.ToString();
        string funf = fifth.GetComponent<Fifth>().bought.ToString();
        PlayerPrefs.SetString("SecretPoints", points);
        PlayerPrefs.SetString("Eins", eins);
        PlayerPrefs.SetString("Zwei", zwei);
        PlayerPrefs.SetString("Drei", drei);
        PlayerPrefs.SetString("Vier", vier);
        PlayerPrefs.SetString("Funf", funf);
        PlayerPrefs.SetInt("Buying",fourth.GetComponent<Fourth>().buying );
        PlayerPrefs.Save();
    }
    

}
