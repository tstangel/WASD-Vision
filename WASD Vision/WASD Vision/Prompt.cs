// http://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms

using System.Windows.Forms;

namespace WASD_Vision
{
    public static class Prompt
    {
        public static string ShowDialog(string PromptText, string WindowTitle, string ButtonText, bool hideCharacters)
        {
            Form prompt = new Form()
            {
                Width = 360,
                Height = 177,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = WindowTitle,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() {
                Left = 27,
                Top = 27,
                Width = prompt.Width - 70,
                Height = 50,
                Text = PromptText
            };
            TextBox textBox = new TextBox() {
                Left = 27,
                Top = 90,
                Width = 220,
                PasswordChar = '*'
            };
            Button confirmation = new Button() {
                Text = ButtonText,
                Left = textBox.Width + textBox.Left + 7,
                Width = 50,
                Top = textBox.Top - 3,
                DialogResult = DialogResult.OK
            };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
