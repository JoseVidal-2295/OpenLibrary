using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineCodingExercise.Model;
using OfflineCodingExercise.Repository;

namespace OfflineCodingExercise.BussnesLayer
{
    public class OpenlibraryLayer : IOpenlibraryLayer
    {
        private readonly IOpenlibraryRepository _openlibraryRepository;
        public OpenlibraryLayer(IOpenlibraryRepository openlibraryRepository)
        {
            _openlibraryRepository = openlibraryRepository;
        }
        public async Task<ResponseListModel> Get(string url, List<string> ISBNList)
        {
            ResponseListModel oResponse = new ResponseListModel();
            try
            {
                oResponse = await _openlibraryRepository.Get(url, ISBNList);
            }
            catch (Exception ex) 
            {
                oResponse.Success = false;
                oResponse.Message = ex.ToString();
                oResponse.Message = ex.ToString();
            }

            return oResponse;
        }
    }
}
