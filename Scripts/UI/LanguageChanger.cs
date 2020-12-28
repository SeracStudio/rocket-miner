using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour
{

    public string TextID;
    public Text text;

    private string path;
    private Dictionary<string, string> jsonChanger;
    public TextAsset language;

    // Start is called before the first frame update
    void Awake()
    {
        jsonChanger = new Dictionary<string, string>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadJson(TextAsset json)
    {
        JSONarray jSONarray = JsonUtility.FromJson<JSONarray>(json.text);
        foreach(JSONpair jSONpair in jSONarray.Idioma)
        {
            jsonChanger.Add(jSONpair.id, jSONpair.content);
        }
    }

    public void ChangeJSON()
    {
        LoadJson(language);
        text.text = jsonChanger[TextID];
    }



[System.Serializable]
private class JSONpair
    {
        public string id;
        public string content;


    }

    private class JSONarray
    {
        public JSONpair[] Idioma;
    }


}