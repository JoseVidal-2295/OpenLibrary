using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Model
{
    public class ResponseFile: BaseResponseModel
    {
        public List<string> ISBNList { get; set; }
    }
}
