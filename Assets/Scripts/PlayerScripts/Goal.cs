using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios;

namespace Last_Imagination
{
    public class Goal : Entity
    {
        private BoxColliderComponent m_BoxCollider;
        private LocalSoundsComponent m_Sounds;
        void OnCreate()
        {
            m_BoxCollider = GetComponent<BoxColliderComponent>();
            m_Sounds = GetComponent<LocalSoundsComponent>();
        }

        void OnNewCollision(ulong colliding_entity)
        {
            if (colliding_entity == 1800500615754059023)
            {
                m_Sounds.PlaySoundAtIndex(0);
                DestroyEntity(colliding_entity);
            }
        }
    }
}
