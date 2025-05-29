using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;
using System;

public class Player : MonoBehaviour, IKitchenObjectPlayer 
{
    public static Player Instance { get; private set; }

    public event EventHandler <OnSelectedCounterCangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterCangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private GameInput gameInput;
   [SerializeField] private LayerMask counterlayerMask;
   [SerializeField] private Transform KitchenObjectHoldPoint;

    private bool isWalking;
    private Vector3 lastInteractDir;
    private ClearCounter selectedCounter;
    private KitchenObject kitchenObject;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }


        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance, counterlayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                if (clearCounter != selectedCounter)
                {
                   SetSelectedCounter  (clearCounter);
                }
                else
                {
                    SetSelectedCounter (null);
                }
            }
            else
            {
                SetSelectedCounter (null);
            }
        }
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 2f;
        float playerRadius = .7f;
        float rotateSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward, lastInteractDir, Time.deltaTime * rotateSpeed);

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);


            if (canMove)
            {
                moveDir = moveDirX;
            }

            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else { }

               
            }
            isWalking = moveDir != Vector3.zero;
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;

        }




    }
    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
          
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterCangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

    public Transform GetKitchenObjectFollowTrasnform()
    {
        return KitchenObjectHoldPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObejct()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject() { return kitchenObject != null; }
}


  

