using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineDrawing : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public bool canDraw = false;

    private bool startDraw = false;

    public LineRenderer linePrefab; // Drag a LineRenderer prefab here

    private LineRenderer currentLine;

    private List<LineRenderer> activeLines;

    private EdgeCollider2D edgeCollider;

    [SerializeField]
    private Transform linesParent;

    private List<Vector2> points = new List<Vector2>();


    private void OnEnable()
    {
        GameplayEventsHandler.onGameStart += EnableDrawing;
        GameplayEventsHandler.onGameUnPause += EnableDrawing;
        GameplayEventsHandler.onGamePause += DisableDrawing;
        GameplayEventsHandler.onScore += ClearLines;
    }

    private void OnDisable()
    {
        GameplayEventsHandler.onGameStart -= EnableDrawing;
        GameplayEventsHandler.onGameUnPause -= EnableDrawing;
        GameplayEventsHandler.onGamePause -= DisableDrawing;
        GameplayEventsHandler.onScore -= ClearLines;


    }

    private void Start()
    {
        activeLines = new List<LineRenderer>();
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab);
        points.Clear();
        points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, points[0]);
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        edgeCollider.points = points.ToArray();
        activeLines.Add(currentLine);
    }

    void UpdateLine(Vector2 newPoint)
    {
        if (!currentLine)
            return;
        points.Add(newPoint);
        currentLine.positionCount = points.Count;
        currentLine.SetPosition(points.Count - 1, newPoint);
        edgeCollider.points = points.ToArray();
    }

    private void DisableDrawing()
    {
        canDraw = false;
    }

    private void EnableDrawing()
    {
        canDraw = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!canDraw)
            return;

        startDraw = true;

        CreateLine();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (!canDraw || !startDraw)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > 0.1f)
        {
            UpdateLine(mousePos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startDraw = false;
    }

    private void ClearLines() 
    {
        if (activeLines.Count == 0)
            return;

        for (int i = 0; i < activeLines.Count; i++) 
        {
            Destroy(activeLines[i].gameObject);
        }
        activeLines.Clear();
    }
}