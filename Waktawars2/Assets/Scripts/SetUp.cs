using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUp : MonoBehaviour
{
    public float maxTime = 60;
    public int lineDistance = 50;
    public Transform lineParent;
    public GameObject mainLinePrefab;
    public GameObject subLinePrefab;

    public GameObject[] lines;

    public int maxNoteIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        SetLineLength();
        SetLine();
    }

    public void SetLineLength()
    {
        for(int i = 0; i < lines.Length; i++)
        {
            RectTransform rect = lines[i].GetComponent<RectTransform>();
            float newHeight = maxTime * 1000;
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
        }
    }

    public void SpawnMain(int yPos)
    {
        GameObject main = Instantiate(mainLinePrefab);
        main.transform.SetParent(lineParent);

        main.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = yPos + "ms";
        main.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, yPos, 0);
    }

    public void SpawnSub(int yPos)
    {
        GameObject sub = Instantiate(subLinePrefab);
        sub.transform.SetParent(lineParent);

        sub.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = yPos + "ms";
        sub.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, yPos, 0);
    }

    public void SetLine()
    {
        var temp = (maxTime * 1000) / lineDistance;

        for (int j = 0; j <= temp; j++)
        {
            if(j % 2 == 0) // Â¦¼ö
            {
                SpawnMain(j * lineDistance);
            }
            else if (j % 2 == 1) // È¦¼ö
            {
                SpawnSub(j * lineDistance);
            }
        }
    }
}
