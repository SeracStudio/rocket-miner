using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    //Para german
    public BaseItem item;

    //Para mi
    public string description;
    public float timeGiven;
    public Sprite imageBG;
    public Sprite image;

    public Canvas canvas;

    public Animator animation;
    public RectTransform popup;
    private RectTransform gameInstance;
    private bool isActive = false;
    private float timePassed = 0.0f;
    private Image itemImage;
    private TextMeshProUGUI descriptionText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timePassed += Time.deltaTime;
            if(timePassed>= timeGiven)
            {
                animation.SetTrigger("Close");
                StartCoroutine(WaitTime());
                isActive = false;
            }
        }
        
    }

    public void showMessage() {
        gameInstance = Instantiate(popup, new Vector3(-112.0f, 61.0f, 0.0f), Quaternion.identity);
        gameInstance.transform.SetParent(canvas.transform, false);
       
        itemImage = gameInstance.Find("Image_Item").GetComponent<Image>();
        descriptionText = gameInstance.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        //Debug.Log(descriptionText);
        
        //Animation part
        animation = gameInstance.GetComponent<Animator>();
        animation.SetTrigger("Pop");

        //Para mi
        gameInstance.GetComponentInChildren<Image>().sprite = imageBG;
        itemImage.sprite = image;
        descriptionText.text = description;

        //Para germán
        /*
        gameInstance.GetComponentInChildren<Image>().sprite = item.itemName;
        descriptionText.text = item.itemDescription;
        itemImage.sprite = item.itemImage;
        gameInstance.GetComponentInChildren<Image>().sprite = item.backgroundImage;*/

        isActive = true;
    }
    IEnumerator WaitTime()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeGiven);
        Destroy(gameInstance.gameObject);
    }

}
