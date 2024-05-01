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
        void OnCreate()
        {
            m_BoxCollider = GetComponent<BoxColliderComponent>();
            Console.WriteLine($"Player {ID} created");
        }

        void OnUpdate(float delta_time)
        {
            // Console.WriteLine($"Player updating, delta time {delta_time}");
           
            if(m_BoxCollider != null) 
            {
                Vector3 velocity = new Vector3(0.0f);
                if (IsKeyPressed(KeyCode.D))
                {
                    velocity.X += Speed;
                }

                if(IsKeyPressed(KeyCode.A)) 
                {
                    velocity.X += -Speed;
                }

                m_BoxCollider.AddLinearVelocity(velocity * delta_time);
            }
        }
    }
}
