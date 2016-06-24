using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOpenGL.Entity
{
    interface ICollisionable
    {
        bool IsCollision( ICollisionable target );
    }
}
