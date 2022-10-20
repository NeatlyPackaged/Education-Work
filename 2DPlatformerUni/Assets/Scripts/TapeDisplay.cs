using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeDisplay : MonoBehaviour
{
    Text Score_UIText;
    public int collection;
    public GameObject Video1;
    public GameObject Video2;
    public GameObject Video3;
    // Start is called before the first frame update
    void Awake()
    {
        Score_UIText = GetComponent<Text>();
        Video1.SetActive(false);
        Video2.SetActive(false);
        Video3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        collection = TapeCollector.tapesCol;

        Score_UIText.text = "You   collected   " + collection.ToString() + "   of the tapes";

        if (collection >= 1)
        {
            Video1.SetActive(true);
        }

        if (collection >= 2)
        {
            Video2.SetActive(true);
        }

        if (collection == 3)
        {
            Video3.SetActive(true);
        }
    }
}
