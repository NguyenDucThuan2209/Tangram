using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SquareType
{
    Empty,
    Line_Horizontal,
    Line_Vertical,
    Number_2,
    Number_3,
    Number_4,
    Number_5,
    Number_8,
}

public class Square : MonoBehaviour
{
    [SerializeField] int m_id = -1;
    [SerializeField] SquareType m_type;
    [SerializeField] SpriteRenderer m_visual;
    [SerializeField] GameObject m_iconComplete;

    private bool m_isComplete;
    private Square m_currentSquare;
    private List<Square> m_squareList = new List<Square>();

    public int ID => m_id;
    public SquareType Type => m_type;
    public bool IsComplete => m_isComplete;
    public SpriteRenderer Visual => m_visual;
    public List<Square> SquareList => m_squareList;

    public int CoorX { get; set; }
    public int CoorY { get; set; }
    public bool IsConnected { get; set; }

    private void Update()
    {
        if (m_type == SquareType.Empty) return;

        UpdateStackState();
    }

    private void CheckFinishStack()
    {
        switch (m_type)
        {
            case SquareType.Line_Horizontal:
                {
                    for (int i = 0; i < m_squareList.Count; i++)
                    {
                        if (System.Math.Round(m_squareList[i].transform.position.y, 2) != System.Math.Round(transform.position.y, 2))
                        {
                            m_isComplete = false;
                            return;
                        }
                    }
                    m_isComplete = (m_squareList.Count > 0) ? true : false;

                }
                break;

            case SquareType.Line_Vertical:
                {
                    for (int i = 0; i < m_squareList.Count; i++)
                    {
                        if (m_squareList[i].transform.position.x != transform.position.x)
                        {
                            m_isComplete = false;
                            return;
                        }
                    }
                    m_isComplete = (m_squareList.Count > 0) ? true : false;
                }
                break;

            case SquareType.Number_2:
                {
                    m_isComplete = (m_squareList.Count + 1 == 2);
                }
                break;

            case SquareType.Number_3:
                {
                    m_isComplete = (m_squareList.Count + 1 == 3);
                }
                break;

            case SquareType.Number_4:
                {
                    m_isComplete = (m_squareList.Count + 1== 4);
                }
                break;

            case SquareType.Number_5:
                {
                    m_isComplete = (m_squareList.Count + 1 == 5);
                }
                break;

            case SquareType.Number_8:
                {
                    m_isComplete = (m_squareList.Count + 1 == 8);
                }
                break;
        }
    }
    private void UpdateStackState()
    {
        m_iconComplete.SetActive(m_isComplete && IsConnected);
    }

    public void SetSquareType(Square square)
    {
        if (square != m_currentSquare)
        {
            m_currentSquare?.OnClear(this);

            m_currentSquare = square;
            m_currentSquare.OnStack(this);
            m_visual.sprite = m_currentSquare.Visual.sprite;

            transform.name = $"{CoorX}_{CoorY} (ID: {square.ID})";
        }
    }
    public void OnStack(Square square)
    {
        m_squareList.Add(square);
        CheckFinishStack();
    }
    public void OnClear(Square square)
    {
        m_squareList.Remove(square);
        CheckFinishStack();
    }
}
