using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationAngle;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        if (!TryGetComponent(out m_rigidbody))
        {
            m_rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        m_rigidbody.isKinematic = true;
        m_rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void FixedUpdate()
    {
        Vector3 rotation = m_rigidbody.rotation.eulerAngles;
        rotation.y += rotationAngle * Time.fixedDeltaTime;
        m_rigidbody.MoveRotation(Quaternion.Euler(rotation));
    }
}
