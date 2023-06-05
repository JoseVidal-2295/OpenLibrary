using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfflineCodingExercise.Model;
using OfflineCodingExercise.Repository.Cache;
using OfflineCodingExercise.Shared;
using RestSharp;

namespace OfflineCodingExercise.Repository
{
    public class OpenlibraryRepository : IOpenlibraryRepository
    {
        private readonly IOpenlibraryCacheRepository _openlibraryCacheRepository;

        public OpenlibraryRepository(IOpenlibraryCacheRepository openlibraryCacheRepository)
        {
            _openlibraryCacheRepository = openlibraryCacheRepository;
        }

        public async Task<ResponseListModel> Get(string url, List<string> ISBNList)
        {
            ResponseListModel oResponse = new ResponseListModel();

            try
            {
                List<OpenlibraryModel> openlibraryList = new List<OpenlibraryModel>();

                int rowNumber = 0;

                foreach (var isbn in ISBNList)
                {

                    OpenlibraryModel oOpenlibraryModel = new OpenlibraryModel();
                    JObject jContent = new JObject();
                    JObject jData = new JObject();
                    JArray authors = new JArray();
                    string authorsResult = "";
                    Boolean isFromCache = false;

                    rowNumber++;

                    //Look in the cache
                    var cacheResult =_openlibraryCacheRepository.GetFronCache(isbn);

                    if (cacheResult.Success)
                    {
                        isFromCache = true;

                        oOpenlibraryModel = cacheResult.DataObj;

                        oOpenlibraryModel.DataRetrievalType = DataRetrievalType.Cache.ToString();

                    }
                    else
                    {
                        var client = new RestClient(url);
                        var request = new RestRequest(Method.GET);
                        request.AddParameter("format", "json");
                        request.AddParameter("bibkeys", isbn);
                        request.AddParameter("jscmd", "data");
                        IRestResponse response = client.Execute(request);

                        if (response.StatusCode == HttpStatusCode.OK && response.Content.Length > 4)
                        {
                            jContent = JsonConvert.DeserializeObject<JObject>(response.Content);

                            jData = (JObject)jContent[isbn];

                            oOpenlibraryModel = jData.ToObject<OpenlibraryModel>();

                            authors = jData.GetValue("authors").ToObject<JArray>();

                            foreach (JObject author in authors)
                            {
                                if (authorsResult == "")
                                {
                                    authorsResult = author["name"].ToString();
                                }
                                else
                                {
                                    authorsResult = $"{authorsResult}, {author["name"].ToString()}";
                                }
                            }

                            oOpenlibraryModel.AuthorName = authorsResult;
                            oOpenlibraryModel.DataRetrievalType = DataRetrievalType.Server.ToString();
                            oOpenlibraryModel.ISBN = isbn;
                        }
                        else if (response.StatusCode == 0)
                        {
                            oResponse.Success = false;
                            oResponse.Message = "Network error, please check your internet connection";
                            oResponse.DataList = openlibraryList;

                            return  oResponse;
                        }

                    }

                    if (!string.IsNullOrEmpty(oOpenlibraryModel.ISBN))
                    {
                        oOpenlibraryModel.RowNumber = rowNumber;

                        oOpenlibraryModel.NumberofPages = !string.IsNullOrEmpty(oOpenlibraryModel.NumberofPages) ? oOpenlibraryModel.NumberofPages : "N/A";

                        openlibraryList.Add(oOpenlibraryModel);

                        //save in cache

                        if (!isFromCache)
                        {
                            _openlibraryCacheRepository.SetToCache(isbn, oOpenlibraryModel);
                        }
                    }

                    

                }

                oResponse.Success = true;
                oResponse.Message = "Complete";
                oResponse.DataList = openlibraryList;
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.ToString();
            }

            return oResponse;
        }
    }
}
