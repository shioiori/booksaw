using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Interfaces.Base
{
    public interface IBaseRepository
    {
        void BeginTransaction();
        int Commit();
        void Dispose();
    }
}
