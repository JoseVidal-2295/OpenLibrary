using OfflineCodingExercise.BussnesLayer;
using OfflineCodingExercise.Presenter;
using OfflineCodingExercise.Repository;
using OfflineCodingExercise.Repository.Cache;
using OfflineCodingExercise.Shared;
using System;
using System.Windows.Forms;

namespace OfflineCodingExercise
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IOpenlibraryCacheRepository openlibraryCacheRepository = new OpenlibraryCacheRepository();
            IOpenlibraryRepository openlibraryRepository = new OpenlibraryRepository(openlibraryCacheRepository);
            IOpenlibraryLayer openlibraryLayer = new OpenlibraryLayer(openlibraryRepository);
            IFileLayer fileLayer = new FileLayer();
            IMessage message = new Shared.Message();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmOpenlibrary(openlibraryLayer, fileLayer, message));
        }
    }
}
