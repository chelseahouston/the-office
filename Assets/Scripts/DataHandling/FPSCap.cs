using UnityEngine;

public class FPSCap : MonoBehaviour
{
    public int targetFPS = 60;

    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = targetFPS;
    }
}