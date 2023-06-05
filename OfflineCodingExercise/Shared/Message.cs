
using System.Windows.Forms;

namespace OfflineCodingExercise.Shared
{
    public class Message : IMessage
    {
        public void Error(string message)
        {
            MessageBox.Show(message, "Offline Coding Exercise", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Ok(string message)
        {
            MessageBox.Show(message,"Offline Coding Exercise", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string message)
        {
            MessageBox.Show(message, "Offline Coding Exercise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
