using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;


namespace PicturePassword
{
    public partial class frmContainer : Form
    {
        public frmContainer()
        {
            InitializeComponent();
        }

        string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+AppDomain.CurrentDomain.BaseDirectory+"PictureLoginDB.mdf;Integrated Security=True";
        // default picture is flower
        System.Drawing.Image img = Properties.Resources.flower;
        Bitmap bmp = (Bitmap)Properties.Resources.flower;

        // an array to store reference point when user click to setup password
        double[,] referPoint = new double[3, 2];

        // a field to hold username that user type
        string username;

        int i = 0; // count click on picture box

        int j = 0;  // count click on confirm

        const double Tolerance = 5.0; // Tolerance in pixels

        // method to hash password before store in databse
        // hash 256 with the salt string and password string that user type in
        private String generateHashSHA256(String password, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            SHA256Managed sHA256Managed = new SHA256Managed();
            byte[] hash = sHA256Managed.ComputeHash(bytes);

            return Convert.ToBase64String(hash);

        }

        // this method to create a random salt string 
        private String createSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to validate clicked coordinates
        public bool ValidateClick(double clickedX, double clickedY)
        {
            for (int i = 0; i < referPoint.GetLength(0); i++)
            {
                double distance = CalculateDistance(clickedX, clickedY, referPoint[i, 0], referPoint[i, 1]);
                if (distance <= Tolerance)
                {
                    return true; // Click is within tolerance range of a reference point
                }
            }
            return false; // Click is not within tolerance range of any reference point
        }

        private double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        // a method to filter image extention when open file diablog
        private static string GetImageFilter()
        {
            return
                "All Files (*.*)|*.*" +
                "|All Pictures (*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.emz;*.wmz;*.tif;*.tiff;*.svg;*.ico)" +
                    "|*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.emz;*.wmz;*.tif;*.tiff;*.svg;*.ico" +
                "|Windows Enhanced Metafile (*.emf)|*.emf" +
                "|Windows Metafile (*.wmf)|*.wmf" +
                "|JPEG File Interchange Format (*.jpg;*.jpeg;*.jfif;*.jpe)|*.jpg;*.jpeg;*.jfif;*.jpe" +
                "|Portable Network Graphics (*.png)|*.png" +
                "|Bitmap Image File (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle" +
                "|Compressed Windows Enhanced Metafile (*.emz)|*.emz" +
                "|Compressed Windows MetaFile (*.wmz)|*.wmz" +
                "|Tag Image File Format (*.tif;*.tiff)|*.tif;*.tiff" +
                "|Scalable Vector Graphics (*.svg)|*.svg" +
                "|Icon (*.ico)|*.ico";
        }

        //choosing the picture
        private void btnChoose_Click_1(object sender, EventArgs e)
        {
            //an open file dialog to select piture, filterindex = 2 to select all picture
            // multiselect set to false to prevent user select multiple picture
            OpenFileDialog openFD = new OpenFileDialog() { Filter = GetImageFilter(), Multiselect = false, FilterIndex = 2 };

            DialogResult result = openFD.ShowDialog();

            if (result == DialogResult.OK)
            {
                img = System.Drawing.Image.FromFile(openFD.FileName);
                bmp = (Bitmap)img;
                pbxLoadImg.Image = bmp;
                btnUseThisPicture.Visible = true;
            }
        }

        private void btnUseThisPicture_Click(object sender, EventArgs e)
        {
            btnChoose.Visible = false;
            btnUseThisPicture.Visible = false;

            lblNum1.ForeColor = SystemColors.ControlText;
            lblNum1.Visible = true;
            lblNum2.Visible = true;
            lblNum3.Visible = true;

            lblInstruction.Text = "Click at any position in the picture to create your password";
        }

