using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float amplitude;
    public float period;

    private Vector3 m_center;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        if (!TryGetComponent(out m_rigidbody))
        {
            m_rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        m_center = m_rigidbody.position;
        m_rigidbody.isKinematic = true;
        m_rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void FixedUpdate()
    {
        Vector3 position = m_rigidbody.position;
        position.y = m_center.y + amplitude * Mathf.Sin(period * Time.time);
        m_rigidbody.MovePosition(position);
    }
}
