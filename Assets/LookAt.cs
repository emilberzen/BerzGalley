using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;


public class LookAt : MonoBehaviour
{
    private float StartTime;
    //public TextMeshPro artistText;
    private TextMeshPro ArtText;
    [SerializeField]
    public GameObject[] ArtWorks;
    bool fadeIn;
    // Start is called before the first frame update
    void Start()
    {
       // artistText.GetComponent<GameObject>();
        StartTime = Time.deltaTime;



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float CurrentTime =0; 
        RaycastHit hit;
        string hitName;
        var cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane));
        if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 20))
        {

            CurrentTime = Time.deltaTime - StartTime;
            GameObject obj = hit.transform.gameObject;
           
            


            for (int i = 0; i < ArtWorks.Length; i++)
            {
                if (obj.name == ArtWorks[i].name && !fadeIn)
                {
                    ArtText = obj.GetComponentInChildren<TextMeshPro>();
                    ArtText.DOFade(1, 0.5f);
                    fadeIn = true;
                    Debug.Log(obj.name);
                }

            }


        }
        else
        {
            if (fadeIn)
            {

                Debug.Log(ArtText);
                fadeIn = false;
                ArtText.DOFade(0, 0.5f);
                
            }

        }


    }


}
