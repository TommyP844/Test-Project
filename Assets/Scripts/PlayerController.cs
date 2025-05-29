
using System;
using System.Numerics;
using Mule;
using Mule.Components;

class PlayerController : Entity
{
    TransformComponent transform;
    RigidBody rigidBody;    
    Camera Camera;
    float Force = 5F;
    Vector3 Gravity = new Vector3(0F, -9.81F, 0F);
    int Count = 2;
    int IsTouchingGround = 0;


    void OnStart()
    {
        transform = GetComponent<TransformComponent>();
        rigidBody = GetComponent<RigidBody>();
        var cameraComponent = GetComponent<CameraComponent>();
        Camera = cameraComponent.GetCamera();
    }

    void OnUpdate(float dt)
    {
        float yVel = rigidBody.GetLinearVelocity().Y;
        Vector3 velocity = Vector3.Zero;
        Vector3 forwardDir = Camera.GetViewDirection();
        forwardDir = Vector3.Normalize(new Vector3(forwardDir.X, 0F, forwardDir.Z));
        Vector3 rightDir = Camera.GetRightDirection();
        rightDir = Vector3.Normalize(new Vector3(rightDir.X, 0F, rightDir.Z));
        
        if (Input.IsKeyDown(Key.W))
            velocity += forwardDir * Force;
        if (Input.IsKeyDown(Key.S))
            velocity -= forwardDir * Force;
        if (Input.IsKeyDown(Key.A))
            velocity -= rightDir * Force;
        if (Input.IsKeyDown(Key.D))
            velocity += rightDir * Force;

        velocity.Y = yVel;
        rigidBody.AddImpulse(new Vector3(0F, 1000F, 0F));

        rigidBody.SetLinearVelocity(velocity);

        
    }
}