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
    public partial class WorkPlan : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        Main main;
        public WorkPlan()
        {
            InitializeComponent();

            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        public WorkPlan(Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btn_plan_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)grd_Result.DataSource;

            Reservation reservation = new Reservation(this);
            reservation.ShowDialog();
        }
    

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
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
                    CommandText = "SELECT A.PROD_CODE as 제품내역, B.PROD_NAME as 제품명, A.PROD_UNIT as 제품단위, A.ORDER_M as 작업지시량, A.ADD_GOOD_QTY as 누적양품량, TO_CHAR(CASE WHEN A.ORDER_M = 0 THEN 0 ELSE A.ADD_GOOD_QTY / A.ORDER_M * 100 END, '990.0') as 누적양품비율, DECODE(A.GUBUN, 'A', '내수', 'B', '수출', 'C', '특판', ' ') 주문형식, DECODE(A.WORK_GUBUN, 'A', '정상작업', 'U', '재작업', 'R', '연구개발', 'T', '기술테스트', 'S', 'S/BOOK', 'C', 'C/MATCH', ' ') 작업구분, DECODE(A.NOTE_FLAG, 'Y', '★', ' ') NOTE_FLAG, DECODE(A.PROC_STATUS, 'Y', '가능', 'A', '예약', 'B', '진행', 'C', '생산', 'E', '종료', 'D', '취소', ' ') 생산상태, TO_CHAR(A.START_DATE, 'YYYY-MM-DD HH24:MI') 시작일자, TO_CHAR(A.END_DATE, 'YYYY-MM-DD HH24:MI') 종료일자, A.JOB_NO as 작업번호, A.ORDER_NO || '-' || A.ORDER_SEQ as 주문번호 , A.NOTE0 as 비고, A.NOTE1 as 비고2, B.MRP_MGR as MRP관리자 FROM TBL_PRODUCTPLAN A, TBL_ProductMaster B WHERE A.PROD_CODE = B.PROD_CODE AND A.PLANT_CODE = :IN_PLANT_CODE AND A.JOB_DATE = :IN_JOB_DATE AND A.PROC_STATUS <> 'N' AND A.DEL_FLAG = 'A' ORDER BY A.START_DATE, A.JOB_NO"
                };


                cmd.Parameters.Add("IN_PLANT_CODE", "2020");
                cmd.Parameters.Add("IN_JOB_DATE", dateTimePicker2.Value.ToString("yyyyMMdd"));


                OracleDataReader reader = cmd.ExecuteReader();

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

        private void grd_Result_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            grd_Result.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            }
        }

        private void grd_Result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Reservation_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Working_Click(object sender, EventArgs e)
        {
            main.CallWorking();
        }

        private void btn_Inspection_Click(object sender, EventArgs e)
        {
            main.CallInspection();
        }

        private void btn_Defect_Click(object sender, EventArgs e)
        {
            main.CallStartingMenu();
        }

        private void btn_SAPOrder_Click(object sender, EventArgs e)
        {
            main.CallSAPOrder();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            int totalRows = grd_Result.Rows.Count;
            int colIndex = grd_Result.SelectedCells[0].OwningColumn.Index;
            int rowIndex = grd_Result.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;
            grd_Result.ClearSelection();
            grd_Result.Rows[0].Cells[colIndex].Selected = true;


        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            int totalRows = grd_Result.Rows.Count;
            int colIndex = grd_Result.SelectedCells[0].OwningColumn.Index;
            int rowIndex = grd_Result.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;
            grd_Result.ClearSelection();
            grd_Result.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            int totalRows = grd_Result.Rows.Count;
            int colIndex = grd_Result.SelectedCells[0].OwningColumn.Index;
            int rowIndex = grd_Result.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;
            grd_Result.ClearSelection();
            grd_Result.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            int totalRows = grd_Result.Rows.Count;
            int colIndex = grd_Result.SelectedCells[0].OwningColumn.Index;
            int rowIndex = grd_Result.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;
            grd_Result.ClearSelection();
            grd_Result.Rows[grd_Result.Rows.Count - 1].Cells[colIndex].Selected = true;
        }

        private void WorkPlan_Activated(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btn_SAPOrder_MouseUp(object sender, MouseEventArgs e)
        {
            btn_SAPOrder.BackgroundImage = FinalProject_Profile.Properties.Resources.생산계획접수;
        }

        private void btn_SAPOrder_MouseDown(object sender, MouseEventArgs e)
        {
            btn_SAPOrder.BackgroundImage = FinalProject_Profile.Properties.Resources.생산계획접수클릭;
        }

        private void btn_WorkPlan_MouseUp(object sender, MouseEventArgs e)
        {
            btn_WorkPlan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업계획;
        }

        private void btn_WorkPlan_MouseDown(object sender, MouseEventArgs e)
        {
            btn_WorkPlan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업계획클릭;
        }

        private void btn_Working_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Working.BackgroundImage = FinalProject_Profile.Properties.Resources.작업진행;
        }

        private void btn_Working_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Working.BackgroundImage = FinalProject_Profile.Properties.Resources.작업진행클릭;
        }

        private void btn_Inspection_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Inspection.BackgroundImage = FinalProject_Profile.Properties.Resources.검사성적서;
        }

        private void btn_Inspection_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Inspection.BackgroundImage = FinalProject_Profile.Properties.Resources.검사성적서클릭;
        }

        private void btn_Defect_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Defect.BackgroundImage = FinalProject_Profile.Properties.Resources.생산현황;
        }

        private void btn_Defect_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Defect.BackgroundImage = FinalProject_Profile.Properties.Resources.생산현황클릭;
        }

        private void btn_plan_MouseUp(object sender, MouseEventArgs e)
        {
            btn_plan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업예약;
        }

        private void btn_plan_MouseDown(object sender, MouseEventArgs e)
        {
            btn_plan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업예약클릭;
        }

        private void btn_Top_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Top.BackgroundImage = FinalProject_Profile.Properties.Resources.위끝;
        }

        private void btn_Top_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Top.BackgroundImage = FinalProject_Profile.Properties.Resources.위끝클릭;
        }

        private void btn_Middle_Top_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Middle_Top.BackgroundImage = FinalProject_Profile.Properties.Resources.위;
        }

        private void btn_Middle_Top_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Middle_Top.BackgroundImage = FinalProject_Profile.Properties.Resources.위클릭;
        }

        private void btn_Bottom_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Bottom.BackgroundImage = FinalProject_Profile.Properties.Resources.아래끝;
        }

        private void btn_Bottom_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Bottom.BackgroundImage = FinalProject_Profile.Properties.Resources.아래끝클릭;
        }

        private void btn_Middle_Bottom_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Middle_Bottom.BackgroundImage = FinalProject_Profile.Properties.Resources.아래;
        }

        private void btn_Middle_Bottom_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Middle_Bottom.BackgroundImage = FinalProject_Profile.Properties.Resources.아래클릭;
        }
    }
}