        private void pbxLoadImg_Click(object sender, EventArgs e)
        {
            if (btnUseThisPicture.Visible == false)
            {
                // an array to store referebce point with 3 row of data
                // each row has 2 column containing X and Y

                var mouseEventArgs = e as MouseEventArgs;

                bool flag = false; // flag of confirm reference point

                if (mouseEventArgs != null && i < 3)
                {

                    if (i == 0)
                    {
                        lblNum1.ForeColor = Color.LightGray;
                        lblNum2.ForeColor = SystemColors.ControlText;
                    }

                    if (i == 1)
                    {
                        lblNum2.ForeColor = Color.LightGray;
                        lblNum3.ForeColor = SystemColors.ControlText;
                    }

                    referPoint[i, 0] = mouseEventArgs.X;
                    referPoint[i, 1] = mouseEventArgs.Y;
                    i++;
                }
                // it now time to confirm reference point
                if (i >= 3)
                {
                    lblTitle.Text = "Confirm your password";
                    lblInstruction.Text = "Select the same position to confirm your password";
                    lblNum1.ForeColor = Color.LightGray;
                    lblNum2.ForeColor = Color.LightGray;
                    lblNum3.ForeColor = Color.LightGray;

                    if (mouseEventArgs != null && j <= 3)
                    {
                        if (j == 0)
                        {
                            lblNum1.ForeColor = SystemColors.ControlText;
                        }

                        if (j == 1)
                        {
                            lblNum1.ForeColor = Color.LightGray;
                            lblNum2.ForeColor = SystemColors.ControlText;
                        }

                        if (j == 2)
                        {
                            lblNum2.ForeColor = Color.LightGray;
                            lblNum3.ForeColor = SystemColors.ControlText;
                        }
                        // confirm the point is the same with point has been set as password
                        // if have any error the flag will raise and change status
                        if (ValidateClick(mouseEventArgs.X, mouseEventArgs.Y) == false)
                        {
                            flag = true;
                        }
                        j++;

                    }

                    if (j == 4)
                    {
                        // if flag still the same as original state
                        // it mean the confirm point is the same with the point has been set as password
                        if (flag == false)
                        {
                            lblTitle.Text = "Your last step!";
                            lblInstruction.Text = "Setting your username account";

                            lblNum1.Visible = false;
                            lblNum2.Visible = false;
                            lblNum3.Visible = false;

                            lblUsername.Visible = true;
                            txtUsername.Visible = true;
                            btnFinish.Visible = true;

                            btnCancel.Visible = false;
                        }
                        else
                        {
                            lblTitle.Text = "The password does not match!";
                            lblInstruction.Text = "please try to confirm your password again or start over";

                            lblNum1.Visible = false;
                            lblNum2.Visible = false;
                            lblNum3.Visible = false;

                            btnTryAgain.Visible = true;
                            btnStartOver.Visible = true;
                            btnFinish.Visible = false;
                            btnCancel.Visible = true;
                        }

                    }

                }
            }
        }
        private string generateCordinate(double[,] referencePoint) 
        {
            string coordinateStr = "";
            for(int i = 0;i< referencePoint.GetLength(0);i++) 
            {
                coordinateStr += referencePoint[i, 0] + referencePoint[i, 1];
            }
            return coordinateStr;
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                // save data into database
                // validate username
                // username can not empty or contain special character <> ? ! -  to prevent script attack
                string pattern = @"[<>?!-]";                

                if (string.IsNullOrEmpty(txtUsername.Text) || Regex.IsMatch(txtUsername.Text, pattern))

                {
                    erpUsername.SetError(txtUsername, "Username can not empty or contain special character like < > ? ! -");
                }
                else
                {
                    erpUsername.SetError(txtUsername, "");
                    username = txtUsername.Text;

                    // create a connection with database
                    SqlConnection con = new SqlConnection(connStr);
                    // open connection
                    con.Open();
                    string sqlQuery = "INSERT INTO [dbo].tbl_picture_login (user_name,image,salt, password) VALUES (@user,@image,@salt,@password)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    string salt = createSalt(10);
                    string coordinateStr = generateCordinate(referPoint);

                    // turn image into binary so it can be store into database
                    byte[] imgData;

                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        imgData = stream.ToArray();
                    }

                    // if coordinate is not null or not containt default coordinate -1-1
                    if (!string.IsNullOrEmpty(coordinateStr) || !coordinateStr.Contains("-1-1-1-1-1-1")) 
                    {
                        // hash the coordinate before store in database
                        string hashedPassword = generateHashSHA256(coordinateStr, salt);
                        // send data into sql query to excute insert
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@image", imgData);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        if (cmd.ExecuteNonQuery() > 0)
                        {                           
                          // after successfull insert into database
                          // open form login or close this form
                           this.Close();
                        }
                    }

                    con.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create this acount!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            // the number 1,2,3 appear again
            btnTryAgain.Visible = false;
            lblNum1.Visible = true;
            lblNum2.Visible = true;
            lblNum3.Visible = true;

            // confirm coordinate again
            // set confirm back to 0
            j = 0;

            // reset the confirm flag
            bool flag = false;

            //use mouse event
            var mouseEventArgs = e as MouseEventArgs;

            if (i >= 3)
            {
                lblTitle.Text = "Confirm your password";
                lblInstruction.Text = "Select the same position to confirm your password";
                // blur the number
                lblNum1.ForeColor = Color.LightGray;
                lblNum2.ForeColor = Color.LightGray;
                lblNum3.ForeColor = Color.LightGray;

                if (mouseEventArgs != null && j <= 3)
                {
                    if (j == 0)
                    {
                        lblNum1.ForeColor = SystemColors.ControlText;
                    }

                    if (j == 1)
                    {
                        lblNum1.ForeColor = Color.LightGray;
                        lblNum2.ForeColor = SystemColors.ControlText;
                    }

                    if (j == 2)
                    {
                        lblNum2.ForeColor = Color.LightGray;
                        lblNum3.ForeColor = SystemColors.ControlText;
                    }
                    // confirm the point is the same with point has been set as password
                    // if have any error the flag will raise and change status
                    if (ValidateClick(mouseEventArgs.X, mouseEventArgs.Y) == false)
                    {
                        flag = true;
                    }
                    j++;

                }

                if (j == 4)
                {
                    // if flag still the same as original state
                    // it mean the confirm point is the same with the point has been set as password
                    if (flag == false)
                    {
                        lblTitle.Text = "Your last step!";
                        lblInstruction.Text = "Setting your username account";
                        //hide number 1,2,3
                        lblNum1.Visible = false;
                        lblNum2.Visible = false;
                        lblNum3.Visible = false;
                        //show username lable and textbox
                        lblUsername.Visible = true;
                        txtUsername.Visible = true;
                        // show button finish 
                        btnFinish.Visible = true;
                        // hide button cancel
                        btnCancel.Visible = false;
                    }
                    else
                    {
                        lblTitle.Text = "The password does not match!";
                        lblInstruction.Text = "please try to confirm your password again or start over";
                        // hide the number 1,2,3
                        lblNum1.Visible = false;
                        lblNum2.Visible = false;
                        lblNum3.Visible = false;

                        // show button try again                     
                        btnTryAgain.Visible = true;
                        //show button start over
                        btnStartOver.Visible = true;
                        // show button cancel
                        btnCancel.Visible = true;

                        btnFinish.Visible = false;
                    }

                }

            }
        }
        // start over the process of create picture password
        private void btnStartOver_Click(object sender, EventArgs e)
        {
            // reset all choosence
            // default picture is flower
            img = Properties.Resources.flower;
            bmp = (Bitmap)Properties.Resources.flower;

            // an array to store reference point when user click to setup password
            for (int row = 0; row < referPoint.GetLength(0); row++)
            {
                // set X = -1
                referPoint[row, 0] = -1;
                // set Y = -1
                referPoint[row, 1] = -1;
            }

            i = 0; // count click on picture box

            j = 0;  // count click on confirm

            //----------------------------------------------
            // show the setup picture as begining
            btnChoose.Visible = true;
            btnUseThisPicture.Visible = true;
            btnCancel.Visible = true;

            // hide all other textbox and button when startover from correct
            lblUsername.Visible = false;
            txtUsername.Visible = false;
            btnFinish.Visible = false;

            btnTryAgain.Visible = false;
            btnStartOver.Visible = false;

            // change lable tile and instrcution
            lblTitle.Text = "Wellcome to Picture Password";
            lblInstruction.Text = "Use the default picture or choose your own picture";

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) 
            {
                erpUsername.SetError(txtUsername, "");
            }
        }
    }
}
