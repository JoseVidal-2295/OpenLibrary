using OfflineCodingExercise.BussnesLayer;
using OfflineCodingExercise.Model;
using OfflineCodingExercise.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OfflineCodingExercise.Presenter
{
    public partial class FrmOpenlibrary : Form
    {
        private readonly IOpenlibraryLayer _openlibraryLayer;
        private readonly IFileLayer _fileLayer;
        private readonly IMessage _message;

        private List<OpenlibraryModel> _OpenlibraryModelList =new List<OpenlibraryModel>();

       
        public FrmOpenlibrary(IOpenlibraryLayer openlibraryLayer, IFileLayer fileLayer, IMessage message)
        {
            InitializeComponent();

            _openlibraryLayer = openlibraryLayer;
            _fileLayer = fileLayer;
            _message = message;
        }

        private void btnProcess_Click(object sender, System.EventArgs e)
        {

            if (_OpenlibraryModelList == null || _OpenlibraryModelList.Count<1)
            {
                _message.Warning("No data to export");
                return;
            }

            var resultWriteFile = _fileLayer.WriteFile(_OpenlibraryModelList);

            if (resultWriteFile.Success)
            {
                _message.Ok("CSV file was created successfully!");
            }

        }

        private void btnSelection_Click(object sender, System.EventArgs e)
        {
            string url = "https://openlibrary.org/api/books";

            var resultReadFile = _fileLayer.ReadFile();

            if (!resultReadFile.Success)
            {
                _message.Error(resultReadFile.Message);
                
                return;
            }

            var resultGet = _openlibraryLayer.Get(url, resultReadFile.ISBNList);

            if (!resultGet.Result.Success)
            {
                _message.Error(resultGet.Result.Message);
                return;
            }

            txtPath.Text = resultReadFile.Message;

            _OpenlibraryModelList = resultGet.Result.DataList;

            dgwOpenLibrary.DataSource = _OpenlibraryModelList;


        }
    }
}
