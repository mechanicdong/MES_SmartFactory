using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class Defect : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        Working working;
        Dictionary<string, string> result;

        int box_pcs, plt_box;
        string prod_code, order_no, prod_name, prod_unit, order_m, work_gbn, gubun, roll_no, wc_code;
        int good_qty = 0, good_box = 0, good_plt = 0;
        int total_qty = 0, total_box = 0, total_plt = 0;

        int bad_qty = 0, bad_box = 0, u_seq = 0;

        int left_bad_qty = 0, left_bad_box = 0, left_bad_plt = 0;

        private void label5_Click(object sender, EventArgs e)
        {
            if (left_bad_qty != 0)
            {
                if (MessageBox.Show("불량등록이 완료되지 않았습니다. 나가시겠습니까?", "Defect", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    this.Close();
                    working.Activate();
                }
                    
            }
            else
            {
                this.Close();
                working.Activate();
            }
                
            
        }

        private void Defect_FormClosed(object sender, FormClosedEventArgs e)
        {
            working.SelectItem();
            working.Activate();
        }

        private void btn_Whole_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Whole.BackgroundImage = FinalProject_Profile.Properties.Resources.전체;
        }

        private void btn_Whole_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Whole.BackgroundImage = FinalProject_Profile.Properties.Resources.전체클릭;
        }

        private void btn_1BOX_MouseUp(object sender, MouseEventArgs e)
        {
            btn_1BOX.BackgroundImage = FinalProject_Profile.Properties.Resources.한BOX;
        }

        private void btn_1BOX_MouseDown(object sender, MouseEventArgs e)
        {
            btn_1BOX.BackgroundImage = FinalProject_Profile.Properties.Resources.한BOX클릭;
        }

        private void btn_10PCS_MouseUp(object sender, MouseEventArgs e)
        {
            btn_10PCS.BackgroundImage = FinalProject_Profile.Properties.Resources.열PCS;
        }

        private void btn_10PCS_MouseDown(object sender, MouseEventArgs e)
        {
            btn_10PCS.BackgroundImage = FinalProject_Profile.Properties.Resources.열PCS클릭;
        }

        private void btn_1PCS_MouseUp(object sender, MouseEventArgs e)
        {
            btn_1PCS.BackgroundImage = FinalProject_Profile.Properties.Resources.한PCS;
        }

        private void btn_1PCS_MouseDown(object sender, MouseEventArgs e)
        {
            btn_1PCS.BackgroundImage = FinalProject_Profile.Properties.Resources.한PCS클릭;
        }

        private void btn_Initialization_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Initialization.BackgroundImage = FinalProject_Profile.Properties.Resources.갯수초기화;
        }

        private void btn_Initialization_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Initialization.BackgroundImage = FinalProject_Profile.Properties.Resources.갯수초기화클릭;
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기3;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기클릭3;
        }

        private void btn_Defect_Registration_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Defect_Registration.BackgroundImage = FinalProject_Profile.Properties.Resources.불량등록2;
        }

        private void btn_Defect_Registration_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Defect_Registration.BackgroundImage = FinalProject_Profile.Properties.Resources.불량등록클릭2;
        }

        private void Defect_Activated(object sender, EventArgs e)
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "SELECT A.B_SEQ 불량번호, B.FACTOR_NAME 불량명, A.BAD_QTY 불량량 from TBL_WCDEFECT A, TBL_DEFECTDTL B WHERE A.FACTOR_CODE = B.FACTOR_CODE AND ROLL_NO = :IN_ROLL_NO ORDER BY B_SEQ"
                };

                cmd.Parameters.Add("IN_ROLL_NO", roll_no);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                grd_Result.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        int r_bad_qty = 0, r_bad_box = 0;
        int i_bad_qty = 0, i_bad_box = 0;
        int p_qty = 0, b_seq = 0;

        public Defect()
        {
            InitializeComponent();
        }

        public Defect(Dictionary<string, string> _result, Working _working)
        {
            InitializeComponent();

            working = _working;

            result = _result;

            prod_code = result["PROD_CODE"];
            order_no = result["ORDER_NO"];
            prod_name = result["PROD_NAME"];
            prod_unit = result["PROD_UNIT"];
            order_m = result["ORDER_M"];
            work_gbn = result["WORK_GBN"];
            gubun = result["GUBUN"];
            roll_no = result["ROLL_NO"];
            wc_code = result["WC_CODE"];

            u_seq = Int32.Parse(result["U_SEQ"]);

            good_qty = Int32.Parse(result["GOOD_QTY"]);
            bad_qty = Int32.Parse(result["BAD_QTY"]);
            total_qty = Int32.Parse(result["TOTAL_QTY"]);

            box_pcs = Int32.Parse(result["BOX_PCS"]);
            plt_box = Int32.Parse(result["PLT_BOX"]);

            UpdateData();
            UpdateControl();
        }
        
        public void UpdateData()
        {
            total_box = total_qty / box_pcs;
            total_plt = total_box / plt_box;
            
            good_box = good_qty / box_pcs;
            good_plt = good_box / plt_box;

            bad_box = bad_qty / box_pcs;

            left_bad_qty = bad_qty - r_bad_qty;
            left_bad_box = left_bad_qty / box_pcs;

            i_bad_box = i_bad_qty / box_pcs;

            r_bad_box = r_bad_qty / box_pcs;
        }

        public void UpdateControl()
        {
            lbl_PROD_CODE.Text = prod_code;
            lbl_ORDER_NO.Text = order_no;
            lbl_PROD_NAME.Text = prod_name;
            lbl_PROD_UNIT.Text = prod_unit;
            lbl_ORDER_M.Text = order_m;
            lbl_WORK_GBN.Text = work_gbn;
            lbl_GUBUN.Text = gubun;

            lbl_Total_QTY.Text = total_qty.ToString();
            lbl_Total_BOX.Text = total_box.ToString();
            lbl_Total_PLT.Text = total_plt.ToString();

            lbl_i_Bad_QTY.Text = i_bad_qty.ToString();
            lbl_i_Bad_BOX.Text = i_bad_box.ToString();

            lbl_Good_QTY.Text = good_qty.ToString();
            lbl_Good_BOX.Text = good_box.ToString();
            lbl_Good_PLT.Text = good_plt.ToString();

            lbl_Bad_QTY.Text = bad_qty.ToString();
            lbl_Bad_BOX.Text = bad_box.ToString();

            lbl_Left_Bad_QTY.Text = left_bad_qty.ToString();
            lbl_Left_Bad_BOX.Text = left_bad_box.ToString();
            lbl_Left_Bad_PLT.Text = left_bad_plt.ToString();

            lbl_Registered_Bad_QTY.Text = r_bad_qty.ToString();
            lbl_Registered_Bad_BOX.Text = r_bad_box.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if(i_bad_qty == 0)
            {
                MessageBox.Show("등록할 불량 갯수를 선택해 주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SelectDefect selectDefect = new SelectDefect(this);
            selectDefect.Show();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void CheckData()
        {
            if(i_bad_qty > left_bad_qty)
            {
                i_bad_qty = p_qty;
                MessageBox.Show("남은 불량보다 수량이 많습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i_bad_qty = 0;
            UpdateData();
            UpdateControl();
        }

        private void lbl_ALL_Click(object sender, EventArgs e)
        {
            i_bad_qty = left_bad_qty;
            UpdateData();
            UpdateControl();
        }

        private void lbl_1BOX_Click(object sender, EventArgs e)
        {
            p_qty = i_bad_qty;
            i_bad_qty += box_pcs;
            CheckData();
            UpdateData();
            UpdateControl();
        }

        private void lbl_10PCS_Click(object sender, EventArgs e)
        {
            p_qty = i_bad_qty;
            i_bad_qty += 10;
            CheckData();
            UpdateData();
            UpdateControl();
        }

        private void lbl_1PCS_Click(object sender, EventArgs e)
        {
            p_qty = i_bad_qty;
            i_bad_qty += 1;
            CheckData();
            UpdateData();
            UpdateControl();
        }

        public void InsertData(string factor_code)
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "INSERT INTO tbl_wcdefect(ROLL_NO, S_SEQ, B_SEQ, PLANT_CODE, FACTOR_CODE, BAD_QTY, STD_QTY, WC_CODE, DEL_FLAG, INSERT_DATE, INSERT_USER) VALUES(:IN_ROLL_NO, 0, :IN_B_SEQ, :IN_PLANT_CODE, :IN_FACTOR_CODE, :IN_BAD_QTY, :IN_STD_QTY, :IN_WC_CODE, 'A', SYSDATE, 'DBA')"
                };

                cmd.Parameters.Add("IN_ROLL_NO", roll_no);
                cmd.Parameters.Add("IN_B_SEQ", b_seq);
                cmd.Parameters.Add("IN_PLANT_CODE", 2020);
                cmd.Parameters.Add("IN_FACTOR_CODE", factor_code);
                cmd.Parameters.Add("IN_BAD_QTY", i_bad_qty);
                cmd.Parameters.Add("IN_STD_QTY", i_bad_qty);
                cmd.Parameters.Add("IN_WC_CODE", wc_code);

                cmd.ExecuteNonQuery();

                r_bad_qty += i_bad_qty;
                i_bad_qty = 0;

                UpdateData();
                UpdateControl();

                b_seq++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
