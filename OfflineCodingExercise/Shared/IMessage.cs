using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Shared
{
    public interface IMessage
    {
        void Ok(string message);
        void Error(string message);
        void Warning(string message);
    }
}
