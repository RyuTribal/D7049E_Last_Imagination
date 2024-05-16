using Helios;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Last_Imagination
{
    public class Player : Entity
    {
        private CharacterControllerComponent m_CharacterControllerComponent;
        private BoxColliderComponent m_BoxCollider;
        private SphereColliderComponent m_SphereColliderComponent;
        private TransformComponent m_TransformComponent;

        [HVEEditableField]
        private float Speed = 10.0f;

        [HVEEditableField]
        private float RotationSpeed = 10.0f;

        [HVEEditableField]
        private float Max_Speed = 100.0f;

        [HVEEditableField]
        private float CameraSensativity = 1.0f;


        private CameraComponent m_Camera;

        private Vector2 m_CursorLastPos;
        private Vector2 m_DeltaPos = new Vector2(0.0f);

        [HVEEditableField]
        private bool Inverse = true;

        void OnCreate()
        {
            m_CharacterControllerComponent = GetComponent<CharacterControllerComponent>();
            m_SphereColliderComponent = GetComponent<SphereColliderComponent>();
            m_BoxCollider = GetComponent<BoxColliderComponent>();
            Console.WriteLine($"Player {ID} created");

            m_Camera = GetComponent<CameraComponent>();
            m_CursorLastPos = GetMousePosition();
            m_TransformComponent = GetComponent<TransformComponent>();
        }

        void OnUpdate(float delta_time)
        {
            if (m_CharacterControllerComponent != null && m_Camera != null)
            {
                float X = 0.0f;
                float Z = 0.0f;
                bool keyDown = false;

                Vector3 desiredRotation = m_CharacterControllerComponent.GetRotation();

                if (IsKeyPressed(KeyCode.W))
                {
                    Z = 1.0f;
                    keyDown = true;
                    desiredRotation.Y = -m_Camera.Rotation.Y;
                }
                else if (IsKeyPressed(KeyCode.S))
                {
                    Z = -1.0f;
                    keyDown = true;
                    desiredRotation.Y = -m_Camera.Rotation.Y + (float)Math.PI;
                }

                if (IsKeyPressed(KeyCode.A))
                {
                    X = -1.0f;
                    keyDown = true;
                    desiredRotation.Y = -m_Camera.Rotation.Y + (float)(Math.PI / 2.0f);
                }
                else if (IsKeyPressed(KeyCode.D))
                {
                    X = 1.0f;
                    keyDown = true;
                    desiredRotation.Y = -m_Camera.Rotation.Y - (float)(Math.PI / 2.0f);
                }

                bool isGrounded = m_CharacterControllerComponent.IsCharacterGrounded();

                // If a key was pressed, determine the yaw to rotate the character
                if (keyDown)
                {
                    // rotate to face camera direction
                    //Vector3 currentRotation = m_CharacterControllerComponent.GetRotation();

                    //desiredRotation.Y = ClampAngle(desiredRotation.Y);

                    //float diff1 = Modulo(desiredRotation.Y - currentRotation.Y, (float)(Math.PI * 2));
                    //float diff2 = Modulo(currentRotation.Y - desiredRotation.Y, (float)(Math.PI * 2));
                    //bool useDiff2 = diff2 < diff1;

                    //float delta = useDiff2 ? Math.Max(-diff2, -Math.Abs(RotationSpeed * delta_time)) : Math.Min(diff1, Math.Abs(RotationSpeed * delta_time));

                    //currentRotation.Y += delta;
                    //m_CharacterControllerComponent.SetRotation(currentRotation);

                    if (isGrounded)
                    {
                        Vector3 movement = (m_Camera.GetUpRightRightDirection() * X) + (m_Camera.GetUpRightForwardDirection() * Z);
                        movement = Vector3.Normalize(movement);
                        movement *= Speed * delta_time;

                        if (IsKeyPressed(KeyCode.Space))
                        {
                            movement.Y = 9.82f;
                        }

                        m_CharacterControllerComponent.AddLinearVelocity(movement);
                    }
                }
            }

            Vector2 m_CurrentPos = GetMousePosition();

            m_DeltaPos = m_CurrentPos - m_CursorLastPos;

            m_CursorLastPos = m_CurrentPos;

            if (m_Camera != null)
            {
                m_Camera.RotateAroundEntity(m_DeltaPos, CameraSensativity * delta_time, Inverse);
            }
        }

        public static float Modulo(float v0, float v1) => v0 - v1 * (float)Math.Floor(v0 / v1);

        public static float ClampAngle(float angle)
        {
            angle = angle % (2 * (float)Math.PI); // Normalize the angle to be within -2π to 2π
            if (angle < -(float)Math.PI)
                angle += 2 * (float)Math.PI;
            else if (angle > (float)Math.PI)
                angle -= 2 * (float)Math.PI;
            return angle;
        }
    }
}
