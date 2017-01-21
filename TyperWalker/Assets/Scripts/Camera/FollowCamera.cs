using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField, Tooltip("Player reference")]
    private Transform m_target = null;
    [SerializeField, Tooltip("Follow delay")]
    private float m_followDelay = 0.2f;
    [SerializeField, Tooltip("Y axis offset")]
    private float m_yAxisOffset = 0.5f;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        Vector3 newPos = Vector2.Lerp(transform.position, m_target.position + (Vector3.up * m_yAxisOffset), m_followDelay * Time.deltaTime);
        newPos.z = transform.position.z;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
