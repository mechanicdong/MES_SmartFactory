﻿using System;
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

/// <summary>
/// 3조 DBA 조재호
/// 2020-10-11
/// </summary>
namespace Upsert
{
    public partial class Worker : MetroForm, IChildForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        InputPopup_Worker popup;
        List<string> list = new List<string>();
        public Worker()
        {
            InitializeComponent();
        }
        public string StoredProcedureName() => "WORKER_UPSERT";

        private void DieaseUpdateEventMethod(object sender)
        {
            //폼2에서 델리게이트로 이벤트 발생하면 현재 함수 Call
            list = (List<string>)sender;
            SaveItem();
            SelectItem();

        }

        private void Child_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 데이터 조회 결과를 adapter로 받아 DataSet을 반환 받은 경우 사용되는 메서드
        /// </summary>
        /// <param name="ds">데이터 조회 결과</param>
        public void FillGrid (DataSet ds)
        {
            grd_Result.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 데이터베이스에 연결해 데이터를 조회하는 IChildForm 인터페이스 구현
        /// </summary>
        public int SelectItem()
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
                    CommandText = "select trim(PLANT_CODE), trim(WC_CODE), trim(SHIFT_CODE), SHIFT_NAME, trim(SA_SABUN), REQ_MP_MAN, REQ_MP_WOMAN, REQ_MP_OUT, START_TIME, END_TIME, WORKING_TIME, BIGO, trim(USE_FLAG), trim(DEL_FLAG), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER from tbl_worker where trim(PLANT_CODE) like '%' || :SeachVal || '%' AND DEL_FLAG = 'A'"
                };

                if (txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PLANT_CODE), trim(WC_CODE), trim(SHIFT_CODE), SHIFT_NAME, trim(SA_SABUN), REQ_MP_MAN, REQ_MP_WOMAN, REQ_MP_OUT, START_TIME, END_TIME, WORKING_TIME, BIGO, trim(USE_FLAG), trim(DEL_FLAG), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER from tbl_worker";

                else if (txt_SeachVal.Text.Equals("") && !ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PLANT_CODE), trim(WC_CODE), trim(SHIFT_CODE), SHIFT_NAME, trim(SA_SABUN), REQ_MP_MAN, REQ_MP_WOMAN, REQ_MP_OUT, START_TIME, END_TIME, WORKING_TIME, BIGO, trim(USE_FLAG), trim(DEL_FLAG), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER from tbl_worker where DEL_FLAG = 'A'";

                else if (!txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PLANT_CODE), trim(WC_CODE), trim(SHIFT_CODE), SHIFT_NAME, trim(SA_SABUN), REQ_MP_MAN, REQ_MP_WOMAN, REQ_MP_OUT, START_TIME, END_TIME, WORKING_TIME, BIGO, trim(USE_FLAG), trim(DEL_FLAG), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER from tbl_worker where trim(PLANT_CODE) like '%' || :SeachVal || '%'";

                cmd.Parameters.Add("SeachVal", txt_SeachVal.Text);

                /*OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                FillGrid(ds);*/
                
                OracleDataReader reader = cmd.ExecuteReader();

                grd_Result.Rows.Clear();

                int i_cnt = 0;

                while (reader.Read())
                {
                    grd_Result.Rows.Add(++i_cnt, reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12], reader[13], reader[14], reader[15], reader[16], reader[17]);
                }
                
                return i_cnt;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void grd_Data_KeyUp(object sender, KeyEventArgs e)
        {
            int i_RowIndex = grd_Result.CurrentRow.Index;

            List<string> list = new List<string>();

            foreach (DataGridViewCell item in grd_Result.Rows[i_RowIndex].Cells)
            {
                list.Add(item.Value.ToString());
            }

            popup = new InputPopup_Worker(list);
            popup.FormSendEvent += new InputPopup_Worker.FormSendDataHandler(DieaseUpdateEventMethod);
            popup.ShowDialog();

            /*txt_ID.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Name.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Path.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Version.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();
            txt_Class.Text = grd_Result.Rows[rowIndex].Cells[5].Value.ToString();*/
        }

        private void grd_Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i_RowIndex = grd_Result.CurrentRow.Index;

            List<string> list = new List<string>();

            foreach (DataGridViewCell item in grd_Result.Rows[i_RowIndex].Cells)
            {
                list.Add(item.Value.ToString());
            }

            popup = new InputPopup_Worker(list);
            popup.FormSendEvent += new InputPopup_Worker.FormSendDataHandler(DieaseUpdateEventMethod);
            popup.ShowDialog();

            /*txt_ID.Text = grd_Result.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Name.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Path.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Version.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Class.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();*/
        }

        /// <summary>
        /// 저장 프로시저를 불러와서 있는 ID값이면 Update, 없는 ID값이면 Insert를 수행
        /// </summary>
        public bool SaveItem()
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
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = StoredProcedureName()
                };

                cmd.Parameters.Add("IN_PLANT_CODE", list[0]);
                cmd.Parameters.Add("IN_WC_CODE", list[1]);
                cmd.Parameters.Add("IN_SHIFT_CODE", list[2]);
                cmd.Parameters.Add("IN_SHIFT_NAME", list[3]);
                cmd.Parameters.Add("IN_SA_SABUN", list[4]);
                cmd.Parameters.Add("IN_REQ_MP_MAN", list[5]);
                cmd.Parameters.Add("IN_REQ_MP_WOMAN", list[6]);
                cmd.Parameters.Add("IN_REQ_MP_OUT", list[7]);
                cmd.Parameters.Add("IN_START_TIME", list[8]);
                cmd.Parameters.Add("IN_END_TIME", list[9]);
                cmd.Parameters.Add("IN_WORKING_TIME", list[10]);
                cmd.Parameters.Add("IN_BIGO", list[11]);
                cmd.Parameters.Add("IN_USE_FLAG", list[12]);
                cmd.Parameters.Add("IN_DEL_FLAG", list[13]);
                cmd.Parameters.Add("IN_INSERT_USER", list[15]);
                cmd.Parameters.Add("IN_UPDATE_USER", list[17]);

                cmd.ExecuteNonQuery();

                return true;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            popup = new InputPopup_Worker();
            popup.FormSendEvent += new InputPopup_Worker.FormSendDataHandler(DieaseUpdateEventMethod);
            popup.ShowDialog();
        }

        public bool DeleteItem()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                int i_RowIndex = grd_Result.CurrentRow.Index;
                string s_DelPrimaryKey = grd_Result.Rows[i_RowIndex].Cells[1].Value.ToString();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "update tbl_worker set DEL_FLAG = 'D', update_date = SYSDATE where trim(PLANT_CODE) = :DeleteVal"
                };

                cmd.Parameters.Add("DeleteVal", s_DelPrimaryKey);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}