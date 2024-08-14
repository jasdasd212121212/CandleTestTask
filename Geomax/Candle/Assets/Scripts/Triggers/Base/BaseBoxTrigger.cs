using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public abstract class BaseBoxTrigger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;

        Rigidbody selfRigidbody = GetComponent<Rigidbody>();

        selfRigidbody.isKinematic = true;
        selfRigidbody.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        OnEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit(other);
    }

    protected abstract void OnEnter(Collider other);
    protected virtual void OnExit(Collider other) { }
}