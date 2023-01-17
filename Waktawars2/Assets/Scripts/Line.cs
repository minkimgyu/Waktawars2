using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour, IPointerClickHandler
{
    public SetUp setUp;

    public Transform noteParent;
    public List<Note> notes = new List<Note>();
    public GameObject notePrefab;
    RectTransform rect;

    public void DestroyNote(int noteIndex)
    {
        Note tempNote = notes.Find(note => note.index == noteIndex);
        notes.Remove(tempNote);
        Destroy(tempNote.gameObject);
    }

    public void InstantiateNote(Vector3 pos)
    {
        GameObject go = Instantiate(notePrefab);
        go.transform.SetParent(noteParent);
        go.GetComponent<RectTransform>().anchoredPosition = pos;

        Note note = go.GetComponent<Note>();

        setUp.maxNoteIndex += 1;
        note.Init(rect, setUp.maxNoteIndex);
        notes.Add(note); // 노트에 추가해줌
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out Vector2 localCursor);
        float noteX = rect.anchoredPosition.x;
        float noteY = localCursor.y;

        InstantiateNote(new Vector3(noteX, noteY, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
