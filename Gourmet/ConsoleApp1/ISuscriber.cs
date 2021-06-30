using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public interface ISuscriber
    {
        public void Update(Recipe recipe);
    }
}
