using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldCamera: MonoBehaviour
{
    public float xMargin = 1f;

    public float xSmooth = 8f;
    public float ySmooth = 8f;
    public Vector2 maxXY;
    public Vector2 minXY;

    private Transform m_Player;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private bool CheckXMarginRight()
    {
        return (transform.position.x - m_Player.position.x) < xMargin;
    }

    private bool CheckXMarginLeft()
    {
        return (transform.position.x - m_Player.position.x) > xMargin;
    }

    private void Update()
    {
        TrackPlayer();
    }

    private void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMarginRight() || CheckXMarginLeft())
        {
            targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXY.x, maxXY.x);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

    }
}