using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios;

namespace Last_Imagination
{
    public class Boombox : Entity
    {
        private GlobalSoundsComponent m_Sounds;
        public void OnCreate()
        {
            m_Sounds = GetComponent<GlobalSoundsComponent>();

            if(m_Sounds != null)
            {
                m_Sounds.PlaySoundAtIndex(0);
            }
        }
    }
}
