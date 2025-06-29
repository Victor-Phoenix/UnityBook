using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX =1,
        mouseY=2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHor = 9.0f;
    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            //horizontal rotation here
            //transform.Rotate(0, sensitivityHor, 0);
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

        }
        else if (axes == RotationAxes.mouseY)
        {
            // Vertical rotation here
        }
        else
        {
            //Both horizontal and vertical rotation here
        }
        
    }
}
