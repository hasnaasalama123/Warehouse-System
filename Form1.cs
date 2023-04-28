using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        EFModel Ent = new EFModel();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Store s in Ent.Stores)
            {
                comboBox1.Items.Add(s.Sid);
            }
            foreach (Vendor v in Ent.Vendors)
            {
                comboBox5.Items.Add(v.Vid);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            Store st = Ent.Stores.Find(id);
            textBox1.Text = st.Sid.ToString();
            textBox2.Text = st.Name;
            textBox3.Text = st.Address;
            textBox4.Text = st.managername;
            var h = (st.Products);
            
            comboBox2.Items.Clear();
            foreach (var item in h)
            {
                comboBox2.Items.Add(item.Code);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store st = new Store();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Store s = Ent.Stores.Find(int.Parse(textBox1.Text));
                if (s == null)
                {
                    st.Sid = int.Parse(textBox1.Text);
                    st.Name = textBox2.Text;
                    st.Address = textBox3.Text;
                    st.managername = textBox4.Text;
                    Ent.Stores.Add(st);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Store is avalible");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Store st = Ent.Stores.Find(int.Parse(textBox1.Text));
            if (st != null)
            {
                if (textBox2.Text != "")
                {
                    st.Name = textBox2.Text;
                    st.Address = textBox3.Text;
                    st.managername = textBox4.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Name isnot available");
                }

            }
            else
            {
                MessageBox.Show("store isnot avaliable");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product p = Ent.Products.Find(int.Parse(textBox5.Text));
            if (p != null)
            {
                if (textBox6.Text != "")
                {
                    p.Name = textBox6.Text;
                    p.Quantity = int.Parse(textBox7.Text);
                    p.date = DateTime.Parse(textBox8.Text);
                    p.validity = int.Parse(textBox9.Text);
                    Ent.SaveChanges();
                    MessageBox.Show("product updated");
                    textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                }
                else
                {
                    MessageBox.Show("Name isnot available");
                }

            }
            else
            {
                MessageBox.Show("product isnot avaliable");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox3.Text);
            Vendor v = Ent.Vendors.Find(id);
            textBox10.Text = v.Vid.ToString();
            textBox11.Text = v.Name;
            textBox12.Text = v.phone.ToString();
            textBox13.Text = v.mail;
            textBox18.Text = v.mobile.ToString();
            textBox19.Text = v.fax;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vendor d = new Vendor();
            if (textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
            {
                int id = int.Parse(comboBox2.Text);
                int vid = int.Parse(textBox10.Text);
                Vendor n = Ent.Vendors.Find(int.Parse(textBox10.Text));
                if (n == null)
                {
                    d.Vid = vid;
                    d.Name = textBox11.Text;
                    d.phone = int.Parse(textBox12.Text);
                    d.mail = textBox13.Text;
                    d.mobile = int.Parse(textBox18.Text);
                    d.fax = textBox19.Text;
                    Ent.Vendors.Add(d);

                    Product p = Ent.Products.Find(id);
                    Request q = new Request()
                    {
                        code = id,
                        Vid = vid

                    };
                    Ent.Requests.Add(q);
                    Ent.SaveChanges();
                    comboBox3.Items.Add(textBox10.Text);
                    comboBox5.Items.Add(textBox10.Text);
                    textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox18.Text = textBox19.Text = "";
                }
                else
                {
                    MessageBox.Show("Vendore is avalible");
                    textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox18.Text = textBox19.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }






        }

        private void button6_Click(object sender, EventArgs e)
        {
            Vendor st = Ent.Vendors.Find(int.Parse(textBox10.Text));
            if (st != null)
            {
                if (textBox11.Text != "")
                {
                    st.Name = textBox11.Text;
                    st.phone = int.Parse(textBox12.Text);
                    st.mail = textBox13.Text;
                    st.mobile = int.Parse(textBox18.Text);
                    st.fax = textBox19.Text;
                    Ent.SaveChanges();
                    MessageBox.Show("data of vendor is updated");
                    textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox18.Text = textBox19.Text = "";
                }
                else
                {
                    MessageBox.Show("Name isnot available");
                }

            }
            else
            {
                MessageBox.Show("vendor isnot avaliable");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            if (textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                int id = int.Parse(comboBox1.Text);
                int code = int.Parse(textBox5.Text);
                Product pt = Ent.Products.Find(code);
                if (pt == null)
                {
                    p.Code = code;
                    p.Name = textBox6.Text;
                    p.Quantity = int.Parse(textBox7.Text);
                    p.date = DateTime.Parse(textBox8.Text);
                    p.validity = int.Parse(textBox9.Text);
                    Ent.Products.Add(p);
                    Store s = Ent.Stores.FirstOrDefault(a => a.Sid == id);
                    s.Products.Add(p);
                    int vid = int.Parse(comboBox5.Text);
                    Vendor v = Ent.Vendors.Find(vid);
                    Request r = new Request();
                    r.code = code;
                    r.Vid = vid;
                    Ent.Requests.Add(r);
                    Ent.SaveChanges();
                    MessageBox.Show("product added");
                    textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = comboBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("product id is exist");
                }
            }
            else
            {
                MessageBox.Show("plz enter data in all fields");
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(comboBox2.Text);
            Product p = Ent.Products.Find(id);
            textBox5.Text = p.Code.ToString();
            textBox6.Text = p.Name;
            textBox7.Text = p.Quantity.ToString();
            textBox8.Text = p.date.ToString();
            textBox9.Text = p.validity.ToString();
            var r = (from b in Ent.Products
                     join q in Ent.Requests
                     on b.Code equals q.code
                     join v in Ent.Vendors
                     on q.Vid equals v.Vid
                     where b.Code == id
                     select v.Vid).ToList();
            var t = (from u in Ent.Products
                     join o in Ent.Orders
                     on u.Code equals o.code
                     join c in Ent.Clients
                     on o.Cid equals c.Cid
                     where u.Code == id
                     select c.Cid).ToList();

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            foreach (var item in r)
            {
                comboBox3.Items.Add(item);
            }
            foreach (var item in t)
            {
                comboBox4.Items.Add(item);
            }


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {


        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Client t = Ent.Clients.Find(int.Parse(textBox14.Text));
            if (t != null)
            {
                if (textBox15.Text != "")
                {
                    t.Name = textBox15.Text;
                    t.Phone = int.Parse(textBox16.Text);
                    t.mail = textBox17.Text;
                    t.Phone = int.Parse(textBox20.Text);
                    t.fax = textBox21.Text;

                    Ent.SaveChanges();
                    MessageBox.Show("data of client is updated");
                    textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox20.Text = textBox21.Text = "";
                }
                else
                {
                    MessageBox.Show("Name isnot available");
                }

            }
            else
            {
                MessageBox.Show("client isnot avaliable");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox4.Text);
            Client l = Ent.Clients.Find(id);
            textBox14.Text = l.Cid.ToString();
            textBox15.Text = l.Name;
            textBox16.Text = l.Phone.ToString();
            textBox17.Text = l.mail;
            textBox20.Text = l.moblie.ToString();
            textBox21.Text = l.fax;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Client t = new Client();
            if (textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" && textBox17.Text != "")
            {
                int id = int.Parse(comboBox2.Text);
                int cid = int.Parse(textBox14.Text);
                Client c = Ent.Clients.Find(int.Parse(textBox14.Text));
                if (c == null)
                {
                    t.Cid = int.Parse(textBox14.Text);
                    t.Name = textBox15.Text;
                    t.Phone = int.Parse(textBox16.Text);
                    t.mail = textBox17.Text;
                    t.Phone = int.Parse(textBox20.Text);
                    t.fax = textBox21.Text;
                    Ent.Clients.Add(t);
                    Product p = Ent.Products.Find(id);
                    Order o = new Order()
                    {
                        code = id,
                        Cid = cid
                    };
                    Ent.Orders.Add(o);

                    Ent.SaveChanges();
                    comboBox4.Items.Add(textBox14.Text);
                    textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox20.Text = textBox21.Text = "";
                }
                else
                {
                    MessageBox.Show("client is avalible");
                    textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox20.Text = textBox21.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Empty Data");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox22.Text != "" && textBox23.Text != "" && comboBox3.Text != "" && comboBox2.Text != "")
            {
                int vid = int.Parse(comboBox3.Text);
                Vendor vendor = Ent.Vendors.Find(vid);
                int productcode = int.Parse(comboBox2.Text);
                Product product = Ent.Products.Find(productcode);
                if (vendor != null && product != null)
                {
                    Request q = new Request
                    {
                        Rdate = DateTime.Parse(textBox22.Text),
                        Rnum = int.Parse(textBox23.Text),
                        code = productcode,
                        Vid = vid
                    };
                    Ent.Requests.Add(q);
                    try
                    {
                        Ent.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MessageBox.Show("request added successfully^");
                }
                else
                {
                    MessageBox.Show("Vendor or product not found");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var st = from s in Ent.Stores select s;
            foreach (var t in st)
            {
                listBox1.Items.Add(t.Sid + "\t" + t.Name + "\t" + t.Address +"\t"+t.managername);
            }
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            if (textBox22.Text != "" && textBox23.Text != "")
            {
                int vid = int.Parse(comboBox3.Text);
                Vendor vendor = Ent.Vendors.Find(vid);
                int productcode = int.Parse(comboBox2.Text);
                Product product = Ent.Products.Find(productcode);

                if (vendor != null && product != null)
                {
                    Request q = Ent.Requests.FirstOrDefault(x => x.code == productcode && x.Vid == vid);

                    if (q != null)
                    {
                        q.Rdate = DateTime.Parse(textBox22.Text);
                        q.Rnum = int.Parse(textBox23.Text);
                        try
                        {
                            Ent.SaveChanges();
                            MessageBox.Show("Request updated successfully");
                        }
                        catch (DbUpdateException ex)
                        {
                            Console.WriteLine( ex.Message);
                            MessageBox.Show("Error updating the request");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The specified Request does not exist");
                    }
                }
                else
                {
                    MessageBox.Show("Either the vendor or product does not exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox24.Text != "" && textBox25.Text != "" && comboBox4.Text != "" && comboBox2.Text != "")
            {
                int cid = int.Parse(comboBox4.Text);
               Client client = Ent.Clients.Find(cid);
                int productcode = int.Parse(comboBox2.Text);
                Product product = Ent.Products.Find(productcode);
                if (client != null && product != null)
                {
                    Order o = new Order()
                    {
                        Odate = DateTime.Parse(textBox24.Text),
                        Onum = int.Parse(textBox25.Text),
                        code = productcode,
                        Cid = cid
                    };
                    Ent.Orders.Add(o);
                    try
                    {
                        Ent.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MessageBox.Show("Order added successfully");
                }
                else
                {
                    MessageBox.Show("Client or product not found");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all  fields");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox24.Text != "" && textBox25.Text != "")
            {
                int cid = int.Parse(comboBox4.Text);
                Client client = Ent.Clients.Find(cid);
                int productcode = int.Parse(comboBox2.Text);
                Product product = Ent.Products.Find(productcode);

                if (client != null && product != null)
                {
                    Order r = Ent.Orders.FirstOrDefault(x => x.code == productcode && x.Cid == cid);

                    if (r != null)
                    {
                       r.Odate = DateTime.Parse(textBox24.Text);
                        r.Onum = int.Parse(textBox25.Text);
                        try
                        {
                            Ent.SaveChanges();
                            MessageBox.Show("Order updated successfully");
                        }
                        catch (DbUpdateException ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("Error updating the Order");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The specified Order does not exist");
                    }
                }
                else
                {
                    MessageBox.Show("Either the client or product does not exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
