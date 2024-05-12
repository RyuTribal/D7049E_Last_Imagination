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
        private LocalSoundsComponent m_Sound;

        public void OnCreate()
        {
            m_Sound = GetComponent<LocalSoundsComponent>();
        }
        public void OnUpdate(float dt)
        {
            if (m_Sound != null)
            {
                if (IsKeyPressed(KeyCode.Space))
                {
                    m_Sound.PlaySoundAtIndex(0);
                }
                
            }
            else
            {
                Console.WriteLine("Empty");
            }

            
        }
    }
}
