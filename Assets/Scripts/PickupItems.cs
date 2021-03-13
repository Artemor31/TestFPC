using UnityEngine;

public class PickupItems : MonoBehaviour
{
    [SerializeField] private Transform _pickupHolder;
    [SerializeField] private float _kickPower;

    private void Start()
    {
        _pickupHolder = GameObject.Find("PickupHolder").transform;
        _kickPower = 30;
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            KickItem();
        else
            GrabItem();
    }

    private void OnMouseUp()
    {
        ReleaseItem();
    }
        
    private void KickItem()
    {
        var kickDirection = _kickPower * (_pickupHolder.position - transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(-kickDirection, ForceMode.Impulse);
    }

    private void GrabItem()
    {
        var thisTransform = transform;
        
        thisTransform.parent = _pickupHolder;
        thisTransform.position = _pickupHolder.position;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ReleaseItem()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}