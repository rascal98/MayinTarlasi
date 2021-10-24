using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class cube : MonoBehaviour
{
    private bool canRotate = false, otherCanRotate = false;
    List<Collider> otherColliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BoxColliderEnable());
    }

    // Update is called once per frame
    void Update()
    {
        //İLK BASILDIĞINDA MAYINA DENK GELİRSE SOL ÜST KÖŞEYE AT
        if (canRotate)
        {
            RotateCube();
        }
        if (otherCanRotate)
        {
            OtherRotation();
            Invoke("ClearList", 1f);
        }
        otherCanRotate = false;
    }
    /// <summary>
    /// Collider'ların değdiği gameObjelerin döndürülmesini sağlar
    /// </summary>
    void OtherRotation()
    {
        foreach (var item in otherColliders)
        {
            if (item.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == "0" && item.gameObject.transform.rotation.x < 90)
            {
                RotateCube(item.gameObject);
                item.gameObject.GetComponent<cube>().otherCanRotate = true;
            }
        }
    }
    /// <summary>
    /// Collider listesini invoke metoduyla silinmesi için yazıldı.
    /// </summary>
    void ClearList()
    {
        otherColliders.Clear();
    }
    IEnumerator BoxColliderEnable()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void CubeClickListener()
    {
        canRotate = true;

        int cubeNumber = int.Parse(gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text);
        ChangeColor(cubeNumber);
        foreach (var item in otherColliders)
        {
            if (item.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == "0" && gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == "0")
            {
                otherCanRotate = true;
            }
        }
    }
    /// <summary>
    /// Küp döndürme fonksiyonu
    /// </summary>
    void RotateCube()
    {
        float degrees = 90;
        Vector3 to = new Vector3(degrees, 0, 0);
        gameObject.transform.eulerAngles =
            Vector3.MoveTowards(transform.rotation.eulerAngles, to, 1f);
    }
    /// <summary>
    /// Küp döndürme fonksiyonu
    /// </summary>
    void RotateCube(GameObject otherGameObject)
    {
        float degrees = 90;
        Vector3 to = new Vector3(degrees, 0, 0);
        otherGameObject.transform.eulerAngles =
            Vector3.MoveTowards(transform.rotation.eulerAngles, to, 1f);
    }
    /// <summary>
    /// Kübün rengini değiştirme 1 - 8 arası
    /// </summary>
    /// <param name="cubeNumber"></param>
    void ChangeColor(int cubeNumber)
    {
        switch (cubeNumber)
        {
            case 1:
                gameObject.GetComponent<Renderer>().material.color = new Color(0.50f, 1, 0);
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = new Color(0.75f, 1, 0);
                break;
            case 3:
                gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0.98f, 0);
                break;
            case 4:
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.79f, 0);
                break;
            case 5:
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.70f, 0);
                break;
            case 6:
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);
                break;
            case 7:
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                break;
            case 8:
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                break;

            default:
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        otherColliders.Add(other);
        if (other.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == "9" && gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text != "9")
        {
            int a = int.Parse(gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text);
            a++;
            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = a.ToString();
        }
    }


}
