using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class Data_Receive_and_Display : MonoBehaviour {
    string filepath;
    string patientname = "Hayden";
    string readdate;

    int[] pos = {22,55,3};
    int[] readpos = new int[3];
    int lognum;

    public Text all;
    

    void Start ()
    {
        string datapath =  Application.dataPath + "/patientdata/" + patientname;
        Debug.Log(datapath);
        string[] lines = File.ReadAllLines(datapath);
        Debug.Log (File.ReadAllText(datapath));
        int.TryParse(lines[0], out lognum);
        lognum++;
        lines[0] = lognum.ToString();
            lines[lognum * 4 - 3] = (DateTime.Now.ToString());
            lines[lognum * 4 - 2] = (pos[0]).ToString();
            lines[lognum * 4 - 2] = (pos[1]).ToString();
            lines[lognum * 4] = (pos[2]).ToString();
        File.WriteAllLines(datapath, lines);
        //______________________________________________
        for (int m = lognum; m >= 1; m--)
        {
            readdate = (lines[m * 4 - 3].ToString());
            int.TryParse(lines[m * 4 - 2] , out readpos[0]);
            int.TryParse(lines[m * 4 - 1], out readpos[1]);
            int.TryParse(lines[m * 4], out readpos[2]);
            
            Debug.Log("Lognum: " + lognum);
            Debug.Log("date: " + readdate);
            Debug.Log("pos1: " + readpos[0]);
            Debug.Log("pos2: " + readpos[1]);
            Debug.Log("pos3: " + readpos[2]);

        }
        all.text = File.ReadAllText(datapath);
    }
}
