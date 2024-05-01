using Helios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Last_Imagination
{
    public class Camera : Entity
    {
        private CameraComponent m_Camera;

        private Vector2 m_CursorLastPos;
        private Vector2 m_DeltaPos = new Vector2(0.0f);

        [HVEEditableField]
        private float Speed = 1.0f;

        [HVEEditableField]
        private bool Inverse = true;
        void OnCreate()
        {
            m_Camera = GetComponent<CameraComponent>();
            m_CursorLastPos = GetMousePosition();
        }

        void OnUpdate(float delta_time)
        {
            // Console.WriteLine($"Player updating, delta time {delta_time}");
            Vector2 m_CurrentPos = GetMousePosition();

            m_DeltaPos = m_CurrentPos - m_CursorLastPos;

            m_CursorLastPos = m_CurrentPos;
            
            if(m_Camera != null)
            {
                m_Camera.RotateAroundEntity(m_DeltaPos, Speed * delta_time, Inverse);
            }
        }
    }
}
