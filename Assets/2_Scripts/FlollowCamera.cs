using UnityEngine;

public class Follw : MonoBehaviour
{
    [SerializeField] GameObject FoollowTaget;

    void LateUpdate()
    {
        transform.position = FoollowTaget.transform.position + new Vector3(0, 0, -10);
    }
}
