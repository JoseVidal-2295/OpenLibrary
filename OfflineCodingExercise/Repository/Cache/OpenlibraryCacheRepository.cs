using System;
using System.Runtime.Caching;
using OfflineCodingExercise.Model;
using Newtonsoft.Json;

namespace OfflineCodingExercise.Repository.Cache
{
   public class OpenlibraryCacheRepository : IOpenlibraryCacheRepository
    {
        public ResponseObjModel GetFronCache(string ISBN)
        {
            ResponseObjModel oResponse = new ResponseObjModel();

            OpenlibraryModel oOpenlibraryModel = new OpenlibraryModel();

            string cachedValue = "";

            try
            {
                //Implementing the local cache

                MemoryCache cache = MemoryCache.Default;

                // Read value from cache
                cachedValue = cache.Get(ISBN) as string;

                if (cachedValue != null)
                {
                    //Deserialize json
                    oOpenlibraryModel = JsonConvert.DeserializeObject<OpenlibraryModel>(cachedValue);

                    oResponse.Success = true;
                    oResponse.Message = "Complete";
                    oResponse.DataObj = oOpenlibraryModel;
                }
                else
                {
                    oResponse.Success = false;
                    oResponse.Message = "Not found";
                    oResponse.DataObj = oOpenlibraryModel;
                }
            }
            catch (Exception ex)
            {
                oResponse.Success = false;
                oResponse.Message = ex.ToString();
            }

            return oResponse;
        }

        public ResponseObjModel SetToCache(string ISBN, OpenlibraryModel openlibraryModel)
        {
            ResponseObjModel oResponse = new ResponseObjModel();
            string key = "";
            string value = "";

            try
            {
                MemoryCache cache = MemoryCache.Default;
                
                key = ISBN;

                value = JsonConvert.SerializeObject(openlibraryModel);

                // Save the value in the cache with a duration of 10 minutes
                DateTimeOffset expiration = DateTimeOffset.Now.AddMinutes(10);

                cache.Set(key, value, expiration);

                oResponse.Success = true;
                oResponse.Message = "Complete";
            
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
