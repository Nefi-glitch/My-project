using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtCamara : MonoBehaviour
{
    private enum Mode
    {
        LookAT,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    [SerializeField] private Mode mode;


    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAT:
        transform.LookAt(Camera.main.transform);
        break;
                case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - Camera.main.transform.forward;
                transform.LookAt(transform.position + dirFromCamera);
                break;
                case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
                case Mode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
    }
    }
}
