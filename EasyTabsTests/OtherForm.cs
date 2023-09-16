using CoreLibrary.Logging;

namespace EasyTabsTests
{
    public partial class OtherForm : Form
    {
        public OtherForm()
        {
            InitializeComponent();
        }

        private void OtherForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
            LoggerFactory.Instance.GetLogger().Info(textBox1.Text, Application.ProductName);
        }
    }
}
