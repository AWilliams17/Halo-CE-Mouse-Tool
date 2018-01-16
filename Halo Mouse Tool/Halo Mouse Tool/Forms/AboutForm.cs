using System.Windows.Forms;
using System.Diagnostics;

namespace Halo_Mouse_Tool
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void RedditLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/r/halospv3/search?q=subreddit%3Ahalospv3+mouse+tool+v6&sort=relevance&t=all");
        }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }
    }
}
