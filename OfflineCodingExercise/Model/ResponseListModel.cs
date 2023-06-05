using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Model
{
    public class ResponseListModel: BaseResponseModel
    {
       public List<OpenlibraryModel> DataList { get; set; }
    }
}
