using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject;

    [SerializeField]
    private CommandProcessor commands = new CommandProcessor();


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 checkPosition = Camera.main.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(checkPosition.x, checkPosition.y), Vector2.zero, 0);
            if (hit)
            {
                IInteractableController interactableObject = hit.transform.gameObject.GetComponent<IInteractableController>();
                if (interactableObject != null)
                {
                    commands.Add(interactableObject.GetCommands(playerObject));
                }
                else
                {
                    UnityEngine.Debug.LogError("Missing IInteractableController on object: " + hit.transform.gameObject.GetType().Name);
                }
            }
            else
            {
                // Just move
                commands.Add(new MoveCommand(playerObject, checkPosition));
            }
        }
    }
}
