using UnityEngine;

public class InputController : MonoBehaviour
{
    void Update()
    {
        Player.Instance.Move(Input.GetAxis("Horizontal"));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Instance.Jump();
        }
    }
}
