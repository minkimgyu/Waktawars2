using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Note : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform line;
    RectTransform rect;
    Vector3 moveVec;

    Vector3 start;

    public int index = -1;

    public void Init(RectTransform rect, int noteIndex){
        line = rect;
        index = noteIndex;
    }

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            line.gameObject.GetComponent<Line>().DestroyNote(index);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(line, eventData.position, eventData.pressEventCamera, out Vector2 localCursor);
        rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, localCursor.y, 0);

        //float height = 1080;
        //float ratio = Mathf.FloorToInt(rect.anchoredPosition.y / height);

        //Debug.Log(rect.anchoredPosition.y);
        //Debug.Log(height);
        //Debug.Log(ratio);

        //float posY = eventData.position.y + (ratio * height);
        //moveVec.Set(rect.anchoredPosition.x, posY, 0);
        //rect.anchoredPosition = moveVec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}
