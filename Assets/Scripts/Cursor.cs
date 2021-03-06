namespace IntroToGameDev.Steering
{
    using UnityEngine;

    public class Cursor : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.Cursor.visible = false;
        }

        private void Update()
        {
            if (Camera.current == null)
            {
                return;
            }
            var ray = Camera.current.ScreenPointToRay(Input.mousePosition);
            var plane = new Plane(Vector3.up, Vector3.zero);
            if (plane.Raycast(ray, out float distance))
            {
                transform.position = ray.GetPoint(distance);
            }
        }
    }
}