using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour
{

    public List<string> TextID;
    public List<Text> texts;
    public List<Text> textsExit;
    public TextAsset language;

    private string path;
    private Dictionary<string, string> jsonChanger;
    private bool SpanishAdded = false;
    private bool EnglishAdded = false;

    // Start is called before the first frame update
    void Awake()
    {
        jsonChanger = new Dictionary<string, string>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadJsonEng(TextAsset json)
    {
        if (!EnglishAdded) { 
            JSONarray jSONarray = JsonUtility.FromJson<JSONarray>(json.text);
            foreach(JSONpair jSONpair in jSONarray.Idioma)
            {
                jsonChanger.Add(jSONpair.id, jSONpair.content);
            }
            EnglishAdded = true;
        }
    }

    public void LoadJsonSpa(TextAsset json)
    {
        if (!SpanishAdded) { 
            JSONarray jSONarray = JsonUtility.FromJson<JSONarray>(json.text);
            foreach (JSONpair jSONpair in jSONarray.Idioma)
            {
                jsonChanger.Add(jSONpair.id, jSONpair.content);
            }
            SpanishAdded = true;
        }
    }

    public void ChangeJSON()
    {
        for (int i = 0; i < texts.Count; i++) {
                texts[i].text = jsonChanger[TextID[i]];
        }

        for(int i=0; i < textsExit.Count; i++)
        {
            textsExit[i].text = jsonChanger[TextID[jsonChanger.Count-1]];
        }
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