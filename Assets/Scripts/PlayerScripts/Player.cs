using Helios;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Imagination
{
    public class Player : Entity
    {
        private BoxColliderComponent m_BoxCollider;

        [HVEEditableField]
        private float Speed = 10.0f;

        [HVEEditableField]
        private float Max_Speed = 100.0f;

        [HVEEditableField]
        private float CameraSensativity = 1.0f;


        private CameraComponent m_Camera;

        private Vector2 m_CursorLastPos;
        private Vector2 m_DeltaPos = new Vector2(0.0f);

        [HVEEditableField]
        private bool Inverse = false;

        void OnCreate()
        {
            m_BoxCollider = GetComponent<BoxColliderComponent>();
            Console.WriteLine($"Player {ID} created");

            m_Camera = GetComponent<CameraComponent>();
            m_CursorLastPos = GetMousePosition();
        }

        void OnUpdate(float delta_time)
        {
            // Console.WriteLine($"Player updating, delta time {delta_time}");
           
            if(m_BoxCollider != null) 
            {
                Vector3 velocity = new Vector3(0.0f);
                Vector3 forward_vector = m_Camera.GetForwardDirection();
                Vector3 right_vector = m_Camera.GetRightDirection();
                if (IsKeyPressed(KeyCode.D))
                {
                    Vector3 right = right_vector * Speed;
                    velocity += right;
                }

                if(IsKeyPressed(KeyCode.A)) 
                {
                    Vector3 left = right_vector * -Speed;
                    velocity += left;
                }

                if (IsKeyPressed(KeyCode.W))
                {
                    Vector3 forward = forward_vector * Speed;
                    velocity += forward;
                }

                if (IsKeyPressed(KeyCode.S))
                {
                    Vector3 back = forward_vector * -Speed;
                    velocity += back;
                }

                m_BoxCollider.AddLinearVelocity(velocity * delta_time);
            }


            Vector2 m_CurrentPos = GetMousePosition();

            m_DeltaPos = m_CurrentPos - m_CursorLastPos;

            m_CursorLastPos = m_CurrentPos;

            if (m_Camera != null)
            {
                m_Camera.RotateAroundEntity(m_DeltaPos, CameraSensativity * delta_time, Inverse);
            }
        }
    }
}
