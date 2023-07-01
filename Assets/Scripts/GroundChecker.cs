using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isOnGround;

    public bool IsGround => _isOnGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            _isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
            _isOnGround = false;
    }
}
