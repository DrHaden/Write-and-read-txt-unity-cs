using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class Data_Receive_and_Display : MonoBehaviour
{
    string[] lines;
    string patientname = "My name";
    string datapath;

    DateTime[] readdate;
    DateTime currentdate = DateTime.Now;

    int[] pos1;
    int[] pos2;
    int[] pos3;
    int lognum;

    public Text all;




    void Start()
    {

        datapath = Application.dataPath + "/patientdata/" + patientname + ".txt";
        if (File.Exists(datapath)) { }
        else
        {
            Debug.Log("hahahahahahahahah");
            string[] setup = new string[1];
            setup[0] = "0";
            File.WriteAllLines(datapath, setup);
        }
        //--------------------------------------------
        lines = File.ReadAllLines(datapath);
        int.TryParse(lines[0], out lognum);
        //--------------------------------------------
        readdate = new DateTime[lognum];
        pos1 = new int[lognum];
        pos2 = new int[lognum];
        pos3 = new int[lognum];
    }




    public void addset()
    {
        lognum++;
        lines[0] = lognum.ToString();
        File.WriteAllLines(datapath, lines);
        using (StreamWriter file = new StreamWriter(datapath))
        {
            System.Random rnd = new System.Random();
            file.WriteLine(currentdate.ToString());
            file.WriteLine(rnd.Next(1, 100));
            file.WriteLine(rnd.Next(1, 100));
            file.WriteLine(rnd.Next(1, 100));
        }
    }




    public void loadset()
    {
        int i = 0;
        for (int m = 3; m < lognum * 4 - 3; m = m + 4)
        {
            DateTime.TryParse(lines[m], out readdate[i]);
            i++;
        }
        i = 0;
        //--------------------------------------------
        for (int m = 3; m < lognum * 4 - 2; m = m + 4)
        {

            int.TryParse(lines[m], out pos1[i]);
            i++;
        }
        i = 0;

        //--------------------------------------------
        for (int m = 3; m < lognum * 4 - 1; m = m + 4)
        {

            int.TryParse(lines[m], out pos2[i]);
            i++;
        }
        i = 0;

        //--------------------------------------------
        for (int m = 3; m < lognum * 4; m = m + 4)
        {

            int.TryParse(lines[m], out pos3[i]);
            i++;
        }
        //--------------------------------------------
        Debug.Log("Lognum: " + lognum);
        int log = this.lognum;
        for (int x = 0; x < lognum; x++)
        {
            Debug.Log("Lognum " + x + ": " + log);
            Debug.Log("date: " + x + ": " + readdate[i]);
            Debug.Log("pos1: " + x + ": " + pos1[i]);
            Debug.Log("pos2: " + x + ": " + pos2[i]);
            Debug.Log("pos3: " + x + ": " + pos3[i]);
            log--;
        }
    }



    void Update()
    {
        all.text = File.ReadAllText(datapath);
    }
}
