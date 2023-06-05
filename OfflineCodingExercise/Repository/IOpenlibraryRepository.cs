using OfflineCodingExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Repository
{
    public interface IOpenlibraryRepository
    {
        Task<ResponseListModel> Get(string url, List<string> ISBNList);
    }
}
