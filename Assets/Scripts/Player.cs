using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Died;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            Died.Invoke();
        }
    }
}
