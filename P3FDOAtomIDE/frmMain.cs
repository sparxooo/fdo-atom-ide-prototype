using P3FDOAtomParsing;

namespace P3FDOAtomIDE
{
    public partial class frmMain : Form
    {

        public List<P3Packet> packets = new List<P3Packet>();
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            packets.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                // Try parsing...
                foreach (string packet in txtPacket.Lines)
                {
                    P3Packet p = new P3Packet(Convert.FromHexString(txtPacket.Text));
                    packets.Add(p);
                }

                // After, add all to list box
                foreach (P3Packet p in packets)
                {
                    listBox2.Items.Add(new KeyValuePair<string, P3Packet>(p.Type.ToString(), p));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                P3Packet p = ((KeyValuePair<string, P3Packet>)listBox2.SelectedItem).Value;
                pgPacket.SelectedObject = p;
                pgFDO.SelectedObject = p.FDO;

                foreach(Atom a in p.FDO.Atoms)
                {
                    listBox1.Items.Add(new KeyValuePair<string, Atom>(a.AtomName, a));
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                pgSelAtom.SelectedObject = ((KeyValuePair<string, Atom>)listBox1.SelectedItem).Value;
            }
            
        }

        private void pgSelAtom_Click(object sender, EventArgs e)
        {

        }
    }
}