using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Model
{
    public abstract class BaseResponseModel
    {
        public Boolean Success { get; set; }
        public string Message { get; set; }
    }
}
