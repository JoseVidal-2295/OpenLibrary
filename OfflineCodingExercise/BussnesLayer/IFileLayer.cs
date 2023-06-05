using OfflineCodingExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.BussnesLayer
{
    public interface IFileLayer
    {
        ResponseFile ReadFile();

        ResponseFile WriteFile(List<OpenlibraryModel> OpenlibraryModelList);
    }
}
