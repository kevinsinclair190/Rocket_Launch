using UnityEngine;

public class GravitySettings : MonoBehaviour
{
    [SerializeField] float gravityY = -1.62f;
    void Start()
    {
        Physics.gravity = new Vector3(0, gravityY, 0);
    }
}

