

using Newtonsoft.Json;
using System.ComponentModel;

namespace OfflineCodingExercise.Model
{
    public class OpenlibraryModel
    {
        [DisplayName("Row Number")]
        public int RowNumber { get; set; }

        [DisplayName("Data Retrieval Type")]
        public string DataRetrievalType { get; set; }

        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Subtitle")]
        public string Subtitle { get; set; }

        [DisplayName("Author Name(s)")]
        public string AuthorName { get; set; }

        [DisplayName("Number of Pages")]

        [JsonProperty("number_of_pages")]
        public string NumberofPages { get; set; }

        [DisplayName("Publish Date")]

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }
       
    }
}
