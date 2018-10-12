namespace IntroToGameDev.Steering.Behaviors
{
    using UnityEngine;

    public class AvoidEdges : DesiredVelocityProvider
    {
        private float edge = 0.05f;
        
        public override Vector3 GetDesiredVelocity()
        {
            var cam = Camera.current;
            var maxSpeed = Vehicle.VelocityLimit;
            var v = Vehicle.Velocity;
            if (cam == null)
            {
                return v;
            }
            
            var point = cam.WorldToViewportPoint(transform.position);

            if (point.x > 1 - edge)
            {
                return new Vector3(-maxSpeed, 0, 0);
                
            }
            if (point.x < edge)
            {
                return new Vector3(maxSpeed, 0, 0);
            }
            if (point.y > 1 - edge)
            {
                return new Vector3(0, 0, -maxSpeed);
            }
            if (point.y < edge)
            {
                return new Vector3(0, 0, maxSpeed);
            }

            return v;
        }
    }
}