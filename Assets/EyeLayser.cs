using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLayser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100f;
    [SerializeField] private GameObject player = null;

    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    Transform m_transform;
    Vector2 dir;

    [SerializeField] private LayerMask ground;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer.SetWidth(0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        TrackingPlayer();
        ShootLaser();
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(m_transform.position, dir))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, dir);
            Draw2DRay(laserFirePoint.position,_hit.point);
            Debug.Log("into raycast");

        }
        else
        {
            Draw2DRay(laserFirePoint.position, dir * defDistanceRay);
            Debug.Log("out of raycast");

        }
    }

    void TrackingPlayer()
    {
        dir = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
    }

    void Draw2DRay(Vector2 startPos,Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
