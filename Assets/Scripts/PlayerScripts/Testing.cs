using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Helios;

namespace Last_Imagination
{
    public class Testing : Entity
    {
        private BoxColliderComponent m_Coller;

        public void OnCreate()
        {
            m_Coller = GetComponent<BoxColliderComponent>();
        }
        public void OnUpdate(float dt)
        {
            if (m_Coller != null)
            {
                if (IsKeyPressed(KeyCode.D))
                {
                    Vector3 velocity = new Vector3(0.0f);
                    velocity.X = 10.0f * dt;
                    m_Coller.AddLinearVelocity(velocity);
                }
                
            }

            
        }
    }
}
