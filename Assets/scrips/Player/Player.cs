using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour

{

   [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput; 

    private bool iswalking;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Debug.Log(inputVector);

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        iswalking = moveDir != Vector3.zero;

        float rotateSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime *rotateSpeed);   

    }
    public bool IsWalking()
    {
        return iswalking;
    }
}
