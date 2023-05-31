using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SensorData_pressure{
    public float reading0;
    public float reading1;
    public float reading2;
    public float reading3;
    public float reading4;
    public string deviceID="";

    public float sum(){
        return reading0+reading1+reading2+reading3+reading4;
    }

}


public class Posture : MonoBehaviour
{
    private float xb=0f;
    
    private float[] left_calibration = new float[5] { 0f, 0.05f, 0.05f, 0.05f, 0f };
    private float[] right_calibration = new float[5] { 0f, 0.04f, 0.04f, 0.04f, 0f };
    private SensorData_pressure data_left;
    private SensorData_pressure data_right;
    private float d=0.46f;
    private float h=1;

    public float get_xb() {
        return xb;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getData("1000");
    }

    float getData(string deviceID){
        string databaseUrl = "https://techin515-74d59-default-rtdb.firebaseio.com/";
        string dataPath = deviceID+".json";
        // Construct the URL to retrieve the data
        string url = databaseUrl + dataPath;
        float floatdata = 0;

        // Send the GET request
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        // Read the data from the response
        while (!www.isDone) { }
        if (www.result != UnityWebRequest.Result.Success)
        {
            // Handle the error
        }
        else
        {
            string data = www.downloadHandler.text;
            string stringdata = "";
            //stringdata=findData(data,jsonName);
            ParseJSON(data,deviceID);
            // print(stringdata);
            // floatdata=float.Parse(stringdata,NumberStyles.AllowLeadingSign);
            // Debug.Log("Retrieved data: " + data);
        }
        return floatdata;
    }


    private void ParseJSON(string json,string deviceID)
    {   
        
        if(deviceID=="10000000"){
            data_left = JsonUtility.FromJson<SensorData_pressure>(json);
    
            data_left.deviceID=deviceID;
            Calibration(ref data_left);
        }
        else{
            data_right = JsonUtility.FromJson<SensorData_pressure>(json);
    
            data_right.deviceID=deviceID;
            Calibration(ref data_right);
        }
        
        

        // Access the parsed data
        Debug.Log("reading0: " + data_right.reading0);
        // Debug.Log("reading1: " + data.reading1);
        // Debug.Log("reading2: " + data.reading2);
    }

    private void Calibration(ref SensorData_pressure data){
        float[] calibration;
        if (data.deviceID=="10000000"){
            calibration=left_calibration;
        }
        else{
            calibration=right_calibration;
        }
        data.reading0+=calibration[0];
        data.reading1+=calibration[1];
        data.reading2+=calibration[2];
        data.reading3+=calibration[3];
        data.reading4+=calibration[4];

    }

    public float dataAna(){
        float p1;
        float p2;
        float tanb=0;


        p1=data_left.sum();
        p2=data_right.sum();

        

        if (p1<0){
            p1=0;
        }
        if (p2<0){
            p2=0;
        }
        if ((p1<0.06 || p2<0.06) && (Math.Abs(p1-p2)<0.06)){
            xb=d / 2;
        }
        else {
            tanb = (p1 + p2) * h / (d * p1);
            xb = h / tanb;
        }
        print(xb);
        return xb;

    }

    string findData(string data,string dataName){
        string[] dataArr = data.Split('\"');
        string targetData = "";
        // foreach (string s in dataArr){
        //     print(s);
        // }
        for (int i=0;i<dataArr.Length;i++){
            // print(dataArr[i]);
            // print(i);
            if (dataArr[i].Contains(dataName)){
                targetData = dataArr[i + 4];
                // print("find!!!!!!!");
                print(targetData);
            }

        }
        return targetData;

    }
}
