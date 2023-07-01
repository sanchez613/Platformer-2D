using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGround {get; private set;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            IsGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
            IsGround = false;
    }
}
