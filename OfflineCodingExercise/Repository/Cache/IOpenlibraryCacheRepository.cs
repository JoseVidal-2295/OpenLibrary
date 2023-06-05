using OfflineCodingExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineCodingExercise.Repository.Cache
{
    public interface IOpenlibraryCacheRepository
    {
        ResponseObjModel GetFronCache(string ISBN);

        ResponseObjModel SetToCache(string ISBN, OpenlibraryModel openlibraryModel);

        //string ISBN, OpenlibraryModel oOpenlibraryModel
    }
}
