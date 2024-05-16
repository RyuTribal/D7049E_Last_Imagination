using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios;

namespace Last_Imagination
{
    public class Ball : Entity
    {
        private LocalSoundsComponent m_Sounds;
        private bool m_IsColliding = false;
        void OnCreate()
        {
            m_Sounds = GetComponent<LocalSoundsComponent>();
        }

        void OnUpdate(float delta_time)
        {
            if (m_IsColliding)
            {
                m_Sounds.PlaySoundAtIndex(0);
            }
        }


        void OnNewCollision(ulong colliding_entity)
        {
            if (colliding_entity == 3782211478)
            {
                m_IsColliding = true;
            }
        }


        void OnRemovedCollision(ulong colliding_entity)
        {
            if (colliding_entity == 3782211478)
            {
                m_IsColliding = false;
            }
        }
    }
}
