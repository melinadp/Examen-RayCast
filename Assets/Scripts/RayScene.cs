using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayScene : MonoBehaviour
{
    public Text time;

    public int totalTime;
    public int maxTime;
    private int option;
    private bool isMenuClicked;

    private float nextTime;
    private float pauseTime;
    private bool isWorking;

    private float timePercent
    {
        get {return (float) totalTime / maxTime;}
    }

    // Start is called before the first frame update
    void Start()
    {
        isMenuClicked = false;
        maxTime = totalTime;
        nextTime = 0;
        pauseTime = 1f;
        isWorking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (isWorking == true)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + pauseTime;
                
                if (totalTime >= 0)
                {
                    totalTime--;
                }
            }

            if (totalTime < 0)
            {
                totalTime = 0;
            }
            time.text = totalTime.ToString();
        }

        if (Input.GetMouseButtonDown(0) && isMenuClicked == false)
        {
            if (Physics.Raycast(ray, out hit) == true)
            {
                var selection = hit.transform;
                Debug.Log("El rayo toca con:" + hit.transform.gameObject.tag);
                if (selection.CompareTag("Cube1") || selection.CompareTag("Sphere") || selection.CompareTag("Cube2"))
                {
                    if (selection.CompareTag("Cube1"))
                    {
                        option = 1;
                    }
                    if (selection.CompareTag("Sphere"))
                    {
                        option = 2;
                    }
                    if (selection.CompareTag("Cube2"))
                    {
                        option = 3;
                    }

                    isWorking = true;
                    StartCoroutine(Count());
                }
            }
        }
    }
    
    IEnumerator Count()
    {
        yield return new WaitForSeconds(5f);
        if (option == 1)
        {
            SceneManager.LoadScene("Scene1 1");
        }
        if (option == 2)
        {
            SceneManager.LoadScene("Scene1 2");
        }
        if (option == 3)
        {
            SceneManager.LoadScene("Scene1 3");
        }

    }
}


